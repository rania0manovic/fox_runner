using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetHealth : MonoBehaviour
{
    public PlayerHealth player;
    // Start is called before the first frame update
    void Start()
    {
        player.health = 2;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
