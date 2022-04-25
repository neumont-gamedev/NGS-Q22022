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
        //i promise this makes sense -Salem
        TITLE = 0,
        PAUSED = 1,
        ABOUT = 2,
        BEFORETITLE, 
        BIOMECHOOSE,
        GAME,
        LAB,
        MUSEUM,
        EXITGAME,
    }

    public void Start()
    {
        //world.GenerateWorld();

        if (currentState == GameState.GAME)
        {
            if (world != null) world.GenerateWorld();
        }
        if (uiManager == null) uiManager = FindObjectOfType<UIManager>();
    }
    public void SpawnPlayer()
    {
        if(player != null)
        {
            return;
        }
        Vector3Int raycastStartPosition = new Vector3Int(world.chunkSize / 2, 100, world.chunkSize / 2);
        RaycastHit hit;
        if (Physics.Raycast(raycastStartPosition, Vector3.down, out hit, 120))
        {
            player = Instantiate(playerPrefab, hit.point + Vector3Int.up, Quaternion.identity);
            VRPlayer = player.transform.GetChild(0).transform.gameObject;
            StartCheckingTheMap();
        }
    }

    public void StartCheckingTheMap()
    {
        //SetCurrentChunkCoordinates();
        SetCurrentChunkCoordinatesVR();
        StopAllCoroutines();
        //StartCoroutine(CheckIfShouldLoadNextPosition());
        StartCoroutine(CheckIfShouldLoadNextPositionVR());
    }

/*    IEnumerator CheckIfShouldLoadNextPosition()
    {
        yield return new WaitForSeconds(detectionTime);
        if (
            Mathf.Abs(currentChunkCenter.x - player.transform.position.x) > world.chunkSize ||
            Mathf.Abs(currentChunkCenter.z - player.transform.position.z) > world.chunkSize ||
            (Mathf.Abs(currentPlayerChunkPosition.y - player.transform.position.y) > world.chunkHeight)
            )
        {
            world.LoadAdditionalChunksRequest(player);
        }
        else
        {
            StartCoroutine(CheckIfShouldLoadNextPosition());
        }
    }*/


    IEnumerator CheckIfShouldLoadNextPositionVR()
    {
        yield return new WaitForSeconds(detectionTime);
        Debug.Log("Start Check if Should Load Next Position VR");
        if (
            Mathf.Abs(currentChunkCenter.x - VRPlayer.transform.position.x) > world.chunkSize ||
            Mathf.Abs(currentChunkCenter.z - VRPlayer.transform.position.z) > world.chunkSize ||
            (Mathf.Abs(currentPlayerChunkPosition.y - VRPlayer.transform.position.y) > world.chunkHeight)
            )
        {
            Debug.Log("Check");
            world.LoadAdditionalChunksRequest(VRPlayer);
        }
        else
        {
            StartCoroutine(CheckIfShouldLoadNextPositionVR());
        }
    }

    private void SetCurrentChunkCoordinates()
    {
        currentPlayerChunkPosition = WorldDataHelper.ChunkPositionFromBlockCoords(world, Vector3Int.RoundToInt(player.transform.position));
        currentChunkCenter.x = currentPlayerChunkPosition.x + world.chunkSize / 2;
        currentChunkCenter.z = currentPlayerChunkPosition.z + world.chunkSize / 2;
    }

    private void SetCurrentChunkCoordinatesVR()
    {
        currentVRPlayerChunkPosition = WorldDataHelper.ChunkPositionFromBlockCoords(world, Vector3Int.RoundToInt(VRPlayer.transform.position));
        currentChunkCenter.x = currentPlayerChunkPosition.x + world.chunkSize / 2;
        currentChunkCenter.z = currentPlayerChunkPosition.z + world.chunkSize / 2;
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
            uiManager.InfoBook();
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
            case GameState.BIOMECHOOSE:
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
            case GameState.ABOUT:
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

    public void SelectBiome()
    {
        currentState = GameState.BIOMECHOOSE;
    }

    public void AboutPage()
    {
        if (currentState == GameState.ABOUT) return;
        for (int i=0; i < (int)GameState.EXITGAME; i++)
        {
            uiManager.DeactivatePanel((GameState)i);
        }

        uiManager.ActivatePanel(GameState.ABOUT);
        currentState = GameState.ABOUT;
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
        //Cursor.lockState = CursorLockMode.None;
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
