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

    public GameObject biomeIcon1;
    public GameObject biomeIcon2;
    public GameObject mainTitle;
    public GameObject biomeSelect;
    public GameObject aboutPage;
    public GameObject pausePanel;
     
    public enum GameState
    {
       BEFORETITLE,
       TITLE,
       BIOMECHOOSE,
       GAME,
       MUSEUM,
       PAUSED,
       ABOUT,
       EXITGAME,
    }

    public void Start()
    {
        //world.GenerateWorld();

        if (currentState == GameState.GAME)
        {
            if (world != null) world.GenerateWorld();
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
                mainTitle.SetActive(true);
                aboutPage.SetActive(false);
                biomeSelect.SetActive(false);
                biomeIcon1.SetActive(false);
                break;

            case GameState.BIOMECHOOSE:
                biomeSelect.SetActive(true);
                mainTitle.SetActive(false);
                biomeIcon1.SetActive(true);
                //biomeIcon2.SetActive(true);
                break;
            case GameState.GAME:
                Time.timeScale = 1;
                //Cursor.lockState = CursorLockMode.Locked;
                break;
            case GameState.MUSEUM:
                break;
            case GameState.PAUSED:
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                Time.timeScale = 0;
                pausePanel.SetActive(true);
                break;
            case GameState.ABOUT:
                mainTitle.SetActive(false);
                aboutPage.SetActive(true);
                break;
            case GameState.EXITGAME:
                break;
            default:
                break;
        }
    }

    public void StartGameDesert()
    {
        StartGame("TerrainGenTest");
    }

    public void StartGameMountain()
    {
        StartGame("DesertGen");
    }

    public void StartGameExcavation()
    {
        StartGame("FirstPersonDigging");
    }

    public void StartGame(string sceneName)
    {
        currentState = GameState.GAME;
        SceneManager.LoadScene(sceneName);
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
        SceneManager.LoadScene("MainMenu");
        currentState = GameState.BEFORETITLE;

    }

    public void MainMenuOpen()
    {
        currentState = GameState.TITLE;
    }

    public void ReturnToGame()
    {
        currentState = GameState.GAME;
        pausePanel.SetActive(false);
    }

    public void ToMuseum()
    {
        currentState = GameState.MUSEUM;
        SceneManager.LoadScene("Museum");
    }

    public void PauseBackButton()
    {
        //Cursor.lockState = CursorLockMode.None;
        currentState = GameState.GAME;
        pausePanel.SetActive(false);
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
