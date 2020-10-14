using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class gameData
{
    public bool[] levels = new bool[30];
    public bool[] bodies = new bool[30];
    public bool[] magicians = new bool[30];
    public int coins = 0;
   

  
    public gameData(SaveController save)
    {
        for (int i = 0; i < 30; i++)
        {
            levels[i] = save.levels[i];
        }
        for (int a = 0; a < 30; a++)
        {
            bodies[a] = save.bodies[a];
        }
        for (int z = 0; z < 30; z++)
        {
            magicians[z] = save.magicians[z];
        }

        coins = save.coins;
        //HRUnit=save.HRUnit;
    }
}
