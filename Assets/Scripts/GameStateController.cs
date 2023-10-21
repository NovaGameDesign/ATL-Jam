using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Game State Controller
/// 
/// Created By: JarekQ Aloisio
/// 
/// This controller serves as the backend for the game.
/// 
/// This was "copy/pasted" from JarekQ's capstone project.
/// 
/// Work in Progress
/// </summary>

public class GameStateController : MonoBehaviour
{
    UserInterfaceManager UIM;

    public GameObject WinPanel;

    // Use this for initialization
    void Awake()
    {
        UIM = FindObjectOfType<UserInterfaceManager>();

        // Starts Game at Main Menu
        if (SceneManager.GetActiveScene().name == "Menu Scene")
        {
            // Do nothing
        }
        else if (SceneManager.GetActiveScene().name != "Menu Scene")
        {
            // do nothing
            LoadMainMenu();
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name != "Menu Scene")
        {
            if (WinPanel.activeSelf == false)
            {
                // do nothing
            }
        }
    }

    // Loads Main Menu
    public void LoadMainMenu()
    {
        Time.timeScale = 1; //Just in case quiting by pause
        SceneManager.LoadScene("Menu Scene");
    }


    public void LoadResults(int winType)
    {
        WinPanel.SetActive(true);
        Time.timeScale = 0;
        Victory(winType);
    }

    /// <summary>
    /// Victory(int winType) | Purpose:
    /// Switch statement for opening the WinPanel to present
    /// various Victory states of the game in the UserInterfaceManager.
    /// </summary>
    /// <param name="wT">Interger WinType</param>
    public void Victory(int wT)
    {
        switch (wT)
        {
            case 1:
                // Blue Conquer
                //UIM.BlueConquer();
                break;
            case 2:
                // Red Conquer
                //UIM.RedConquer();
                break;
            case 3:
                // Blue Conquest
                //UIM.BlueConquest();
                break;
            case 4:
                // Red Conquest
                //UIM.RedConquest();
                break;
            default:
                // Check winType
                Debug.Log("Win Type = " + wT);
                break;
        }
    }

    /// <summary>
    /// LoadLevel() | Purpose:
    /// Switcth statement that uses the UIM.levelDecider to
    /// select the target scene to call SceneManager.LoadScene()
    /// </summary>
    public void LoadLevel()
    {
        switch (UIM.levelDecider)
        {
            case 1:
                // Menu Scene
                SceneManager.LoadScene(UIM.levelDecider);
                break;
            case 2:
                // Air Scene
                SceneManager.LoadScene(UIM.levelDecider);
                break;
            case 3:
                // Earth Scene
                SceneManager.LoadScene(UIM.levelDecider);
                break;
            case 4:
                // Fire Scene
                SceneManager.LoadScene(UIM.levelDecider);
                break;
            case 5:
                // Water Scene
                SceneManager.LoadScene(UIM.levelDecider);
                break;
            default:
                // Default Case loads the 'Test Scene'
                UIM.levelDecider = 0;
                SceneManager.LoadScene(UIM.levelDecider);
                break;
        }
    }

    /// <summary>
    /// CloseGame() | Purpose:
    /// Calls Application.Quit() to exit the game completely and terminate the process.
    /// </summary>
    public void CloseGame()
    {
        Application.Quit();
    }
}
