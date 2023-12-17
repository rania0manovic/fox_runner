using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    public GameObject PauseMenu;
    public GameObject footsteps;
    bool pause = false;
    // Start is called before the first frame update
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && pause == false)
        {
            Pause();
            pause = true;
        }
        else if (Input.GetKeyDown(KeyCode.Return) && pause == true)
        {
            Continue();
            pause = false;
        }
    }
    public void Pause()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0;
        footsteps.GetComponent<AudioSource>().Pause();
    }
    public void Continue()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1;
        footsteps.GetComponent<AudioSource>().Play();


    }
    public void GoToMainMenu()
    {
        Continue();
        SceneManager.LoadScene(0);

    }
    public void Exit()
    {
        Application.Quit();
    }
}
