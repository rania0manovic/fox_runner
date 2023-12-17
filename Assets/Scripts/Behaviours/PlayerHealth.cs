using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    private CharacterController controller;
    public PlatformGenerator platforms;
    public GameObject PauseButton;
    public GameObject GameOverMenu;
    Animator anim;
    public int health;
    public Text Score;
    public Text Lives;
    public GameObject footsteps;



    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        health = 2;
        DisplayLives();

    }
    public void DecreaseHealth()
    {
        health--;
        DisplayLives();
    }
    public void IncreaseHealth()
    {
        health++;
        DisplayLives();

    }

    public void DisplayLives()
    {
        Lives.text = "Lives left: " + health;
    }


    private void Update()
    {
        IsDead();
    }


    private void IsDead()
    {
        if (health <= 0 || IsFalling())
        {
            footsteps.GetComponent<AudioSource>().Pause();
            Time.timeScale = 0;
            PauseButton.SetActive(false);
            GameOverMenu.SetActive(true);
        }
    }
    private bool IsFalling()
    {
        if (controller.gameObject.transform.localPosition.y <= 0 || controller.gameObject.transform.localPosition.z <= 20)
        {
            health = 0;
            return true;
        }
        return false;
    }


}
