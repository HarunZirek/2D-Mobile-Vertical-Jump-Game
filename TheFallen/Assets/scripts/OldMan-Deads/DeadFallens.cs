using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class DeadFallens : MonoBehaviour
{
    private GameObject saveManager;
    public int Number;
    public bool isTalking = false;
    public GameObject textButton;
    public GameObject textArea;
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    public int index;
    private GameObject player;
    public GameObject endGame;
    public float typingSpeed;
    public GameObject continueButton;

    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
        saveManager = GameObject.Find("GameSaveManager");
        player = GameObject.Find("Player");
    }


    void Update()
    {
        if(player.GetComponent<Playables>().isDead==true)
        {
            textArea.SetActive(false);
        }
        if (isTalking == true)
        {
            textButton.SetActive(false);
            if (textDisplay.text == sentences[index])
            {
                continueButton.SetActive(true);
            }
        }
        if (isTalking == false)
        {
            if (-1f < transform.position.x - player.transform.position.x && 1f > transform.position.x - player.transform.position.x)
            {
                if (-1f < transform.position.y - player.transform.position.y && 1f > transform.position.y - player.transform.position.y)
                {
                    textButton.SetActive(true);
                }
                else
                {
                    textButton.SetActive(false);
                }
            }
            else
            {
                textButton.SetActive(false);
            }
        }
    }

    public void Button1()
    {
        player.GetComponent<Playables>().isPlaying = false;
        player.GetComponent<Playables>().canJump = false;
        textArea.SetActive(true);
        isTalking = true;
        anim.SetBool("isTalking", true);
        StartCoroutine(Type());
    }

    IEnumerator Type()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
    public void nextSentence()
    {
        continueButton.SetActive(false);

        if (index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else
        {
            textDisplay.text = "";
            anim.SetBool("isTalking", false);
            continueButton.SetActive(false);
            textArea.SetActive(false);
            isTalking = false;
            player.GetComponent<Playables>().isPlaying = true;
            player.GetComponent<Playables>().canJump = true;
            saveManager.GetComponent<SaveController>().bodies[Number - 1] = true;
            endGame.GetComponent<LevelComplete>().BodyCount++;
        }
    }
}