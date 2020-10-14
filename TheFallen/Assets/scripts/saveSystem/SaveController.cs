using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SaveController : MonoBehaviour
{
    public bool[] levels = new bool[30];
    public bool[] bodies = new bool[30];
    public bool[] magicians = new bool[30];
    public int coins = 0;
  
    public static SaveController instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }

    public void SaveGame()
    {
        GameSavingSystem.SaveGame(this);
    }

    public void LoadGame()
    {
        gameData data = GameSavingSystem.LoadGame();

        for (int i = 0; i < 30; i++)
        {
            levels[i] = data.levels[i];
        }
        for (int a = 0; a < 30; a++)
        {
            bodies[a] = data.bodies[a];
        }
        for (int z = 0; z < 30; z++)
        {
            magicians[z] = data.magicians[z];
        }
        coins = data.coins;
    }
    

}
