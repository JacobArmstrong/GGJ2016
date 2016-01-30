using UnityEngine;
using System.Collections;

public class EntityStats : MonoBehaviour {

    public int Health = 100;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Damage(int dmg)
    {
        Health -= dmg;
    }
}
