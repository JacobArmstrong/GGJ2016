using UnityEngine;
using System.Collections;

public class overworldMove : MonoBehaviour
{
    public float moveAmount;
    public float moveSpeed;

    //deal with sprite animation
    private int spriteIndex;
    private float spriteTimer;
    public float animationWaitTime;

    private new SpriteRenderer renderer;
    public Vector3 targetPosition;
    private Vector3 beginPosition;
    private float timeSpentMoving;
    private bool bIsMoving;

    //Arrays to hold the sprites
    public Sprite[] animationSet;
    public Sprite[] up = new Sprite[0];
    public Sprite[] left = new Sprite[0];
    public Sprite[] down = new Sprite[0];
    public Sprite[] right = new Sprite[0];

    // Use this for initialization
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        targetPosition = transform.position;
        spriteIndex = 0;
        renderer.sprite = down[spriteIndex];
        spriteTimer = animationWaitTime;
    }

    // Update is called once per frame
    void Update()
    {
        //alarm for sprite animation change
        spriteTimer -= Time.deltaTime;

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
                    animationSet = up;
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
                    animationSet = down;
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
                    animationSet = left;
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
                    animationSet = right;
                }
            }
        }

        //if the character is moving, gradually lerp them to their target
        else
        {
            timeSpentMoving += Time.deltaTime;

            if (transform.position != targetPosition)
            {
                float distCovered = timeSpentMoving / moveSpeed;
                float fracJourney = distCovered / moveAmount;
                transform.position = Vector3.Lerp(beginPosition, targetPosition, fracJourney);
                if(spriteTimer <= 0)
                {
                    if (++spriteIndex > 3)
                    {
                        spriteIndex = 0;
                    }
                    renderer.sprite = animationSet[spriteIndex];
                    spriteTimer = animationWaitTime;
                }
                
            }
            else
            {
                bIsMoving = false;
                timeSpentMoving = 0.0f;
                targetPosition = transform.position;
                spriteIndex = 0;
                renderer.sprite = animationSet[spriteIndex];
            }
        }
    }

    void initMovement()
    {
        bIsMoving = true;
        beginPosition = transform.position;
    }
}