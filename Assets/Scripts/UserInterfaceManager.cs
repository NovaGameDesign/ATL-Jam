using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// User Interface Manager
/// 
/// Created By: JarekQ Aloisio
/// 
/// This manager serves as the backend for the UI.
/// 
/// This was "copy/pasted" from JarekQ's capstone project.
/// 
/// Work in Progress
/// </summary>

public class UserInterfaceManager : MonoBehaviour
{
    public GameObject startPanel, pausePanel, instructionsPanel, optionsPanel, creditsPanel, quitPanel, levelsPanel;

    public GameObject title;
    public int levelDecider;

    public GameObject bluePanel, redPanel;
    //public Text redText, blueText;

    //public GameObject FadePanel;
    //public FadeTransition fade;

    public void Awake()
    {
        //FadePanel = GameObject.Find("FadePanel");
        //FadeTransition fade = FadePanel.GetComponent<FadeTransition>();
    }

    // Update is called once per frame
    public void Update()
    {
        if (SceneManager.GetActiveScene().name != "MainMenu")
        {
            if ((Input.GetKeyDown(KeyCode.Escape)) && (pausePanel.activeSelf == false))
            {
                PauseMenu();
            }

            else if ((Input.GetKeyDown(KeyCode.Escape)) && (pausePanel.activeSelf == true))
            {
                UnPauseMenu();
            }
        }
        TestScores();

    }

    public void BackToMainMenu()
    {
        if (instructionsPanel.activeSelf == true)
        {
            instructionsPanel.SetActive(false);
        }

        if (optionsPanel.activeSelf == true)
        {
            optionsPanel.SetActive(false);
        }

        if (creditsPanel.activeSelf == true)
        {
            creditsPanel.SetActive(false);
        }
        if (levelsPanel.activeSelf == true)
        {
            levelsPanel.SetActive(false);
        }

        // Enabling StartMenu to True
        startPanel.SetActive(true);

        title.SetActive(true);

        Debug.Log("Back Button clicked - Returned to MainMenu");
    }

    // Pause Game and Open Pause Menu
    public void PauseMenu()
    {
        if (pausePanel.activeSelf == false)
        {
            pausePanel.SetActive(true);

            Time.timeScale = 0.0f;
        }
        Debug.Log("GAMEMANAGER:: TimeScale: " + Time.timeScale);
    }

    // Resume Game and Close Pause Menu
    public void UnPauseMenu()
    {
        if (pausePanel.activeSelf == true)
        {
            pausePanel.SetActive(false);

            Time.timeScale = 1.0f;
        }
        Debug.Log("GAMEMANAGER:: TimeScale: " + Time.timeScale);
    }

    //This function can be used for both MainMenu and In-Game
    public void OpenInstructions()
    {
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            startPanel.SetActive(false);

            title.SetActive(false);

            instructionsPanel.SetActive(true);

            Debug.Log("I opend the instructions");
        }
        else
        {
            pausePanel.SetActive(false);

            instructionsPanel.SetActive(true);

            Debug.Log("I opened the OPTIONS");
        }

        instructionsPanel.SetActive(true);

        Debug.Log("I opend the instructions");

        Debug.Log("GAMEMANAGER:: TimeScale: " + Time.timeScale);
    }

    // This function can be used to close the Instructions menu In-Game
    public void CloseInstructions()
    {
        instructionsPanel.SetActive(false);

        Debug.Log("I closed the instructions");

        pausePanel.SetActive(true);

        Debug.Log("GAMEMANAGER:: TimeScale: " + Time.timeScale);
    }
    // This function can be used to go to any of our 3 levels in game
    public void OpenLevels()
    {
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            startPanel.SetActive(false);

            title.SetActive(false);

            levelsPanel.SetActive(true);

            Debug.Log("I opened the LEVELS");
        }
        else
        {
            pausePanel.SetActive(false);

            levelsPanel.SetActive(true);

            Debug.Log("I opened the LEVELS");
        }
        levelsPanel.SetActive(true);

        Debug.Log("I opened LEVELS");
    }
    // This function can be used in MainMenu and In-Game
    public void OpenOptions()
    {
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            startPanel.SetActive(false);

            title.SetActive(false);

            optionsPanel.SetActive(true);

            Debug.Log("I opened the OPTIONS");
        }


        pausePanel.SetActive(false);

        optionsPanel.SetActive(true);

        Debug.Log("I opened the OPTIONS");


        optionsPanel.SetActive(true);

        Debug.Log("I opened OPTIONS");
    }

    // This function can be used to close the Options menu In-Game
    public void CloseOptions()
    {
        optionsPanel.SetActive(false);

        Debug.Log("I closed OPTIONS");

        pausePanel.SetActive(true);

        Debug.Log("GAMEMANAGER:: TimeScale: " + Time.timeScale);
    }

    // This function can be used to view the Credits
    // It will show in MainMenu and after the Results page
    public void ViewCredits()
    {
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            startPanel.SetActive(false);

            title.SetActive(false);

            creditsPanel.SetActive(true);

            Debug.Log("I opend the CREDITS");
        }

    }

    //closes pause panel and brings up the quit panel, asking the player if they really want to quit
    public void ConfirmQuit()
    {
        pausePanel.SetActive(false);

        quitPanel.SetActive(true);

        Debug.Log("GAMEMANAGER:: TimeScale: " + Time.timeScale);
    }

    //quit panel will be closed, brings back up pause panel
    public void RefuseQuit()
    {
        quitPanel.SetActive(false);

        pausePanel.SetActive(true);

        Debug.Log("GAMEMANAGER:: TimeScale: " + Time.timeScale);
    }

    #region Level Decider

    // Follwoing methods handles selection of levels Based on Ints. Once level is clicked, the start button will appear with the scene number loaded in. 
    public void Level1()
    {
        levelDecider = 1;
        Debug.Log("You are currently going to level" + levelDecider);
    }

    public void Level2()
    {
        levelDecider = 2;
        Debug.Log("You are currently going to level" + levelDecider);
    }
    public void Level3()
    {
        levelDecider = 3;
        Debug.Log("You are currently going to level" + levelDecider);
    }

    #endregion

    #region Victory/Lose UI

    public void TestScores()
    {
        if (Input.GetKey(KeyCode.Keypad1))
        {
            //BlueConquer();
        }
        if (Input.GetKey(KeyCode.Keypad2))
        {
            //BlueConquest();
        }
        if (Input.GetKey(KeyCode.Keypad3))
        {
            //RedConquer();
        }
        if (Input.GetKey(KeyCode.Keypad4))
        {
            //RedConquest();
        }
    }

    /*
    public void BlueConquest()
    {
        blueText.text = "Victory by Conquest!!!";
        redText.text = "Defeat by Conquest...";
    }

    public void BlueConquer()
    {
        blueText.text = "Victory by Conquer!!!";
        redText.text = "Defeat by Conquer...";
    }

    public void RedConquest()
    {
        blueText.text = "Defeat by Conquest...";
        redText.text = "Victory by Conquest!!!";
    }

    public void RedConquer()
    {
        blueText.text = "Defeat by Conquer...";
        redText.text = "Victory by Conquer!!!";
    }
    

    //Call fading out
    public void Fade()
    {
        FadeTransition fade = FadePanel.GetComponent<FadeTransition>();

        if (levelDecider != 0)
            fade.fadingOut = true;
    }
    */
    #endregion

}
