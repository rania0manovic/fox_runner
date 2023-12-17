using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class DisplayHighestScore : MonoBehaviour
{
    float highestScore;
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.HasKey("HighestScore"))
            text.text = "HIGHEST SCORE: " + PlayerPrefs.GetFloat("HighestScore"); ;

    }
}
