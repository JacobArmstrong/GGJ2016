using UnityEngine;
using System.Collections.Generic;

public class monsterMovement : MonoBehaviour {
    public float timeBetweenMoves;
    public float moveAmount = 1.0f;
    public float moveSpeed;

    private bool bIsMoving;
    public Vector3 targetPosition;
    private Vector3 beginPosition;
    private float timeSpentMoving;

    private List<Vector3> possibleMoves = new List<Vector3>();
    private float timer;
	// Use this for initialization
	void Start ()
    {
        timer = timeBetweenMoves;
        targetPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(!bIsMoving)
        {
        timer -= Time.deltaTime;
            if (timer <= 0)
        {
            //checking the possible moves
            //check up
            //first, do a raycast in the direction we want to go clamped by the distance we want to go
                RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.up, moveAmount);
            //if the raycast doesn't hit anything, the move is possible to do
            if (hit.collider == null)
                    possibleMoves.Add(Vector3.up * moveAmount);
            //check down
                hit = Physics2D.Raycast(transform.position, Vector3.down, moveAmount);
            //if the raycast doesn't hit anything, the move is possible to do
            if (hit.collider == null)
                    possibleMoves.Add(Vector3.down * moveAmount);
            //check left
                hit = Physics2D.Raycast(transform.position, Vector3.left, moveAmount);
            //if the raycast doesn't hit anything, the move is possible to do
            if (hit.collider == null)
                    possibleMoves.Add(Vector3.left * moveAmount);
            //check right
                hit = Physics2D.Raycast(transform.position, Vector3.right, moveAmount);
            //if the raycast doesn't hit anything, the move is possible to do
            if (hit.collider == null)
                    possibleMoves.Add(Vector3.right * moveAmount);
    
            //select a random move from the list of possible moves
            if (possibleMoves.Count > 0)
                {
                    targetPosition += possibleMoves[(int)(Random.value * possibleMoves.Count)];
                    initMovement();
                }
            //clear the list of possible moves for the next iteration
            possibleMoves.Clear();

            timer = timeBetweenMoves;
        }
        }

        else
        {
            timeSpentMoving += Time.deltaTime;

            if (transform.position != targetPosition)
            {
                float distCovered = timeSpentMoving / moveSpeed;
                float fracJourney = distCovered / moveAmount;
                transform.position = Vector3.Lerp(beginPosition, targetPosition, fracJourney);
            }
            else
            {
                bIsMoving = false;
                timeSpentMoving = 0.0f;
                targetPosition = transform.position;
            }
        }
        
    }

    void initMovement()
    {
        bIsMoving = true;
        beginPosition = transform.position;
	}

    void OnTriggerEnter2D(Collider2D other)
    {
<<<<<<< HEAD
        Debug.Log(other.tag);
        if(other.tag == "Player")
            Debug.Log("HELP IVE BEEN HIT");
=======
        if (other.tag == "Player")
            Application.LoadLevel("Combat");
>>>>>>> cd4d5354c877072030aec23fc097ae1f5585a712
    }
}