using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coins : MonoBehaviour
{

    private GameObject saveManager;
    public GameObject endGame;
    private void Start()
    {
        saveManager = GameObject.Find("GameSaveManager");
    }

    private void Update()
    {       
           
    }
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.name == "Player")
        {
            Destroy(gameObject);
            FindObjectOfType<audioManager>().Play("coin");
            saveManager.GetComponent<SaveController>().coins++;
            saveManager.GetComponent<SaveController>().SaveGame();
            endGame.GetComponent<LevelComplete>().CoinCount++;
        }
    }
    public void AdCoin()
    {
        saveManager.GetComponent<SaveController>().coins+=300;
        saveManager.GetComponent<SaveController>().SaveGame();
    }
}
