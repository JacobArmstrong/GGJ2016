using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

    public GameObject Caster;
    int timer = 300;
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
        }
	}
}
