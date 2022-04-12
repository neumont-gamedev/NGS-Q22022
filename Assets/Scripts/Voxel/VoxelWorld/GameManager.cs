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

    public static GameState currentState = GameState.TITLE;

    public Camera gameCamera;

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
            world.GenerateWorld();
        }
        
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

        switch (currentState)
        {
            case GameState.BEFORETITLE:
                currentState = GameState.TITLE;
                break;
            case GameState.TITLE:
                Time.timeScale = 1;
                uiManager.Menu(GameState.TITLE);
                break;
            case GameState.BIOMECHOOSE:
                break;
            case GameState.GAME:
                Time.timeScale = 1;
                //Cursor.lockState = CursorLockMode.Locked;
                break;
            case GameState.LAB:
                break;
            case GameState.MUSEUM:
                break;
            case GameState.PAUSED:
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                Time.timeScale = 0;
                uiManager.Menu(GameState.PAUSED);
                break;
            case GameState.ABOUT:
                uiManager.Menu(GameState.ABOUT);
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
        currentState = GameState.ABOUT;
    }

    public void BackButton()
    {
        currentState = GameState.TITLE;
    }

    public void OnPause()
    {
        currentState = GameState.PAUSED;
    }

    public void ReturnToTitle()
    {
        currentState = GameState.BEFORETITLE;
        uiManager.LoadMuseum();
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
}
