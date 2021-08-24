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
    // Start is called before the first frame update
    void Start()
    {
        if(PauseMenu)
        {
            PauseMenu.SetActive(false);
        }
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(FindObjectsOfType<EnemyController>().Length == 0)
        {
            if(door1)
            {
                door1.SetActive(false);
            }        
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            PauseMenu.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
        }
        //TODO: Implement new score system
        //scoreText.text = "Score: " + score.ToString();
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

}
