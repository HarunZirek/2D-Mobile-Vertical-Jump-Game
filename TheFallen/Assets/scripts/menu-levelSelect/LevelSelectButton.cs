using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
public class LevelSelectButton : MonoBehaviour
{
    private GameObject saveManager;
    public GameObject LoadingScreenUI;
    public int SceneToOpen;
    public int levelNumber;
    public string Loretext;
    public TextMeshProUGUI Lore;
    public GameObject LevelMenu;
    public Animator anim;

    public Button isOpen;
    private void Start()
    {
        saveManager = GameObject.Find("GameSaveManager");
        isOpen.interactable = false;
    }

    private void Update()
    {
        if(levelNumber==1)
        {
            isOpen.interactable = true;
            return;
        }
        else
        {
           if (saveManager.GetComponent<SaveController>().levels[levelNumber - 2]==true)
            {
                isOpen.interactable = true;
            }
        }
    }
    public void openLevelMenu()
    {
        LevelMenu.SetActive(true);
        Lore.text = Loretext;
        
    }

    public void OpenLevel()
    {
        LoadingScreenUI.SetActive(true);
        anim.SetTrigger("loadingScreen");
        StartCoroutine(LoadLevel(SceneToOpen));
    }
    public void CloseLevelMenu()
    {
        LevelMenu.SetActive(false);
        Lore.text = "";
    }
    IEnumerator LoadLevel(int index)
    {      
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene(index);
    }
}
