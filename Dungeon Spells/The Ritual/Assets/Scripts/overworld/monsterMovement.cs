using UnityEngine;
using System.Collections.Generic;


public class monsterMovement : MonoBehaviour {
    public float timeBetweenMoves;
    public float moveScale = 1.0f;

    private List<Vector3> possibleMoves = new List<Vector3>();
    private float timer;
    private bool bIsValidMove = true;
	// Use this for initialization
	void Start () {
        timer = timeBetweenMoves;
	}
	
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            //checking the possible moves
            //check up
            //first, do a raycast in the direction we want to go clamped by the distance we want to go
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.up, moveScale);
            //if the raycast doesn't hit anything, the move is possible to do
            if (hit.collider == null)
                possibleMoves.Add(Vector3.up * moveScale);
            //check down
            hit = Physics2D.Raycast(transform.position, Vector3.down, moveScale);
            //if the raycast doesn't hit anything, the move is possible to do
            if (hit.collider == null)
                possibleMoves.Add(Vector3.down * moveScale);
            //check left
            hit = Physics2D.Raycast(transform.position, Vector3.left, moveScale);
            //if the raycast doesn't hit anything, the move is possible to do
            if (hit.collider == null)
                possibleMoves.Add(Vector3.left * moveScale);
            //check right
            hit = Physics2D.Raycast(transform.position, Vector3.right, moveScale);
            //if the raycast doesn't hit anything, the move is possible to do
            if (hit.collider == null)
                possibleMoves.Add(Vector3.right * moveScale);
    
            //select a random move from the list of possible moves
            if (possibleMoves.Count > 0)
                transform.position += possibleMoves[(int)(Random.value * possibleMoves.Count)];
            //clear the list of possible moves for the next iteration
            possibleMoves.Clear();

            timer = timeBetweenMoves;
        }
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("HELP IVE BEEN HIT");
        bIsValidMove = false;
    }
}
