using UnityEngine;
using System.Collections;
using System;

public class Spell : IComparable<Spell> {
	public string name;
	public string code;

	public Spell(string newName, string newCode){
		name = newName;
		code = newCode;
	}

	public int CompareTo(Spell other){
		return name.CompareTo (other.name);
	}
}
