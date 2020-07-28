using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Spell
{

    public string name;
    public int levelReq;
    public int itemReq;
    public int expGained;

    public Spell(string name, int levelReq, int itemReq, int expGained)
    {
        this.name = name;
        this.levelReq = levelReq;
        this.itemReq = itemReq;
        this.expGained = expGained;
    }

    public void Cast()
    {
        Debug.Log("Cast Spell: "+ this.name);
    }
}
