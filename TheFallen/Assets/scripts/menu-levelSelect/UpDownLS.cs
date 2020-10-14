using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UpDownLS : MonoBehaviour
{
    private GameObject saveManager;
    private GameObject Mcamera;
    public int Arealock;
    
    public Button isOpen;
    private void Start()
    {
        saveManager = GameObject.Find("GameSaveManager");
        Mcamera = GameObject.Find("Main Camera");
        isOpen.interactable = false;
        if (saveManager.GetComponent<SaveController>().levels[9] == true)
        {
            if (saveManager.GetComponent<SaveController>().levels[19] == true)
            {
                Mcamera.transform.position = new Vector3(Mcamera.transform.position.x, 21.5f, Mcamera.transform.position.z);
            }
            else
            {
                Mcamera.transform.position = new Vector3(Mcamera.transform.position.x, 10.75f, Mcamera.transform.position.z);
            }
        }
    }

    private void Update()
    {
        if (Arealock == 0)
        {
            isOpen.interactable = true;
            return;
        }
        else
        {
            if (saveManager.GetComponent<SaveController>().levels[(Arealock*10)-1] == true)
            {
                isOpen.interactable = true;
            }
        }
    }

    public void Up()
    {
        Mcamera.transform.position = new Vector3(Mcamera.transform.position.x, Mcamera.transform.position.y + 10.75f, Mcamera.transform.position.z);      
    }
    public void Down()
    {
        Mcamera.transform.position = new Vector3(Mcamera.transform.position.x, Mcamera.transform.position.y - 10.75f, Mcamera.transform.position.z);
    }
  
}
