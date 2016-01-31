using UnityEngine;
using System.Collections;

public class overworldMove : MonoBehaviour
{

    public bool isTurn = true;
    public float moveScale = 1.0f;
    public float waitTime = 0.75f;
    private int index;

    public float timeBetweenSprites;
    private float timer;

    private SpriteRenderer renderer;

    public Sprite[] up = new Sprite[0];
    public Sprite[] left = new Sprite[0];
    public Sprite[] down = new Sprite[0];
    public Sprite[] right = new Sprite[0];

    private Transform body;
    // Use this for initialization
    void Start ()
    {
        Transform body = GetComponent<Transform>();
        timer = timeBetweenSprites;
        renderer.GetComponent<SpriteRenderer>();
        renderer.sprite = down[0];
    }
	
	// Update is called once per frame
	
    void Update()
    {
        timer -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.W))
        {
            
        }

        if (Input.GetKeyDown(KeyCode.A))
        {

        }

        if (Input.GetKeyDown(KeyCode.S))
        {

        }

        if (Input.GetKeyDown(KeyCode.D))
        {

        }

    }











    /*void Update ()
    {
        timer += Time.deltaTime;
        if(isTurn)
        {
            if (timer > waitTime)
            {
                if (Input.GetKeyDown(KeyCode.W))
                {
                    body.transform.position += Vector3.up * moveScale;
                    timer = 0.0f;
                }
            if (timer > waitTime)
            {
                if (Input.GetKeyDown(KeyCode.A))
                {
                    body.transform.position += Vector3.left * moveScale;
                    timer = 0.0f;
                }
            }
            if (timer > waitTime)
            {
                if (Input.GetKeyDown(KeyCode.S))
                {
                    body.transform.position += Vector3.down * moveScale;
                    timer = 0.0f;
                }
            }
            if (timer > waitTime)
            {
                if (Input.GetKeyDown(KeyCode.D))
                {
                    body.transform.position += Vector3.right * moveScale;
                    timer = 0.0f;
                }
            }
            }
        }
	}*/
}
