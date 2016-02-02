using UnityEngine;
using System.Collections;

public class monsterAnimation : MonoBehaviour
{
    public Sprite[] sprites = new Sprite[0];
    public float timeBetweenSprites;

    private float timer;
    private int index = 0;
    private new SpriteRenderer renderer;


    public int monsterID;
    // Use this for initialization
    void Start ()
    {
        timer = timeBetweenSprites;
        renderer = GetComponent<SpriteRenderer>();
        renderer.sprite = sprites[index];
	}
	
	// Update is called once per frame
	void Update ()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            //increment index, wrapping around if necessary
            if (index >= sprites.Length - 1)
                index = 0;
            else
                index++;

            renderer.sprite = sprites[index];

            timer = timeBetweenSprites;
        }
	}

    void Awake()
    {
        bool objectFound = false;

        if (UnlockedSpells.defeatedEnemies.Count > 0)
        {
            for (int i = 0; i < UnlockedSpells.defeatedEnemies.Count; i++)
            {
                if (UnlockedSpells.defeatedEnemies[i] == monsterID)
                    objectFound = true;
            }
        }

        if (objectFound)
            Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            UnlockedSpells.bWasInCombat = true;
            UnlockedSpells.lastKnownPosition = other.GetComponent<overworldMove>().beginPosition;
            UnlockedSpells.lastLevelIndex = Application.loadedLevel;
            UnlockedSpells.defeatedEnemies.Add(monsterID);
            Application.LoadLevel("Combat");
        }
    }
}
