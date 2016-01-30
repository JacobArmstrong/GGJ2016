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

    private string IdentifySpell(int[] spell)
    {
        string spellName = "";
        if(spell[0] == 0)
        {
            if(spell[1] == 0)
            {
                if(spell[2] == 0)
                {
                    if(spell[3] == 0)
                    {
                        if(spell[4] == 0)
                        {
                            spellName = "fire";
                        }
                    }
                }
            }
        }
        return spellName;

    }
}
