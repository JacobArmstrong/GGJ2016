using UnityEngine;
using System.Collections;

public class SpellCaster : MonoBehaviour
{

    private int timer = -1;
    private int textTimer = -1;
    public Sprite fireSpell;
    public Sprite cutSpell;
    public Sprite mindSpell;
    public GameObject enemy;

    private bool Immolating = false;
    private bool Berserk = false;
    private bool Maddening = false;
    private bool Pestulant = false;
    private bool Paralyzing = false;
    private bool Arcane = false;

    public GameObject TextHolder;
    public GameObject DmgHolder;



    // Use this for initialization
    void Start()
    {
        if (TextHolder != null)
            TextHolder.GetComponent<TextMesh>().text = "";
        if (DmgHolder != null)
            DmgHolder.GetComponent<TextMesh>().text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            timer--;
        }
        else if (timer == 0)
        {
            timer--;
            GetComponent<SpriteRenderer>().sprite = null;
        }

        if (textTimer > 0)
        {
            textTimer--;
        }
        else if (textTimer == 0)
        {
            textTimer--;
            if (TextHolder != null)
                TextHolder.GetComponent<TextMesh>().text = "";
            if (DmgHolder != null)
                DmgHolder.GetComponent<TextMesh>().text = "";
        }
    }

    public void setSpell(string spellName)
    {
        timer = 50;
        textTimer = 100;
        float enemyDamage = 0;
        string totalSpellName = "";
        if (spellName == "Conflagration")
        {
            GetComponent<SpriteRenderer>().sprite = fireSpell;
            enemyDamage = 10f;

            if (Immolating)
            {
                totalSpellName += "Immolating ";
                enemyDamage = enemyDamage * 2.5f;
            }
            if (Pestulant)
            {
                //DOT LATER
                totalSpellName += "Pestulant ";
                enemyDamage = enemyDamage * 2f;
            }
            if (Arcane)
            {
                totalSpellName += "Arcane ";
                enemyDamage += 25;
            }

            resetSpell();
            totalSpellName += "Conflagration!";
        }
        else if (spellName == "Evisceration")
        {
            GetComponent<SpriteRenderer>().sprite = cutSpell;
            enemyDamage = 10f;
            if (Berserk)
            {
                totalSpellName += "Berserk ";
                enemyDamage += 20;
            }
            if (Pestulant)
            {
                //DOT LATER
                totalSpellName += "Pestulant ";
                enemyDamage = enemyDamage * 2;
            }
            if (Paralyzing)
            {
                //STUN LATER
                totalSpellName += "Paralyzing ";
                enemyDamage = enemyDamage * 2.0f;
            }
            resetSpell();
            totalSpellName += "Evisceration!";
        }
        else if (spellName == "Telepathy")
        {
            GetComponent<SpriteRenderer>().sprite = mindSpell;
            enemyDamage = 10f;
            if (Maddening)
            {
                totalSpellName += "Maddening ";
                enemyDamage += 15;
            }
            if (Paralyzing)
            {
                //DOT LATER
                totalSpellName += "Paralyzing ";
                enemyDamage += 15;
            }
            if (Arcane)
            {
                //STUN LATER
                totalSpellName += "Arcane ";
                enemyDamage = enemyDamage * 2.0f;
            }
            resetSpell();
            totalSpellName += "Telepethy!";
        }


        else if (spellName == "Immolating")
        {
            Immolating = true;
            totalSpellName += "Immolating!";
        }
        else if (spellName == "Berserk")
        {
            totalSpellName += "Berserk!";
            Berserk = true;
        }
        else if (spellName == "Maddening")
        {
            totalSpellName += "Maddening!";
            Maddening = true;
        }
        else if (spellName == "Pestulant")
        {
            Pestulant = true;
            totalSpellName += "Pestulant!";
        }
        else if (spellName == "Paralyzing")
        {
            totalSpellName += "Paralyzing!";
            Paralyzing = true;
        }
        else if (spellName == "Arcane")
        {
            totalSpellName += "Arcane!";
            Arcane = true;
        }

        enemy.GetComponent<EntityStats>().Damage((int)enemyDamage);
        if (TextHolder != null)
            TextHolder.GetComponent<TextMesh>().text = totalSpellName;
        if(enemyDamage > 0)
        if(DmgHolder != null)
            DmgHolder.GetComponent<TextMesh>().text = "-" + enemyDamage.ToString();
    }

    private void resetSpell()
    {
        Immolating = false;
        Berserk = false;
        Maddening = false;
        Pestulant = false;
        Paralyzing = false;
        Arcane = false;
    }
}
