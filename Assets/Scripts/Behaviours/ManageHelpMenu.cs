using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageHelpMenu : MonoBehaviour
{
    public GameObject Buttons;
    public GameObject Help;
    public Animator anim;
    // Start is called before the first frame update


    public void HelpMenu()
    {

        Buttons.SetActive(false);
        Help.SetActive(true);
    }
    public void MainMenu()
    {
        anim.SetBool("Menu", true);
        Help.SetActive(false);
        Buttons.SetActive(true);
    }

}
