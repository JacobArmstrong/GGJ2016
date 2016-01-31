using UnityEngine;
using System.Collections;

public class UnlockedSpells : MonoBehaviour {

    // SPELL INDEX
    // 0 = Conflaguration (fin)
    // 1 = Eviceration (fin)
    // 2 = Telepathy (fin)
    // 3 = burning (mod)
    // 4 = berzerk (mod)
    // 5 = maddening (mod)
    // 6 = Pestulant (mod)
    // 7 = Paralyzing (mod)
    // 8 = arcane (mod)

    private static bool[] SpellStatus = { true, true, true, true, false, false, false, false, false };

	// Use this for initialization
	void Start () {
	    //This runs at the start of every scene.  Do NOT put game starting values here.
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void UnlockSpell(int newSpell)
    {
        SpellStatus[newSpell] = true;
    }

    public bool IsSpellUnlocked(int spell)
    {
        return SpellStatus[spell];
    }

    public static void gameReset()
    {
        SpellStatus = new bool[] { true, true, true, true, false, false, false, false, false };
    }
}