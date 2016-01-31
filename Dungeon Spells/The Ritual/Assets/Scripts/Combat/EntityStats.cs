using UnityEngine;
using System.Collections;

public class EntityStats : MonoBehaviour {

    public int Health = 100;
    public GameObject HealthCounter;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        HealthCounter.GetComponent<TextMesh>().text = Health.ToString();
	}

    public void Damage(int dmg)
    {
        Health -= dmg;
    }
}
