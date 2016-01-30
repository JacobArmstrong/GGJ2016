using UnityEngine;
using System.Collections;

public class CombatInputHandling : MonoBehaviour {
	private float hInput, vInput;
	
	//private GameObject upArrow, downArrow, leftArrow, rightArrow;
	public Sprite[] arrows = new Sprite[4];
    const int maxChain = 5;
    public GameObject[] slots = new GameObject[maxChain];
    private int[] spell = new int[maxChain];
	// Use this for initialization
	void Start () {
        //slots[0].GetComponent<SpriteRenderer>().sprite = arrows[0];
        //slots[1].GetComponent<SpriteRenderer>().sprite = arrows[1];
        //slots[2].GetComponent<SpriteRenderer>().sprite = arrows[2];
        //slots[3].GetComponent<SpriteRenderer>().sprite = arrows[3];
        //slots[4].GetComponent<SpriteRenderer>().sprite = arrows[0];
        //slots[5].GetComponent<SpriteRenderer>().sprite = arrows[1];
        //slots[6].GetComponent<SpriteRenderer>().sprite = arrows[2];
        //slots[7].GetComponent<SpriteRenderer>().sprite = arrows[3];
    }
	
	// Update is called once per frame
	void Update ()
    {
		if (Input.GetKeyDown(KeyCode.W))
        {
            setArrow("up");
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            setArrow("down");
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            setArrow("left");
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            setArrow("right");
        }
    }


    private void setArrow(string btn)
    {
        for (int i = 0; i < maxChain; i++)
        {

            if (slots[i].GetComponent<SpriteRenderer>().sprite == null)
            {
                if (btn == "up")
                {
                    slots[i].GetComponent<SpriteRenderer>().sprite = arrows[0];
                    spell[i] = 0;
                    break;
                }
                else if (btn == "down")
                {
                    slots[i].GetComponent<SpriteRenderer>().sprite = arrows[1];
                    spell[i] = 1;
                    break;
                }
                else if (btn == "left")
                {
                    slots[i].GetComponent<SpriteRenderer>().sprite = arrows[2];
                    spell[i] = 2;
                    break;
                }
                else if (btn == "right")
                {
                    slots[i].GetComponent<SpriteRenderer>().sprite = arrows[3];
                    spell[i] = 3;
                    break;
                }
            }
        }
    }

    public bool isReady()
    {
        if(slots[maxChain-1].GetComponent<SpriteRenderer>().sprite != null)
        {
            return true;
        }
        return false;
    }

    public int[] TakeSpell()
    {
        int[] tempSpell = spell;
        
        for(int i = 0; i<maxChain; i++)
        {
            slots[i].GetComponent<SpriteRenderer>().sprite = null;
            spell[i] = 0;
        }

        return tempSpell;
    }
}