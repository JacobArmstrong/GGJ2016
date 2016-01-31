using UnityEngine;
using System.Collections;

public class SpellCaster : MonoBehaviour {

    private int timer = -1;
    public Sprite fireSpell;
    public GameObject enemy;

    private bool explosive = false;
    private bool mega = false;
    private bool soft = false;

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
                enemyDamage = enemyDamage * 2.5f;
            }
            if (mega)
            {
                enemyDamage += 5;
            }


            resetSpell();
        }
        else if(spellName == "rock")
        {
            GetComponent<SpriteRenderer>().sprite = fireSpell;
            enemyDamage = 5;
            if (mega)
            {
                enemyDamage += 10;
            }
            if (explosive)
            {
                enemyDamage = enemyDamage * 2;
            }
            if (soft)
            {
                enemyDamage = enemyDamage * 0.5f;
            }
            resetSpell();
        }

        else if(spellName == "mega")
        {
            mega = true;
        }
        else if(spellName == "explosive")
        {
            explosive = true;
        }
        else if(spellName == "soft")
        {
            soft = true;
        }

        enemy.GetComponent<EntityStats>().Damage((int)enemyDamage);

    }

    private void resetSpell()
    {
        mega = false;
        explosive = false;
        soft = false;
    }
}
