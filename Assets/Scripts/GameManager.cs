using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public int score;
    public Text scoreText;
    public GameObject door1;
    public GameObject PauseMenu;
    public GameObject MainMenuRoot;
    public GameObject SettingRoot;
    public Slider MusicSlider;
    public Slider SFXSlider;
    public AudioSource musicSource;
    public AudioSource[] sfxSources;
    public AudioSource doorSFX;
    bool door1Open;
    // Start is called before the first frame update
    void Start()
    {
        door1Open = false;
        if(PauseMenu)
        {
            PauseMenu.SetActive(false);
        }
        if(MusicSlider)
        {
            MusicSlider.value = GetMusicVolume();
        }
        if(SFXSlider)
        {
            SFXSlider.value = GetSFXVolume();
        }
        if(musicSource)
        {
            musicSource.volume = GetMusicVolume() * 0.1f;
        }
        if(sfxSources.Length != 0)
        {
            foreach(var sfxSource in sfxSources)
            {
                sfxSource.volume = GetSFXVolume();
                if (sfxSource.tag == "Walk")
                {
                    sfxSource.volume = GetSFXVolume() * 0.1f;
                }
            }
        }
        score = 0;
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(FindObjectsOfType<EnemyController>().Length == 0)
        {
            if(door1)
            {
                if(doorSFX && !door1Open)
                {
                    doorSFX.Play();
                }
                door1.SetActive(false);
                door1Open = true;
            }        
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            PauseMenu.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
        }
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene("RPG");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Resume()
    {
        if(PauseMenu)
        {
            Cursor.lockState = CursorLockMode.Locked;
            PauseMenu.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void Back()
    {
        if(SettingRoot)
        {
            SettingRoot.SetActive(false);
        }
        if(MainMenuRoot)
        {
            MainMenuRoot.SetActive(true);
        }
    }

    public void GoSetting()
    {
        if (SettingRoot)
        {
            SettingRoot.SetActive(true);
        }
        if (MainMenuRoot)
        {
            MainMenuRoot.SetActive(false);
        }
    }

    public void SetMusicVolume(float value)
    {
        //Debug.LogError(value);
        PlayerPrefs.SetFloat("Music", value);
    }

    public void SetSFXVolume(float value)
    {
        //Debug.LogError(value);
        PlayerPrefs.SetFloat("SFX", value);
    }

    public float GetMusicVolume()
    {
        return PlayerPrefs.GetFloat("Music");
    }

    public float GetSFXVolume()
    {
        return PlayerPrefs.GetFloat("SFX");
    }
}
