using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class menu : MonoBehaviour
{
    private int i = 0;
    public GameObject area;
    public Animator anim;
   
    public void play()
    {
        StartCoroutine(LoadLevel(1));
    }
    public void backToMenu()
    {
        SceneManager.LoadScene(0);
    }
    IEnumerator LoadLevel(int index)
    {
        anim.SetTrigger("Fade");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(index);
    }
    public void quit()
    {
        Debug.Log("quit");
        Application.Quit();
    }

    public void info()
    {
        if(i==0)
        {
            
            area.SetActive(true);
            i = 1;
        }
        else if(i==1)
        {
            
            area.SetActive(false);
            i = 0;
        }
    }
}
