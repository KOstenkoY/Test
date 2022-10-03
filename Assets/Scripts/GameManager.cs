using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class GameManager : Singleton<GameManager>
{
    public Level[] scenes;

    public GameObject player;
    public GameObject finish;

    [SerializeField] Vector3 startPosition;
    [SerializeField] Vector3 finishPosition;

    [SerializeField] Material baseColor;
    [SerializeField] Material changeColor;

    public GameObject diePrefab;

    private int number;

    public bool playerInvincible { get; set; }
    private float timeWithInvincible = 2.0f;

    private float delayBeforeRemoving = 1.0f;

    private Coroutine coroutine;

    Level _currentScene;
    GameObject _currentDiePref;

    public GameObject inGameUI;
    public GameObject pausedUI;
    public GameObject WinMenu;

    public GameObject dampingAnimation;


    void Awake() 
    {
        ShowMainMenu();

    }
    public void StartGame()
    {
        ShowUI(pausedUI);

        number = Random.Range(0, scenes.Length);

        _currentScene = Instantiate(scenes[number], Vector3.zero, this.transform.rotation);

        _currentScene.player = Instantiate(player, startPosition, this.transform.rotation);

        Instantiate(finish, finishPosition, this.transform.rotation);
        Time.timeScale = 0.0f;
    }
    void ShowUI(GameObject newUI)
    {
        GameObject[] allUI = { inGameUI, pausedUI, WinMenu };

        foreach (GameObject UIToHide in allUI)
        {
            UIToHide.SetActive(false);
        }

        newUI.SetActive(true);
    }

    void ShowMainMenu()
    {
        StartGame();
    }

    public void SetPaused(bool paused)
    {
        inGameUI.SetActive(!paused);
        pausedUI.SetActive(paused);
        
        if (paused)
        {
            dampingAnimation.SetActive(true);      //DoColor
            Time.timeScale = 0.0f;
        }
        else
        {
            Time.timeScale = 1.0f;
            dampingAnimation.SetActive(false);
        }
    }

    public void KillPlayer()
    {
        if(playerInvincible)
        {

        }
        else
        {
            Vector3 spawnPosition = _currentScene.player.transform.position;
            
            Quaternion currentRotation = player.transform.rotation;

            Destroy(_currentScene.player);

            _currentDiePref = Instantiate(diePrefab, spawnPosition, currentRotation);
            StartCoroutine(Die());
        }
    }

    public void NewGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Win()
    {
        Time.timeScale = 0.0f;
        dampingAnimation.SetActive(true);
        WinMenu.SetActive(true);
    }

    public void CreatePlayer()
    {
        _currentScene.player = Instantiate(player, startPosition, this.transform.rotation);
        _currentScene.player.transform.DOPath(_currentScene.path, 10f, PathType.Linear);

        Instantiate(finish, finishPosition, this.transform.rotation);
    }

    public void SetInvincible()
    {
        playerInvincible = true;
        _currentScene.player.GetComponentInChildren<MeshRenderer>().material = changeColor;
        coroutine = StartCoroutine(Invincible());
    }

    public void BreakInvincible()
    {
        if(coroutine == null)
        {
            return;
        }

        StopCoroutine(coroutine);

        playerInvincible = false;

        _currentScene.player.GetComponentInChildren<MeshRenderer>().material = baseColor;
    }

    IEnumerator Invincible()
    {
        yield return new WaitForSeconds(timeWithInvincible);
        playerInvincible = false;
    }

    IEnumerator Die()
    {
        yield return new WaitForSeconds(delayBeforeRemoving);
        Destroy(_currentDiePref);

        CreatePlayer();
    }

    public void Exit()
    {
        Application.Quit();
    }
}
