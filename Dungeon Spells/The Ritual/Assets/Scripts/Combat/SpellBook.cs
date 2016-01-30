using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class SpellBook : MonoBehaviour {
	public Vector2 targetLocation;
	public float slideLerpRate;
	public GameObject[] textSlots;
	public Sprite[] inputIcons;
	public float iconHolderXOffset;
	public float iconHolderYOffset;
	public float iconXBuffer;
	
	public List<Spell> spellList = new List<Spell> ();
	
	private Vector2 startPosition;
	private bool bGetOnScreen = false;
	private int startIndex, endIndex;
	// Use this for initialization
	void Start () {
		startPosition = transform.position;

		spellList.Add(new Spell("Fire", "uuuuu"));
		spellList.Add(new Spell("Grape Soda", "uudlr"));
		spellList.Add(new Spell("Mangrove", "udlrl"));
		spellList.Add(new Spell("Crab", "urldd"));
		spellList.Add(new Spell("Fire", "uuuuu"));
		spellList.Add(new Spell("Grape Soda", "uudlr"));
		spellList.Add(new Spell("Mangrove", "udlrl"));
		spellList.Add(new Spell("Crab", "urldd"));
		startIndex = 0;
		endIndex = 5;
		DrawSpells (startIndex, endIndex);
	}
	
	// Update is called once per frame
	void Update () {
		//switch bGetOnScreen when left shift is pressed
		if (Input.GetKeyDown(KeyCode.LeftShift))
			bGetOnScreen = !bGetOnScreen;

		//if bGetOnScreen is true, go to target location, otherwise go to the starting location
		if (bGetOnScreen) {
			transform.position = Vector2.Lerp (transform.position, targetLocation, slideLerpRate * Time.deltaTime);
			if (Input.GetKeyDown(KeyCode.A) && startIndex > 0)
			{
				startIndex -= 6;
				endIndex -= 6;
				DrawSpells (startIndex, endIndex);
			}
			if (Input.GetKeyDown(KeyCode.D) && endIndex < spellList.Count)
			{
				startIndex += 6;
				endIndex += 6;
				DrawSpells (startIndex, endIndex);
			}
		}
		else
			transform.position = Vector2.Lerp (transform.position, startPosition, slideLerpRate * Time.deltaTime);
	}

	void DrawSpells(int startIndex, int endIndex){
		//clear the current text in the text slots
		ClearText ();

		int textSlotIndex = 0;
		for (int i=startIndex; i <= endIndex; i++, textSlotIndex++){
			//make sure i doesn't exceed the range of spellList
			if(i < spellList.Count){
				//put the ith spell's name into the text
				textSlots[textSlotIndex].GetComponent<TextMesh>().text = spellList[i].name;

				//create an empty game object to hold input icons
				GameObject iconHolder = new GameObject(spellList[i].name +"'s icon holder");
				iconHolder.transform.position = textSlots[textSlotIndex].transform.position + (new Vector3(iconHolderXOffset, iconHolderYOffset, 0.0f));
				//attach the new game object to its respective text slot
				iconHolder.transform.SetParent(textSlots[textSlotIndex].transform);

				//Draw icons to the icon holder
				DrawIcons(spellList[i].code, iconHolder);
			}
		}
	}
	void ClearText(){
		for (int i=0; i<textSlots.Length; i++) {
			//clear all text currently in the text slots
			textSlots[i].GetComponent<TextMesh>().text = "";
			//remove the input icons attatched to the text slots
			if(textSlots[i].transform.childCount > 0)
				Destroy(textSlots[i].transform.GetChild(0).gameObject);
		}
	}

	void DrawIcons(string input, GameObject holder){
		int index = 0;
		while (input.Length > 0) {
			//Create a gameobject to render the icon
			GameObject icon = new GameObject("icon");
			icon.AddComponent<SpriteRenderer>();

			//attach the icon gameobject to the icon holder
			icon.transform.position = holder.transform.position;
			icon.transform.SetParent(holder.transform);

			//move the icon to the right
			icon.transform.position += new Vector3(iconXBuffer * index, 0.0f, 0.0f);

			//get the first character in the input string
			char newInput = input[0];
			//render an icon based on the first character
			if(newInput == 'u')
				icon.GetComponent<SpriteRenderer>().sprite = inputIcons[0];
			if(newInput == 'd')
				icon.GetComponent<SpriteRenderer>().sprite = inputIcons[1];
			if(newInput == 'l')
				icon.GetComponent<SpriteRenderer>().sprite = inputIcons[2];
			if(newInput == 'r')
				icon.GetComponent<SpriteRenderer>().sprite = inputIcons[3];
			//shorten the input string
			if(input.Length > 0)
				input = input.Substring(1,input.Length-1);
			
			index++;
		}
	}
	
	void OnDrawGizmosSelected() {
		Gizmos.color = Color.red;
		Gizmos.DrawSphere(targetLocation, 0.5f);
	}
}
