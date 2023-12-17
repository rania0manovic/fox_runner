using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlatformGenerator : MonoBehaviour
{

    public Camera Camera;
    public float Speed = 6.0f;
    public int nPlatform = 5;
    public Platform[] platform;
    public List<Platform> platformsMade = new List<Platform>();
    List<GameObject> obstacles;
    public decimal Score = 0;
    int targtScore = 50;
    public Text ScoreText;
    Vector3 distance;

    public static PlatformGenerator instance;

    void Start()
    {
        obstacles = new List<GameObject>(platform[0].obstacles);
        InstantiatePlatforms();
        Time.timeScale = 1;
    }

    private void InstantiatePlatforms()
    {
        instance = this;
        Vector3 position = Vector3.zero;
        var rand = new System.Random();
        var ra = new System.Random();
        var randomPlatform = 0;
        distance = platform[0].start.localPosition - platform[0].end.localPosition;
        position -= distance;
        Platform start = Instantiate(platform[0], position, Quaternion.identity);
        start.transform.SetParent(transform);
        platformsMade.Add(start);
        for (int i = 1; i < nPlatform; i++)
        {
            var previous = randomPlatform;
            randomPlatform = rand.Next(0, platform.Length);
            if (previous == 0 && randomPlatform == 1)
                distance = (platform[0].start.localPosition - platform[0].end.localPosition) + new Vector3(0, 0, 15);
            else if (previous == 1 && randomPlatform == 0)
                distance = platform[1].start.localPosition - platform[1].end.localPosition - new Vector3(0, 0, 15);
            else if (previous == 1 && randomPlatform == 1)
                distance = platform[1].start.localPosition - platform[1].end.localPosition + new Vector3(0, 0, 2);

            else
                distance = platform[randomPlatform].start.localPosition - platform[randomPlatform].end.localPosition;

            position -= distance;
            Platform Temp = Instantiate(platform[randomPlatform], position, Quaternion.identity) as Platform;
            Temp.transform.SetParent(transform);
            if (i >= 1 && randomPlatform == 0)
            {
                var n = ra.Next(0, obstacles.Count);
                var obstacle1 = Instantiate(obstacles[n]);
                if (n == obstacles.Count - 1)
                    n = -1;
                var obstacle2 = Instantiate(obstacles[n + 1]);
                obstacle1.transform.SetParent(Temp.transform, false);
                obstacle2.transform.SetParent(Temp.transform, false);
            }
            platformsMade.Add(Temp);
            ScoreText.text = "Score: " + Score;
        }
    }


    void Update()
    {

        HandleScore();
        HandlePlatforms();


    }

    private void HandleScore()
    {
        Score += Math.Round((decimal)(Time.deltaTime * Speed), 2);
        ScoreText.text = "Score: " + Score;
        if (Score > targtScore)
        {
            Speed += 1f;
            if (Score < 1000)
                targtScore += 100;
            else if (Score < 3000)
                targtScore += 250;
            else
                targtScore += 500;
        }
    }
    private void HandlePlatforms()
    {

        //moves the platforms
        foreach (var platform in platformsMade)
        {
            platform.transform.Translate(Speed * Time.deltaTime * -platform.transform.forward, Space.World);
        }

        if (platformsMade[0].transform.position.z < 0)
        {
            Destroy(transform.GetChild(0).gameObject);
            platformsMade.RemoveAt(0);
            var rand = new System.Random();
            var randomPlatform = rand.Next(0, platform.Length);

            if (platformsMade[platformsMade.Count - 1].gameObject.tag == "PlatformBridge" && randomPlatform == 1)
                distance = (platform[0].start.localPosition - platform[0].end.localPosition) + new Vector3(0, 0, 15);

            else if (platformsMade[platformsMade.Count - 1].gameObject.tag == "ShortPlatform" && randomPlatform == 0)
                distance = platform[1].start.localPosition - platform[1].end.localPosition - new Vector3(0, 0, 15);

            else if (platformsMade[platformsMade.Count - 1].gameObject.tag == "ShortPlatform" && randomPlatform == 1)
                distance = platform[1].start.localPosition - platform[1].end.localPosition + new Vector3(0, 0, 2);

            else
                distance = platform[randomPlatform].start.localPosition - platform[randomPlatform].end.localPosition;

            //distance = temp.start.localPosition - temp.end.localPosition;
            var temp1 = Instantiate(platform[randomPlatform], platformsMade[platformsMade.Count - 1].transform.position - distance, Quaternion.identity);
            temp1.transform.SetParent(transform, false);
            if (temp1.gameObject.tag == "PlatformBridge")
            {
                //FindObstacleToDdestroy(temp);
                var random = new System.Random();
                var n = random.Next(0, obstacles.Count);
                var obstacle1 = Instantiate(obstacles[n]);
                if (n == obstacles.Count - 1)
                    n = -1;
                var obstacle2 = Instantiate(obstacles[n + 1]);
                obstacle1.transform.SetParent(temp1.transform, false);
                obstacle2.transform.SetParent(temp1.transform, false);
            }

            platformsMade.Add(temp1);
        }
    }

    private Transform FindObstacleToDdestroy(Platform temp)
    {
        foreach (Transform T in temp.transform)
        {
            if (T.tag == "Obstacle" || T.tag == "Crystal" || T.tag == "BadCrystal")
                Destroy(T.gameObject);
        }
        return null;
    }
}
