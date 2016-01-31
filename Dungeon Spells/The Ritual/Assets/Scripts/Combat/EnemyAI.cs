using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

    public GameObject Caster;
    int timer = 300;
    int animTimer = -1;

    public GameObject Player;

    public Sprite[] sprites = new Sprite[2];
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        timer--;
        if(timer <= 0)
        {
            Caster.GetComponent<SpellCaster>().setSpell("Evisceration");
            timer = 300;
            Player.GetComponent<SpriteRenderer>().sprite = sprites[1];
            animTimer = 50;
        }

        if (animTimer > 0)
        {
            animTimer--;
        }
        else if (animTimer == 0)
        {
            animTimer--;
            Player.GetComponent<SpriteRenderer>().sprite = sprites[0];
        }
    }
}
