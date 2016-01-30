using UnityEngine;
using System.Collections;

public class CombatSpellbook : MonoBehaviour {


    public GameObject SpellAnimation;
	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        if (GetComponent<CombatInputHandling>().isReady())
        {
            int[] spell = GetComponent<CombatInputHandling>().TakeSpell();
            string spellName = IdentifySpell(spell);
            if(spellName != "")
            {
                SpellAnimation.GetComponent<SpellCaster>().setSpell(spellName);
            }
        }
    }


    //FIRE:  Up, Down, Up, Left, Right
    //ROCK:  Down, Down, Up, Up, Right
    //MEGA:  Up, Right, Down, Left, Up
    //EXPL:  Left, Right, Down, Up, Right
    private string IdentifySpell(int[] spell)
    {
        string spellName = "";
        if(spell[0] == 0)
        {
            if(spell[1] == 1)
            {
                if(spell[2] == 0)
                {
                    if(spell[3] == 2)
                    {
                        if(spell[4] == 3)
                        {
                            spellName = "fire";
                        }
                    }
                }
            }
            else if(spell[1] == 3)
            {
                if(spell[2] == 1)
                {
                    if(spell[3] == 2)
                    {
                        if(spell[4] == 0)
                        {
                            spellName = "mega";
                        }
                    }
                }
            }
        }
        else if(spell[0] == 1)
        {
            if(spell[1] == 1)
            {
                if(spell[2] == 0)
                {
                    if(spell[3] == 0)
                    {
                        if(spell[4] == 3)
                        {
                            spellName = "rock";
                        }
                    }
                }
            }
        }
        else if (spell[0] == 2)
        {
            if(spell[1] == 3)
            {
                if(spell[2] == 1)
                {
                    if(spell[3] == 0)
                    {
                        if(spell[4] == 3)
                        {
                            spellName = "explosive";
                        }
                    }
                }
            }
        }
        return spellName;

    }
}
