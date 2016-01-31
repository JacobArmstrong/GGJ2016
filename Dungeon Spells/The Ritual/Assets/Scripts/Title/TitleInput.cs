using UnityEngine;
using System.Collections;

public class TitleInput : MonoBehaviour {
    
    private bool bEnterPressed = false;
    private new AudioSource audio;

    // Use this for initialization
    void Start ()
    {
        audio = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            audio.Play();
            bEnterPressed = true;
            UnlockedSpells.gameReset();
            Application.LoadLevel("Level1");
        }

        if (bEnterPressed)
        {
            if (!audio.isPlaying)
            {
                Application.LoadLevel("overworld");
            }
        }

        Debug.Log(audio.isPlaying);
    }
}