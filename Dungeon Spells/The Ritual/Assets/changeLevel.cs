using UnityEngine;
using System.Collections;

public class changeLevel : MonoBehaviour
{
    

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    //this doesn't work, player can't go onto ladder tile because of ray casting + box colliders
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            UnlockedSpells.defeatedEnemies.Clear();
            nextLevel();
        }
    }

    //determines which level to go to next
    void nextLevel()
    {
        if (Application.loadedLevelName.Equals("Level1"))
        {
            Application.LoadLevel("Level2");
        }
        else if (Application.loadedLevelName.Equals("Level2"))
        {
            Application.LoadLevel("Level3");
        }
        else if (Application.loadedLevelName.Equals("Level3"))
        {
            Application.LoadLevel("Level4");
        }
        else if (Application.loadedLevelName.Equals("Level4"))
        {
            Application.LoadLevel("Level5");
        }
    }
}
