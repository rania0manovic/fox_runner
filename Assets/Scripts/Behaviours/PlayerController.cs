using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Animator anim;
    private Vector3 Velocity;
    private Vector3 PlayerMovement;
    float JumpsFallingSpeed;

    public Camera Camera;
    public PlatformGenerator platforms;
    private CharacterController cc;
    private Vector3 VelocityCamera;

    private bool left;
    private bool right;
    private bool jump;

    public GameObject JumpAudio;
    public GameObject footsteps;
    public GameObject MoveAudio;

    public GameObject PauseMenu;
    public GameObject GameOverMenu;

    public bool CanDoAction()
    {
        if (PauseMenu.activeInHierarchy)
            return false;
        if (GameOverMenu.activeInHierarchy)
            return false;
        return true;
    }

    void Start()
    {
        anim = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
        cc = Camera.GetComponent<CharacterController>();
        left = right = false;
        anim.SetBool("Menu", false);
        JumpsFallingSpeed = 5;

    }

    // Update is called once per frame
    void Update()
    {
        if (CanDoAction())
        {
            CheckSpeed();
            PlayerMovement = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
            ///Debug.Log(controller.isGrounded.ToString());
            if (controller.isGrounded)
            {
                Velocity.y = -1;
                VelocityCamera.y = -1;
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Velocity.y = 1.2f;
                    VelocityCamera.y = 1.2f;
                    footsteps.GetComponent<AudioSource>().Pause();
                    JumpAudio.GetComponent<AudioSource>().Play();
                    footsteps.GetComponent<AudioSource>().Play();

                }
            }
            else
            {
                Velocity.y -= JumpsFallingSpeed * Time.deltaTime;
                VelocityCamera.y -= JumpsFallingSpeed * Time.deltaTime;

            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                controller.Move(PlayerMovement);
                MoveAudio.GetComponent<AudioSource>().Play();
                left = true;
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                controller.Move(PlayerMovement);
                MoveAudio.GetComponent<AudioSource>().Play();

                right = true;
            }

            else
            {
                left = right = jump = false;
            }

            controller.Move(Velocity);
            cc.Move(VelocityCamera);

            anim.SetBool("left", left);
            anim.SetBool("right", right);
            anim.SetBool("jump", jump);

        }

    }

    private void CheckSpeed()
    {
        if (platforms.Speed > 10)
            JumpsFallingSpeed = 6;
        else if (platforms.Speed > 20)
            JumpsFallingSpeed = 7;
        else if (platforms.Speed > 30)
            JumpsFallingSpeed = 8;
        else if (platforms.Speed > 40)
            JumpsFallingSpeed = 9;


    }
}
