using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collectable : MonoBehaviour
{
    public float speed = 10;
    bool toDestory = false;
    public GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        toDestory = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 45, 0) * speed * Time.deltaTime);
        if (toDestory)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            toDestory = true;
            gm.score += 1;
            gm.scoreText.text = "Score: " + gm.score.ToString();
        }
    }
}
