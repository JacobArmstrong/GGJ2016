using UnityEngine;
using System.Collections;

public class CombatSpellbook : MonoBehaviour {


    public GameObject SpellAnimation;
    public GameObject UnlockedSpells;
    private UnlockedSpells unlocked;


	// Use this for initialization
	void Start () {
        unlocked = UnlockedSpells.GetComponent<UnlockedSpells>();
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
    //SOFT:  Down, Down, Down, Down, Down
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
                            if (unlocked.IsSpellUnlocked(0))
                            {
                                spellName = "fire";
                            }
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
                            if (unlocked.IsSpellUnlocked(2))
                            {
                                spellName = "mega";
                            }
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
                            if (unlocked.IsSpellUnlocked(1))
                            {
                                spellName = "rock";
                            }
                        }
                    }
                }
                else if(spell[2] == 1)
                {
                    if(spell[3] == 1)
                    {
                        if(spell[4] == 1)
                        {
                            if (unlocked.IsSpellUnlocked(4))
                            {
                                spellName = "soft";
                            }
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
                            if (unlocked.IsSpellUnlocked(3))
                            {
                                spellName = "explosive";
                            }
                        }
                    }
                }
            }
        }
        return spellName;

    }
}
