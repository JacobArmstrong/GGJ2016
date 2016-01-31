using UnityEngine;
using System.Collections;

public class SpellCaster : MonoBehaviour {

    private int timer = -1;
    private int textTimer = -1;
    public Sprite fireSpell;
    public GameObject enemy;

    private bool explosive = false;
    private bool mega = false;
    private bool soft = false;

    public GameObject TextHolder;



	// Use this for initialization
	void Start () {
        if(TextHolder != null)
        TextHolder.GetComponent<TextMesh>().text = "";
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

        if (textTimer > 0)
        {
            textTimer--;
        }
        else if(textTimer == 0)
        {
            textTimer--;
            if (TextHolder != null)
                TextHolder.GetComponent<TextMesh>().text = "";
        }
	}

    public void setSpell(string spellName)
    {
        timer = 50;
        textTimer = 100;
        float enemyDamage = 0;
        string totalSpellName = "";
        if(spellName == "fire")
        {
            GetComponent<SpriteRenderer>().sprite = fireSpell;
            enemyDamage = 10;

            if (soft)
            {
                totalSpellName += "Soft ";
            }
            if (explosive)
            {
                totalSpellName += "Explosive ";
                enemyDamage = enemyDamage * 2.5f;
            }
            if (mega)
            {
                totalSpellName += "Mega ";
                enemyDamage += 5;
            }
            
            resetSpell();
            totalSpellName += "Fire!";
        }
        else if(spellName == "rock")
        {
            GetComponent<SpriteRenderer>().sprite = fireSpell;
            enemyDamage = 5;
            if (mega)
            {
                totalSpellName += "Mega ";
                enemyDamage += 10;
            }
            if (explosive)
            {
                totalSpellName += "Explosive ";
                enemyDamage = enemyDamage * 2;
            }
            if (soft)
            {
                totalSpellName += "Soft ";
                enemyDamage = enemyDamage * 0.5f;
            }
            resetSpell();
            totalSpellName += "Rock!";
        }

        else if(spellName == "mega")
        {
            mega = true;
            totalSpellName += "Mega!";
        }
        else if(spellName == "explosive")
        {
            totalSpellName += "Explosive!";
            explosive = true;
        }
        else if(spellName == "soft")
        {
            totalSpellName += "Soft?";
            soft = true;
        }

        enemy.GetComponent<EntityStats>().Damage((int)enemyDamage);
        if (TextHolder != null)
            TextHolder.GetComponent<TextMesh>().text = totalSpellName;
    }

    private void resetSpell()
    {
        mega = false;
        explosive = false;
        soft = false;
    }
}
