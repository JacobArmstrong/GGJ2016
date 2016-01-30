using UnityEngine;
using System.Collections;

public class overworldMove : MonoBehaviour {

    public bool isTurn = true;
    public float moveScale = 1.0f;
    public float waitTime = 0.75f;
    private float timer = 0.0f;

    // Use this for initialization
    void Start ()
    {
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        timer += 1.0f * Time.deltaTime;
        if(isTurn)
        {
            BoxCollider2D body = GetComponent<BoxCollider2D>();
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
	}
}
