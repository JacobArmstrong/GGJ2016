using UnityEngine;
using System.Collections;

public class TitleInput : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            UnlockedSpells.gameReset();
            Application.LoadLevel("overworld");
        }
    }
}
