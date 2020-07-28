using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : MonoBehaviour
{
    public Spell[] spells;

    public int level = 1;
    public int exp;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            foreach(var spell in spells)
            {
                if(spell.levelReq == level)
                {
                    spell.Cast();
                    exp += spell.expGained;
                }
            }
        }
    }
}
