using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DeadNotes : MonoBehaviour
{
    public GameObject DeadManUI;
    public GameObject DeadManText;
    private GameObject saveManager;
    public Button[] deadMans = new Button[30];
    public TextMeshProUGUI deadText;
    
    private void Start()
    {
        saveManager = GameObject.Find("GameSaveManager");
    }
    private void Update()
    {
      for(int i=0;i<30;i++)
        {
            if(saveManager.GetComponent<SaveController>().bodies[i] == false)
            {
                deadMans[i].interactable = false;
            }
            else if (saveManager.GetComponent<SaveController>().bodies[i] == true)
            {
                deadMans[i].interactable = true;
            }
        }
    }
    public void DeadNotesUIOpen()
    {
        DeadManUI.SetActive(true);
    }
    public void DeadNotesUIClose()
    {
        DeadManUI.SetActive(false);
        DeadManText.SetActive(false);
        deadText.text = "";
    }
   
    public void NoteClose()
    {
        DeadManText.SetActive(false);
        deadText.text = "";
    }
}
