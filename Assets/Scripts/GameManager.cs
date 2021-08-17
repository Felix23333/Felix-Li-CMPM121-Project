using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int score;
    public Text scoreText;
    public GameObject door1;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(FindObjectsOfType<EnemyController>().Length == 0)
        {
            door1.SetActive(false);
        }
        //TODO: Implement new score system
        //scoreText.text = "Score: " + score.ToString();
    }
}
