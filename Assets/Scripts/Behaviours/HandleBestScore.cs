using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleBestScore : MonoBehaviour
{
    float HighestScore;
    public PlatformGenerator platforms;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if ((float)platforms.Score > PlayerPrefs.GetFloat("HighestScore"))
        {
            HighestScore = (float)platforms.Score;
            PlayerPrefs.SetFloat("HighestScore", HighestScore);
            PlayerPrefs.Save();
        }
    }
}
