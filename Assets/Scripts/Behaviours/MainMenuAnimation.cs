using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuAnimation : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    private void Awake()
    {
        Time.timeScale = 1;
        animator = GetComponent<Animator>();
        animator.SetBool("Menu", true);
    }
    private void Update()
    {


    }


}
