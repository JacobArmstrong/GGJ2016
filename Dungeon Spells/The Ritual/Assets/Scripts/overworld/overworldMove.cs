using UnityEngine;
using System.Collections;

public class overworldMove : MonoBehaviour
{
    public float moveAmount;
    public float moveSpeed;

    private new SpriteRenderer renderer;
    public Vector3 targetPosition;
    private Vector3 beginPosition;
    private float timeSpentMoving;
    private bool bIsMoving;
    private float journeyLength;

    //Arrays to hold the sprites
    public Sprite[] up = new Sprite[0];
    public Sprite[] left = new Sprite[0];
    public Sprite[] down = new Sprite[0];
    public Sprite[] right = new Sprite[0];

    // Use this for initialization
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        targetPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //checking the possible moves
        if (!bIsMoving)
        {
            if (Input.GetKey(KeyCode.W))
            {
                //check up
                RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.up, moveAmount);
                if (hit.collider == null)
                {
                    targetPosition += Vector3.up * moveAmount;
                    initMovement();
                }
            }
            else if (Input.GetKey(KeyCode.S))
            {
                //check down
                RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.down, moveAmount);
                if (hit.collider == null)
                {
                    targetPosition += Vector3.down * moveAmount;
                    initMovement();
                }
            }
            else if (Input.GetKey(KeyCode.A))
            {
                //check left
                RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.left, moveAmount);
                if (hit.collider == null)
                {
                    targetPosition += Vector3.left * moveAmount;
                    initMovement();
                }
            }
            else if (Input.GetKey(KeyCode.D))
            {
                //check right
                RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.right, moveAmount);
                if (hit.collider == null)
                {
                    targetPosition += Vector3.right * moveAmount;
                    initMovement();
                }
            }
        }

        //if the character is moving, gradually lerp them to their target
        if (bIsMoving)
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
        journeyLength = Vector3.Distance(transform.position, targetPosition);
    }
}