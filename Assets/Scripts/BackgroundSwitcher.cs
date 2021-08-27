using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BackgroundSwitcher : MonoBehaviour
{
    public Sprite[] images;
    int index;
    // Start is called before the first frame update
    void Start()
    {
        index = 0;
        InvokeRepeating("ChangePic", 3, 3);
    }

    public void ChangePic()
    {

        index += 1;
        index = index % images.Length;
        GetComponent<Image>().sprite = images[index];
    }
}
