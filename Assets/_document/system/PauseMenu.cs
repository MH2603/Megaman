using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public bool GameIsPause = false;

    public GameObject PauseMenuUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (GameIsPause) Resume();
            else Pause();
        }

        if (GameIsPause)
        {
            if (Input.GetKeyDown(KeyCode.R)) LoadMenu();
            if (Input.GetKeyDown(KeyCode.Q)) QuitGame();
        }

       
    }



    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPause = false;
    }


    void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPause = true;

        
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("game");
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        Application.Quit(); 
    }

}
