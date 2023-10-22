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
    private UserInterfaceManager UIM;
    //winPanel = UIM.victoryPanel;

    #region Awake Start Update
    // Use this for initialization
    void Awake()
    {
        Debug.Log("GSC | Awake()");

        UIM = FindObjectOfType<UserInterfaceManager>();

        Debug.Log("GSC | Current Scene = " + SceneManager.GetActiveScene().name);
        // Starts Game at Main Menu
        if (SceneManager.GetActiveScene().name != "Menu Scene")
        {
            // Upon starting game.EXE, updates UIM level index to Menu Scene
            UIM.Level1();
            // UIM level index for Menu Scene passes to LoadLevel
            LoadLevel();
            // Menu Scene should appear at start of game
            Debug.Log("GSC | Current Scene = " + SceneManager.GetActiveScene().name);
        }
    }

    //void Start()
    //{
    //    Debug.Log("GSC | Start()");
    //    UIM = FindObjectOfType<UserInterfaceManager>();

    //    Debug.Log("GSC | Current Scene = " + SceneManager.GetActiveScene().name);
    //    // Starts Game at Main Menu
    //    if (SceneManager.GetActiveScene().name != "Menu Scene")
    //    {
    //        // Upon starting game.EXE, updates UIM level index to Menu Scene
    //        UIM.Level1();
    //        // UIM level index for Menu Scene passes to LoadLevel
    //        LoadLevel();
    //        // Menu Scene should appear at start of game
    //        Debug.Log("GSC | Current Scene = " + SceneManager.GetActiveScene().name);
    //    }
    //}

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name != "Menu Scene")
        {
            Debug.Log("GSC | Update() - Not Menu Scene - Check Cursor State");
            if (Cursor.lockState != CursorLockMode.Locked && Cursor.visible != false)
            {
                // Disable Cursor Control and Visibility
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;

                Debug.Log("Cusor.lockState = " + Cursor.lockState.ToString());
                Debug.Log("Cusor.visibility = " + Cursor.visible.ToString());
            }

            if (UIM.victoryPanel.activeSelf == false)
            {
                // do nothing
            }
        }
        else
        {
            Debug.Log("GSC | Update() - Menu Scene - Check Cursor State");
            if (Cursor.lockState != CursorLockMode.None && Cursor.visible != true)
            {
                // Enable Cursor Control and Visibility
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;

                Debug.Log("Cusor.lockState = " + Cursor.lockState.ToString());
                Debug.Log("Cusor.visibility = " + Cursor.visible.ToString());
            }
        }
    }
    #endregion

    #region Mouse State Control

    private void CursorEnabled()
    {
        // Enable Cursor Control and Visibility
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void CursorDisabled()
    {
        // Enable Cursor Control and Visibility
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    #endregion

    // Loads Main Menu
    public void LoadMainMenu()
    {
        Debug.Log("GSC | LoadMainMenu()");
        Time.timeScale = 1.0f; //Just in case quiting by pause
        SceneManager.LoadScene("Menu Scene");
    }

    #region TestScores
    /// <summary>
    /// TestScores() - Press 1 of 3 Keys to Check if the Win/Lose Conditions work as expected.
    /// 
    /// Press 'PageUp' to increment score by 1.
    /// Press 'PageDown' to decrement score by 1.
    /// Press 'End' to set Player Health to 0.
    /// </summary>
    public void TestScores()
    {
        if (Input.GetKey(KeyCode.PageUp))
        {
            // Increment Score by 1
        }
        if (Input.GetKey(KeyCode.PageDown))
        {
            // Decrement Score by 1
        }
        if (Input.GetKey(KeyCode.End))
        {
            // Set Player Health to Zero
        }
    }
    #endregion

    /// <summary>
    /// LoadResults() - Updates the winType/score value to track game's progression. Reset the timeScale to zero.
    /// </summary>
    /// <param name="winType">
    /// Integer for Win Condition
    /// </param>
    public void LoadResults(int winType)
    {
        Debug.Log("GSC | LoadResults()");
        UIM.victoryPanel.SetActive(true);
        Time.timeScale = 0.0f;
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
        Debug.Log("GSC | Victory(" + wT + ")");
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
        Debug.Log("GSC | LoadLevel()");
        Debug.Log("GSC | UIM.levelDecider = " + UIM.levelIndex);
        switch (UIM.levelIndex)
        {
            case 1:
                // Menu Scene
                SceneManager.LoadScene(UIM.levelIndex);
                break;
            case 2:
                // Air Scene
                SceneManager.LoadScene(UIM.levelIndex);
                // Enable Cursor Control and Visibility
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                break;
            case 3:
                // Earth Scene
                SceneManager.LoadScene(UIM.levelIndex);
                // Enable Cursor Control and Visibility
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                break;
            case 4:
                // Fire Scene
                SceneManager.LoadScene(UIM.levelIndex);
                // Enable Cursor Control and Visibility
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                break;
            case 5:
                // Water Scene
                SceneManager.LoadScene(UIM.levelIndex);
                // Enable Cursor Control and Visibility
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                break;
            default:
                // Default Case loads the 'Test Scene'
                UIM.levelIndex = 0;
                SceneManager.LoadScene(UIM.levelIndex);
                // Enable Cursor Control and Visibility
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                break;
        }
    }

    #region Exit Game EXE
    /// <summary>
    /// CloseGame() | Purpose:
    /// Calls Application.Quit() to exit the game completely and terminate the process.
    /// </summary>
    public void CloseGame()
    {
        Debug.Log("GSC | CloseGame() - Check Built EXE for function success");
        Application.Quit();
    }
    #endregion
}
