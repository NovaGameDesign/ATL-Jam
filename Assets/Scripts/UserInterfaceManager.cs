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
    public GameObject startPanel, pausePanel, instructionsPanel,
        optionsPanel, creditsPanel, quitPanel, levelsPanel, inGamePanel;

    public GameObject title;
    public int levelIndex;

    #region Awake Start Update

    public void Awake()
    {
        
    }

    public void Start()
    {
        
    }

    // Update is called once per frame
    public void Update()
    {
        if (SceneManager.GetActiveScene().name != "Menu Scene")
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

    #endregion

    #region MainMenu

    public void BackToMainMenu()
    {
        if (instructionsPanel.activeSelf == true)
        {
            instructionsPanel.SetActive(false);
        }

        //if (optionsPanel.activeSelf == true)
        //{
        //    optionsPanel.SetActive(false);
        //}

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
    #endregion

    #region Pause
    // Pause Game and Open Pause Menu
    public void PauseMenu()
    {
        if (pausePanel.activeSelf == false)
        {
            pausePanel.SetActive(true);
            inGamePanel.SetActive(false);
            Time.timeScale = 0.0f;
        }
        Debug.Log("UIM | TimeScale = " + Time.timeScale);
    }

    // Resume Game and Close Pause Menu
    public void UnPauseMenu()
    {
        if (pausePanel.activeSelf == true)
        {
            pausePanel.SetActive(false);
            inGamePanel.SetActive(true);
            Time.timeScale = 1.0f;
        }
        Debug.Log("UIM | TimeScale = " + Time.timeScale);
    }

    #endregion

    #region Instructions
    //This function can be used for both MainMenu and In-Game
    public void OpenInstructions()
    {
        if (SceneManager.GetActiveScene().name == "Menu Scene")
        {
            startPanel.SetActive(false);

            title.SetActive(false);

            instructionsPanel.SetActive(true);

            Debug.Log("I opened the instructions");
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

    #endregion

    #region Options

    // This function can be used in MainMenu and In-Game
    public void OpenOptions()
    {
        if (SceneManager.GetActiveScene().name == "Menu Scene")
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

    #endregion

    #region Credits
    // This function can be used to view the Credits
    // It will show in MainMenu and after the Results page
    public void ViewCredits()
    {
        if (SceneManager.GetActiveScene().name == "Menu Scene")
        {
            startPanel.SetActive(false);

            title.SetActive(false);

            creditsPanel.SetActive(true);

            Debug.Log("I opend the CREDITS");
        }

    }
    #endregion

    #region Quit
    // Closes pause panel and brings up the quit panel, asking the player if they really want to quit
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

    #endregion

    #region Level Selection
    /// <summary>
    /// Level Selection
    /// 
    /// OpenLevels() - UI Enable/Disable
    /// 
    /// OnClick() Methods for UIM - levelIndex Modifiers
    /// </summary>
    public void OpenLevels()
    {
        if (SceneManager.GetActiveScene().name == "Menu Scene")
        {
            startPanel.SetActive(false);
            title.SetActive(false);
            levelsPanel.SetActive(true);

            Debug.Log("UIM | startPanel = " + startPanel.activeSelf);
            Debug.Log("UIM | title = " + title.activeSelf);
            Debug.Log("UIM | levelsPanel = " + levelsPanel.activeSelf);
        }
        else
        {
            pausePanel.SetActive(false);
            levelsPanel.SetActive(true);

            Debug.Log("UIM | pausePanel = " + pausePanel.activeSelf);
            Debug.Log("UIM | levelsPanel = " + levelsPanel.activeSelf);
        }
        levelsPanel.SetActive(true);

        Debug.Log("UIM | levelsPanel = " + levelsPanel.activeSelf);
    }

    /// <summary>
    /// OnClick() Methods for UIM
    /// 
    /// UI Buttons in Canvas will be set to select a given level.
    /// Each Level#() function assigns the levelIndex to a value.
    /// Then, it locates the local GSC object and calls LoadLevel().
    /// </summary>
    #region OnClick() Methods for UIM
    public void Level1()
    {
        levelIndex = 1;
        Debug.Log("UIM | levelDecide = " + levelIndex);
        FindObjectOfType<GameStateController>().LoadLevel();
    }
    public void Level2()
    {
        levelIndex = 2;
        Debug.Log("UIM | levelDecide = " + levelIndex);
        FindObjectOfType<GameStateController>().LoadLevel();
    }
    public void Level3()
    {
        levelIndex = 3;
        Debug.Log("UIM | levelDecide = " + levelIndex);
        FindObjectOfType<GameStateController>().LoadLevel();
    }
    public void Level4()
    {
        levelIndex = 4;
        Debug.Log("UIM | levelDecide = " + levelIndex);
        FindObjectOfType<GameStateController>().LoadLevel();
    }
    public void Level5()
    {
        levelIndex = 5;
        Debug.Log("UIM | levelDecide = " + levelIndex);
        FindObjectOfType<GameStateController>().LoadLevel();
    }
    #endregion

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
