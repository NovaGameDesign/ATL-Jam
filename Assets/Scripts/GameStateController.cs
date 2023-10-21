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
    //public PlayerStats Player1, Player2;

    public GameObject[] fleetBlue, fleetRed;
    public GameObject WinPanel;

    // Use this for initialization
    void Awake()
    {
        UIM = FindObjectOfType<UserInterfaceManager>();

        if (SceneManager.GetActiveScene().name != "MainMenu")
        {
            //fleetBlue = Player1.GetComponent<PlayerStats>().fleet;
            //fleetRed = Player2.GetComponent<PlayerStats>().fleet;
        }


        // Starts Game at Main Menu
        //if (SceneManager.GetActiveScene().name == "MainMenu")
        //{
        //    // Do nothing
        //}
        //else
        //{
        //    LoadMainMenu();
        //}
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name != "MainMenu")
        {
            if (WinPanel.activeSelf == false)
            {
                //Win by Conquer
                if (fleetRed.Length == 0)
                {
                    Debug.Log("Player 1 Conquers");
                    LoadResults(1);
                }

                if (fleetBlue.Length == 0)
                {
                    Debug.Log("Player 2 Conquers");
                    LoadResults(2);
                }

                //Win by Conquest
                /*
                if (Player1.GetComponent<PlayerStats>().sectorsCaptured == 7)
                {
                    Debug.Log("Player 1 Conquests");
                    LoadResults(3);
                }

                if (Player2.GetComponent<PlayerStats>().sectorsCaptured == 7)
                {
                    Debug.Log("Player 2 Conquests");
                    LoadResults(4);
                }
                */
            }
        }
    }

    // Loads Main Menu
    public void LoadMainMenu()
    {
        Time.timeScale = 1; //Just in case quiting by pause
        SceneManager.LoadScene("MainMenu");
    }


    public void LoadResults(int winType)
    {
        WinPanel.SetActive(true);
        Time.timeScale = 0;
        Victory(winType);
    }

    //Win State Transition
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

    //Loads New Game
    public void LoadLevel()
    {
        switch (UIM.levelDecider)
        {
            case 1:
                SceneManager.LoadScene(UIM.levelDecider);
                break;

            case 2:
                SceneManager.LoadScene(UIM.levelDecider);
                break;

            case 3:
                SceneManager.LoadScene(UIM.levelDecider);
                break;
        }
    }

    // Shutdown Game Application
    public void CloseGame()
    {
        Application.Quit();
    }
}
