using UnityEngine;
using System.Collections;

public class overworldMove : MonoBehaviour
{
    public float moveAmount;
    public float moveSpeed;

    private new SpriteRenderer renderer;
    private Vector3 targetPosition;
    private Vector3 beginPosition;
    private float timeSpentMoving;
    private bool bIsMoving;

    //Arrays to hold the sprites
    public Sprite[] up = new Sprite[0];
    public Sprite[] left = new Sprite[0];
    public Sprite[] down = new Sprite[0];
    public Sprite[] right = new Sprite[0];

    // Use this for initialization
    void Start ()
    {
        renderer = GetComponent<SpriteRenderer>();
        targetPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //checking the possible moves
        if (!bIsMoving) {
            //check up
            //first, do a raycast in the direction we want to go clamped by the distance we want to go
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.up, moveAmount);
            //if the raycast doesn't hit anything, the move is possible to do
            if (hit.collider == null)
            {
                targetPosition = Vector3.up * moveAmount;
                initMovement();
            }
            //check down
            hit = Physics2D.Raycast(transform.position, Vector3.down, moveAmount);
            //if the raycast doesn't hit anything, the move is possible to do
            if (hit.collider == null)
            {
                targetPosition = Vector3.down * moveAmount;
                initMovement();
            }
            //check left
            hit = Physics2D.Raycast(transform.position, Vector3.left, moveAmount);
            //if the raycast doesn't hit anything, the move is possible to do
            if (hit.collider == null)
            {
                targetPosition = Vector3.left * moveAmount;
                initMovement();
            }
            //check right
            hit = Physics2D.Raycast(transform.position, Vector3.right, moveAmount);
            //if the raycast doesn't hit anything, the move is possible to do
            if (hit.collider == null)
            {
                targetPosition = Vector3.right * moveAmount;
                initMovement();
            }
        }

        //if the character is moving, gradually lerp them to their target
        if (bIsMoving)
        {
            timeSpentMoving += Time.deltaTime;
        }
    }

    void initMovement()
    {
        bIsMoving = true;
        beginPosition = transform.position;
    }
}
