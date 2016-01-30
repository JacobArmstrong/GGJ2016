using UnityEngine;
using System.Collections;

public class SpellCaster : MonoBehaviour {

    private int timer = -1;
    public Sprite fireSpell;
    public GameObject enemy;

    private bool explosive = false;

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
        float enemyDamage = 0;
        if(spellName == "fire")
        {
            GetComponent<SpriteRenderer>().sprite = fireSpell;
            enemyDamage = 10;

            if (explosive)
            {
                enemyDamage = enemyDamage * 1.5f;
            }
        }

        enemy.GetComponent<EntityStats>().Damage((int)enemyDamage);

    }
}
