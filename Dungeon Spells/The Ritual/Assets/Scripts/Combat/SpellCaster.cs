using UnityEngine;
using System.Collections;

public class SpellCaster : MonoBehaviour {

    private int timer = -1;
    public Sprite fireSpell;
    public GameObject enemy;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(timer > 0)
        {
            timer--;
        }
        else if(timer == 0)
        {
            timer--;
            GetComponent<SpriteRenderer>().sprite = null;
        }
	}

    public void setSpell(string spellName)
    {
        timer = 50;
        int enemyDamage = 0;
        if(spellName == "fire")
        {
            GetComponent<SpriteRenderer>().sprite = fireSpell;
            enemyDamage = 10;
        }

        enemy.GetComponent<EntityStats>().Damage(enemyDamage);

    }
}
