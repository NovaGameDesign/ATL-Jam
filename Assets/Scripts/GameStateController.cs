using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Transactions;
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
    private PlayerHealthManager PHM;
    //winPanel = UIM.victoryPanel;

    public bool airWin;
    public bool earthWin;
    public bool fireWin;
    public bool waterWin;

    public int currentScore, totalScore;
    
    #region Awake Start Update
    // Use this for initialization
    void Awake()
    {
        Debug.Log("GSC | Awake()");

        UIM = FindObjectOfType<UserInterfaceManager>();

        // Reset Win Conditions to New Game
        airWin = false;
        earthWin = false;
        fireWin = false;
        waterWin = false;
        // Reset Score to New Game
        currentScore = 0;
        totalScore = 4;
        
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
            CursorDisabled();

            if (UIM.victoryPanel.activeSelf == false)
            {
                // do nothing
            }
        }
        else
        {
            Debug.Log("GSC | Update() - Menu Scene - Check Cursor State");
            CursorEnabled();
        }
    }
    #endregion

    #region Mouse State Control
    /// <summary>
    /// CursorEnabled() - Sets visible to true and disables the lockState.
    /// </summary>
    private void CursorEnabled()
    {
        if (Cursor.lockState != CursorLockMode.None && Cursor.visible != true)
        {
            // Enable Cursor Control and Visibility
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            //Debug.Log("Cusor.lockState = " + Cursor.lockState.ToString());
            //Debug.Log("Cusor.visibility = " + Cursor.visible.ToString());
        }
        else
        {
            // Do nothing

            //Debug.Log("Cusor Already Enabled");
            //Debug.Log("Cusor.lockState = " + Cursor.lockState.ToString());
            //Debug.Log("Cusor.visibility = " + Cursor.visible.ToString());
        }
    }
    /// <summary>
    /// CursorEnabled() - Sets visible to false and enables the lockState.
    /// </summary>
    private void CursorDisabled()
    {
        if (Cursor.lockState != CursorLockMode.Locked && Cursor.visible != false)
        {
            // Disable Cursor Control and Visibility
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            //Debug.Log("Cusor.lockState = " + Cursor.lockState.ToString());
            //Debug.Log("Cusor.visibility = " + Cursor.visible.ToString());
        }
        else
        {
            // Do nothing

            //Debug.Log("Cusor Already Disabled");
            //Debug.Log("Cusor.lockState = " + Cursor.lockState.ToString());
            //Debug.Log("Cusor.visibility = " + Cursor.visible.ToString());
        }
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
            if(currentScore <= totalScore && currentScore >= 0)
            {
                // Increment Score by 1
                currentScore++;
                Debug.Log("GSC | currentScore = " + currentScore + " / totalScore = " + totalScore);
            }
            else
            {
                Debug.Log("GSC | currentScore = " + currentScore + " / totalScore = " + totalScore);
            }
        }
        if (Input.GetKey(KeyCode.PageDown))
        {
            if (currentScore <= totalScore && currentScore >= 0)
            {
                // Decrement Score by 1
                currentScore--;
                Debug.Log("GSC | currentScore = " + currentScore + " / totalScore = " + totalScore);
            }
            else
            {
                Debug.Log("GSC | currentScore = " + currentScore + " / totalScore = " + totalScore);
            }
        }
        if (Input.GetKey(KeyCode.End))
        {
            // Set Player Health to Zero
            PHM = FindObjectOfType<PlayerHealthManager>();
            PHM.TakeHit();
            Debug.Log("GSC | PHM._healthPoints = " + PHM.GetHealthPoints());
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
                // Air Win
                airWin = true;
                break;
            case 2:
                // Earth Win
                earthWin = true;
                break;
            case 3:
                // Fire Win
                fireWin = true;
                break;
            case 4:
                // Water Win
                waterWin = true;
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
                break;
            case 3:
                // Earth Scene
                SceneManager.LoadScene(UIM.levelIndex);
                break;
            case 4:
                // Fire Scene
                SceneManager.LoadScene(UIM.levelIndex);
                break;
            case 5:
                // Water Scene
                SceneManager.LoadScene(UIM.levelIndex);
                break;
            default:
                // Default Case loads the 'Test Scene'
                UIM.levelIndex = 0;
                SceneManager.LoadScene(UIM.levelIndex);
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
