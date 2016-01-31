using UnityEngine;
using System.Collections;

public class UnlockedSpells : MonoBehaviour {

    // SPELL INDEX
    // 0 = fire (fin)
    // 1 = frost (fin)
    // 2 = mega (mod)
    // 3 = explosive (mod)
    // 4 = soft (mod)
    // 5 = cut / Flagellation (fin)
    // 6 = Telepathy (fin)
    // 7 = 

    private static bool[] SpellStatus = { true, true, true, true, true, false, false, false };

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
        SpellStatus = new bool[]{ true, true, true, true, false, false, false, false };
    }
}