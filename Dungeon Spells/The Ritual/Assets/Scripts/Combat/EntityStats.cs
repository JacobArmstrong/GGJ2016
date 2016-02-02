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

        //when this entity runs out  of health
        if (Health <= 0)
            //if the entity is a player, go to a game over screen
            if (tag == "Player")
                GameOver();
            else
                GoToOverworld();
	}

    public void Damage(int dmg)
    {
        Health -= dmg;
    }

    public void GameOver()
    {
        Application.LoadLevel("GameOver");
    }

    public void GoToOverworld()
    {
        //Load the previous level
        Application.LoadLevel(UnlockedSpells.lastLevelIndex);
    }
}
