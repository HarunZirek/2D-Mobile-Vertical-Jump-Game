using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class LevelComplete : MonoBehaviour
{
    public Button pauseButton;
    public TextMeshProUGUI coinNumber;
    public GameObject loadingScreenUI;
    public Animator loadingScreen;
    public GameObject pauseMenuUI;

    private GameObject saveManager;
    private GameObject Mcamera;

    public Button reviveButton;
    public int reviveCount = 1;
    public GameObject savePoint;
    public static bool isPaused = false;
    public int LevelNumber;
    public int CoinCount = 0;
    public int BodyCount = 0;
    public bool isLevelComplete = false;
    public GameObject EndLevel;
    private GameObject player;
    private GameObject adManager;
    private Animator anim;
    private int Count = 1;
    private void Start()
    {
        Mcamera = GameObject.Find("Main Camera");
        adManager = GameObject.Find("AdManager");
        saveManager = GameObject.Find("GameSaveManager");
        player = GameObject.Find("Player");
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        coinNumber.text = "x" + saveManager.GetComponent<SaveController>().coins;
        if (savePoint.GetComponent<savePoint>().isSaved == false || reviveCount == 0)
        {
            reviveButton.interactable = false;
        }
        else if (savePoint.GetComponent<savePoint>().isSaved == true)
        {
           reviveButton.interactable = true;
        }
        if (player.GetComponent<Playables>().isDead ==true)
        {
            gameOver();
        }
        if (player.transform.position.y >= EndLevel.transform.position.y)
        {
           if(Count==1)
            {
                player.GetComponent<Playables>().levelDone();
                isLevelComplete = true;
                levelComplete();
                saveManager.GetComponent<SaveController>().levels[LevelNumber - 1] = true;
                saveManager.GetComponent<SaveController>().SaveGame();               
                pauseButton.interactable = false;
                Count--;
            }
        }
    }


    private void gameOver()
    {
        anim.SetBool("gameOver", true);
        pauseButton.interactable = false;
    }
    private void levelComplete()
    {
       
        anim.SetBool("levelComplete", true);
        pauseButton.interactable = false;
    }
    public void resume()
    {
        pauseMenuUI.SetActive(false);
        pauseButton.interactable = true;
        Time.timeScale = 1f;
        isPaused = false;
    }
    public void pause()
    {        
        pauseMenuUI.SetActive(true);
        pauseButton.interactable = false;
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void restart()
    {
        player.GetComponent<Playables>().levelDone();
        loadingScreenUI.SetActive(true);
        loadingScreen.SetTrigger("loadingScreen");
        StartCoroutine(LoadLevel((SceneManager.GetActiveScene().buildIndex)));
        Time.timeScale = 1f;
        isPaused = false;
    }
    public void levelSelect()
    {
        player.GetComponent<Playables>().levelDone();
        loadingScreenUI.SetActive(true);
        loadingScreen.SetTrigger("loadingScreen");
        StartCoroutine(LoadLevel(1));
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void nextLevel()
    {
        loadingScreenUI.SetActive(true);
        loadingScreen.SetTrigger("loadingScreen");
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
        Time.timeScale = 1f;
        isPaused = false;
    }
    IEnumerator LoadLevel(int index)
    {
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene(index);
    }

    IEnumerator reviveTime()
    {
        yield return new WaitForSeconds(1.5f);
        isPaused = false;
        Time.timeScale = 1f;
        player.GetComponent<Playables>().isPlaying = true;
        player.GetComponent<Playables>().canJump = true;
    }
    public void revive()
    {
        anim.SetBool("gameOver", false);
        reviveCount = 0;
        pauseButton.interactable = true;
        Mcamera.GetComponent<cameraController>().RestartPos();
        player.GetComponent<Playables>().isDead = false;
        player.transform.position = new Vector3(savePoint.transform.position.x, savePoint.transform.position.y, player.transform.position.z);
        Mcamera.GetComponent<cameraController>().RestartPos();
        StartCoroutine(reviveTime());
    }

    public void adForRevive()
    {
        adManager.GetComponent<adManager>().playReviveVideoAd();
    }
    
}

