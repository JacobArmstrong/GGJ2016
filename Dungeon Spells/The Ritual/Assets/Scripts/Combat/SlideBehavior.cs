using UnityEngine;
using System.Collections;

public class SlideBehavior : MonoBehaviour {
	public Vector2 targetLocation;
	public float slideLerpRate;

	private Vector2 startPosition;
	private float slideDistance;
	// Use this for initialization
	void Start () {
		startPosition = transform.position;
		slideDistance = Vector2.Distance (startPosition, targetLocation);
	}
	
	// Update is called once per frame
	void Update () {
		//I'm actually using this function the wrong way, but I like the way it looks
		transform.position = Vector2.Lerp (transform.position, targetLocation, slideLerpRate * Time.deltaTime);
	}

	void OnDrawGizmosSelected() {
		Gizmos.color = Color.red;
		Gizmos.DrawSphere(targetLocation, 0.5f);
	}
}
