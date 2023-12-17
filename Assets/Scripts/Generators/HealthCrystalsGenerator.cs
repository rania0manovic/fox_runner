using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCrystalsGenerator : MonoBehaviour
{
    public PlatformGenerator platforms;
    public GameObject crystal1;
    public GameObject crystal2;
    int targetScore1;
    int targetScore2;

    // Start is called before the first frame update
    void Start()
    {
        targetScore1 = 500;
        targetScore2 = 100;
    }

    // Update is called once per frame
    void Update()
    {
        GenerateCrsytals();
        GenerateBadCrystals();
    }

    private void GenerateCrsytals()
    {
        if (platforms.Score > targetScore1)
        {
            var temp = Instantiate(crystal1);
            temp.transform.SetParent(platforms.platformsMade[2].transform, false);
            targetScore1 += 500;
        }
    }
    private void GenerateBadCrystals()
    {

        if (platforms.Score > targetScore2)
        {
            var temp = Instantiate(crystal2);
            temp.transform.SetParent(platforms.platformsMade[2].transform, false);
            targetScore2 += 300;
        }
    }
}
