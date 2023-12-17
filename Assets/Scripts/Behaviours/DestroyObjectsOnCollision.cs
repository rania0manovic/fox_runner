using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjectsOnCollision : MonoBehaviour
{
    public PlayerHealth player;
    public PlatformGenerator platforms;
    private float TempSpeed;
    private Animator anim;
    private bool hasEntered;
    public GameObject running;
    public GameObject HitReaction;
    public GameObject HitSound;



    void Start()
    {
        anim = player.GetComponent<Animator>();
        hasEntered = false;
    }

    void Update()
    {

    }

    private IEnumerator OnCollisionEnter(Collision collision)
    {
        if (gameObject.tag == "Crystal" && !hasEntered)
        {
            hasEntered = true;
            player.IncreaseHealth();
            HitSound.GetComponent<AudioSource>().Play();
        }
        else if (gameObject.tag == "BadCrystal" && !hasEntered)
        {
            hasEntered = true;
            player.DecreaseHealth();
            HitReaction.GetComponent<AudioSource>().Play();
        }
        else if (gameObject.tag == "Obstacle")
        {
            running.GetComponent<AudioSource>().Pause();
            HitSound.GetComponent<AudioSource>().Play();
            HitReaction.GetComponent<AudioSource>().Play();
            TempSpeed = platforms.Speed;
            platforms.Speed = 0;
            anim.SetBool("hit", true);
            yield return new WaitForSeconds(2);
            anim.SetBool("hit", false);
            platforms.Speed = TempSpeed;
            player.DecreaseHealth();
            running.GetComponent<AudioSource>().Play();
        }

        Destroy(gameObject);
        Debug.Log(player.health);
    }




}
