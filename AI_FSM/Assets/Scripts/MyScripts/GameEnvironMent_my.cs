using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class GameEnvironMent_my
{
    public static GameEnvironMent_my instance;
    public List<GameObject> chekcpoints = new List<GameObject>();

    public List<GameObject> Checkpoints { get { return chekcpoints; } }

    public static GameEnvironMent_my singleton
    {
        get
        {
            if(instance == null)
            {
                instance = new GameEnvironMent_my();
                instance.chekcpoints.AddRange(GameObject.FindGameObjectsWithTag("Checkpoint"));
            }
            return instance;
        }
    }

}


