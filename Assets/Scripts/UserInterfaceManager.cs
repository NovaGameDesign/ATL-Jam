using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

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
        optionsPanel, creditsPanel, quitPanel, levelsPanel, gamePanel, victoryPanel;

    public TMP_Text healthText, scoreText, victoryText;

    public int levelIndex;
    private Unity.Mathematics.Random random;

    public Transform centerPoint;
    public Transform edgePoint;
    public Transform camera;
    public Transform cameraRotatePoint;
    public float spinTime;
    public Transform[] worldWaypoints;
    List<int> completedLevelIndexes;

    bool spinning = false;

    #region Awake Start Update

    public void Awake()
    {
        camera.LookAt(centerPoint);
        completedLevelIndexes = new List<int>();

        //if (SceneManager.GetActiveScene().buildIndex == 1)
        //{
        //    PlayerPrefs.SetInt("AirWin", 0);
        //    PlayerPrefs.SetInt("EarthWin", 0);
        //    PlayerPrefs.SetInt("FireWin", 0);
        //    PlayerPrefs.SetInt("WaterWin", 0);
        //}
    }

    public void Start()
    {
        
    }

    // Update is called once per frame
    public void Update()
    {
        if(PlayerPrefs.GetInt("AirWin") == 1 && !completedLevelIndexes.Contains(2))
        {
            completedLevelIndexes.Add(2);
        }
        if (PlayerPrefs.GetInt("EarthWin") == 1 && !completedLevelIndexes.Contains(3))
        {
            completedLevelIndexes.Add(3);
        }
        if (PlayerPrefs.GetInt("FireWin") == 1 && !completedLevelIndexes.Contains(4))
        {
            completedLevelIndexes.Add(4);
        }
        if (PlayerPrefs.GetInt("WaterWin") == 1 && !completedLevelIndexes.Contains(5))
        {
            completedLevelIndexes.Add(5);
        }


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

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            StartCoroutine(SelectWorld());
        }


        if (spinning)
        {
            camera.position = cameraRotatePoint.position;
            centerPoint.Rotate(0, 1f, 0, Space.Self);
            camera.LookAt(edgePoint);
        }
    }

    #endregion

    IEnumerator SelectWorld()
    {
        spinning = true;
        yield return new WaitForSeconds(spinTime);

        do
        {
            levelIndex = UnityEngine.Random.Range(2, 6);
            if (levelIndex < 2)
            {
                levelIndex = 2;
            }
            if (levelIndex > 5)
            {
                levelIndex = 5;
            }
        } while (completedLevelIndexes.Contains(levelIndex));

        Debug.Log("UIM | levelDecide = " + levelIndex);
        spinning = false;
        camera.LookAt(worldWaypoints[levelIndex - 2]);
        yield return new WaitForSeconds(5f);

        FindObjectOfType<GameStateController>().LoadLevel(levelIndex);
    }

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

        Debug.Log("Back Button clicked - Returned to MainMenu");
    }

    public void BackToMainMenuFromLevel()
    {
        Level1();
        new WaitForSeconds(.5f);
        startPanel.SetActive(false);
        levelsPanel.SetActive(true);

        Debug.Log("UIM - BackToMainMenuFromLevel");
    }
    #endregion

    #region GameUI

    public void EnableGameUI()
    {
        gamePanel.SetActive(true);
    }

    public void DisableGameUI()
    {
        gamePanel.SetActive(true);
    }

    public void setHealthText(string text)
    {
        healthText.text = text;
    }

    public void setScoreText(string text)
    {
        scoreText.text = text;
    }

    #endregion

    #region Victory

    public void EnableVictoryUI()
    {
        victoryPanel.SetActive(true);
    }

    public void DisableVictoryUI()
    {
        victoryPanel.SetActive(true);
    }

    public void SetVictoryText(string text)
    {
        victoryText.text = text;
    }

    #endregion

    #region Pause
    // Pause Game and Open Pause Menu
    public void PauseMenu()
    {
        if (pausePanel.activeSelf == false)
        {
            pausePanel.SetActive(true);
            gamePanel.SetActive(false);
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
            gamePanel.SetActive(true);
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

        Debug.Log("UIM | TimeScale = " + Time.timeScale);
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
            creditsPanel.SetActive(true);

            Debug.Log("UIM | startPanel *string* = " + startPanel.activeSelf.ToString());
            Debug.Log("UIM | startPanel *bool* = " + startPanel.activeSelf);
        }

    }
    #endregion

    #region Quit
    // Closes pause panel and brings up the quit panel, asking the player if they really want to quit
    public void ConfirmQuit()
    {
        pausePanel.SetActive(false);

        quitPanel.SetActive(true);

        Debug.Log("UIM | TimeScale = " + Time.timeScale);
    }

    //quit panel will be closed, brings back up pause panel
    public void RefuseQuit()
    {
        quitPanel.SetActive(false);

        pausePanel.SetActive(true);

        Debug.Log("UIM | TimeScale = " + Time.timeScale);
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
            levelsPanel.SetActive(true);

            Debug.Log("UIM | startPanel = " + startPanel.activeSelf);
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

    public void SpinLevels()
    {
        levelsPanel.SetActive(false);
        StartCoroutine(SelectWorld());
    }

    /// <summary>
    /// RandomLevel() - Randomly select level and SPIN IT.
    /// 
    /// Spin the rotation gradually and stop on the selected level, then use GSC to change to the level.
    /// 
    /// 
    /// NOTES from Lynx:
    /// Use Transform.RotateAround() for the Camera to look an empty object at the center of the terrain
    /// </summary>
    //public void RandomLevel()
    //{
    //    levelIndex = random.NextInt(2, 5);

    //    Debug.Log("UIM | levelDecide = " + levelIndex);
    //    FindObjectOfType<GameStateController>().LoadLevel();
    //}

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
        Debug.Log("UIM | Level1() - levelDecide = " + levelIndex);
        //FindObjectOfType<GameStateController>().LoadLevel();
    }
    public void Level2()
    {
        levelIndex = 2;
        Debug.Log("UIM | Level2() - levelDecide = " + levelIndex);
        //FindObjectOfType<GameStateController>().LoadLevel();
    }
    public void Level3()
    {
        levelIndex = 3;
        Debug.Log("UIM | Level3() - levelDecide = " + levelIndex);
        //FindObjectOfType<GameStateController>().LoadLevel();
    }
    public void Level4()
    {
        levelIndex = 4;
        Debug.Log("UIM | Level4() - levelDecide = " + levelIndex);
        //FindObjectOfType<GameStateController>().LoadLevel();
    }
    public void Level5()
    {
        levelIndex = 5;
        Debug.Log("UIM | Level5() - levelDecide = " + levelIndex);
        //FindObjectOfType<GameStateController>().LoadLevel();
    }
    #endregion

    #endregion

}
