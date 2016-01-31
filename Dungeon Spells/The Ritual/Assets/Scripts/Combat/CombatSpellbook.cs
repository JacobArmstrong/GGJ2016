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
        if (spell[0] == 0 && spell[1] == 1 && spell[2] == 0 && spell[3] == 2 && spell[4] == 3)
        {
            if (unlocked.IsSpellUnlocked(0))
            {
                spellName = "Conflagration";
            }
        }
        else if (spell[0] == 3 && spell[1] == 2 && spell[2] == 3 && spell[3] == 2 && spell[4] == 3)
        {
            if (unlocked.IsSpellUnlocked(1))
            {
                spellName = "Evisceration";
            }
        }
        else if (spell[0] == 0 && spell[1] == 0 && spell[2] == 1 && spell[3] == 2 && spell[4] == 3)
        {
            if (unlocked.IsSpellUnlocked(2))
            {
                spellName = "Telepathy";
            }
        }
        else if (spell[0] == 3 && spell[1] == 2 && spell[2] == 0 && spell[3] == 0 && spell[4] == 0)
        {
            if (unlocked.IsSpellUnlocked(3))
            {
                spellName = "Immolating";
            }
        }
        else if (spell[0] == 2 && spell[1] == 3 && spell[2] == 2 && spell[3] == 3 && spell[4] == 2)
        {
            if (unlocked.IsSpellUnlocked(4))
            {
                spellName = "Berserk";
            }
        }
        else if (spell[0] == 0 && spell[1] == 2 && spell[2] == 1 && spell[3] == 3 && spell[4] == 0)
        {
            if (unlocked.IsSpellUnlocked(5))
            {
                spellName = "Maddening";
            }
        }
        else if (spell[0] == 2 && spell[1] == 3 && spell[2] == 1 && spell[3] == 0 && spell[4] == 1)
        {
            if (unlocked.IsSpellUnlocked(6))
            {
                spellName = "Pestulant";
            }
        }
        else if (spell[0] == 1 && spell[1] == 2 && spell[2] == 3 && spell[3] == 1 && spell[4] == 1)
        {
            if (unlocked.IsSpellUnlocked(7))
            {
                spellName = "Paralyzing";
            }
        }
        else if (spell[0] == 0 && spell[1] == 1 && spell[2] == 3 && spell[3] == 2 && spell[4] == 0)
        {
            if (unlocked.IsSpellUnlocked(8))
            {
                spellName = "Arcane";
            }
        }

        return spellName;

    }
}
