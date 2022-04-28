using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject playerPrefab;
    private GameObject player;
    public GameObject VRPlayer;
    public Vector3Int currentPlayerChunkPosition;
    public Vector3Int currentVRPlayerChunkPosition;
    private Vector3Int currentChunkCenter = Vector3Int.zero;

    public World world;

    float detectionTime = 1;
    public Camera mainCam;

    public UIManager uiManager;

    public GameState currentState = GameState.BEFORETITLE;

    public Camera gameCamera;

    private int scene = 0;

    public enum GameState
    { 
        TITLE,
        PAUSED,
        CREDITS,
        BEFORETITLE, 
        GAME,
        LAB,
        MUSEUM,
        EXITGAME
    }

    public void Start()
    {
        if (uiManager == null) uiManager = FindObjectOfType<UIManager>();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            OnPause();
        }

        if (Input.GetButtonDown("Button.Two"))
        {
            //open informational book if not open
            //put away book if open
            //uiManager.InfoBook();
        }

        switch (currentState)
        {
            case GameState.BEFORETITLE:
                scene = SceneManager.GetActiveScene().buildIndex;

                switch (scene)
                {
                    case 0: //TPMuseum
                        currentState = GameState.TITLE;
                        break;
                    case 1: //FirstPersonDigging (Excavation)
                        currentState = GameState.GAME;
                        break;
                    case 2: //CleaningTest
                        currentState = GameState.LAB;
                        break;
                    default:
                        break;
                }
                break;
            case GameState.TITLE:
                Time.timeScale = 1;
                //uiManager.Menu(GameState.TITLE);
                break;
            case GameState.GAME:
                Time.timeScale = 1;
                //Cursor.lockState = CursorLockMode.Locked;
                break;
            case GameState.LAB:
                Time.timeScale = 1;
                //Cursor.lockState = CursorLockMode.Locked;
                break;
            case GameState.MUSEUM:
                break;
            case GameState.PAUSED:
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                Time.timeScale = 0;
                //uiManager.Menu(GameState.PAUSED);
                break;
            case GameState.CREDITS:
                //uiManager.Menu(GameState.ABOUT);
                break;
            case GameState.EXITGAME:
                break;
            default:
                break;
        }
    }

    public void StartGameMuseum()
    {
        StartGame(0);
    }

    public void StartGameExcavation()
    {
        StartGame(1);
    }

    public void StartGameLab()
    {
        StartGame(2);
    }

    public void StartGame(int sceneIndex)
    {
        switch (sceneIndex)
        {
            case 0:
                currentState = GameState.MUSEUM;
                uiManager.LoadMuseum();
                break;
            case 1:
                currentState = GameState.GAME;
                uiManager.LoadExcavation();
                break;
            case 2:
                currentState = GameState.LAB;
                uiManager.LoadLab();
                break;
            default:
                break;
        }
    }

    public void CreditsPage()
    {
        if (currentState == GameState.CREDITS) return;
        for (int i=0; i < (int)GameState.EXITGAME; i++)
        {
            uiManager.DeactivatePanel((GameState)i);
        }

        uiManager.ActivatePanel(GameState.CREDITS);
        currentState = GameState.CREDITS;
    }

    public void BackButton()
    {
        if (currentState == GameState.TITLE) return;
        for (int i = 0; i < (int)GameState.EXITGAME; i++)
        {
            uiManager.DeactivatePanel((GameState)i);
        }

        uiManager.ActivatePanel(GameState.TITLE);
        currentState = GameState.TITLE;
    }

    public void OnPause()
    {
        if (currentState == GameState.PAUSED) return;
        for (int i = 0; i < (int)GameState.EXITGAME; i++)
        {
            uiManager.DeactivatePanel((GameState)i);
        }

        uiManager.ActivatePanel(GameState.PAUSED);
        currentState = GameState.PAUSED;
    }

    public void ReturnToTitle()
    {
        if (currentState == GameState.TITLE) return;
        for (int i = 0; i < (int)GameState.EXITGAME; i++)
        {
            uiManager.DeactivatePanel((GameState)i);
        }

        uiManager.ActivatePanel(GameState.TITLE);
        currentState = GameState.TITLE;
    }

    public void MainMenuOpen()
    {
        currentState = GameState.TITLE;
    }

    public void ReturnToGame()
    {
        currentState = GameState.GAME;
        uiManager.Menu(GameState.PAUSED);
    }

    public void ToMuseum()
    {
        currentState = GameState.MUSEUM;
        uiManager.LoadMuseum();
    }

    public void PauseBackButton()
    {
        currentState = GameState.GAME;
        uiManager.Menu(GameState.PAUSED);
    }

    public void OnQuit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
