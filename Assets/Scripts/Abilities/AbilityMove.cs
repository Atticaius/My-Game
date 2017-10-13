using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityMove : MonoBehaviour {

    public float directionToFaceX;
    public float directionToFaceY;

    private Rigidbody2D myRigidBody;
    private GameObject player;
    private Rigidbody2D objectToMove;
    private PlayerMovement playerMovement;

    private float playerLastMoveX;
    private float playerLastMoveY;
    private float playerPosX;
    private float playerPosY;
    private float timeToMoveCounter;
    private bool objectInMotion;
    private int hAxis;
    private int vAxis;
    private float moveSpeed;
    private float timeToMove;

    // Use this for initialization
    void Start () {
        GetComponent<Rigidbody2D>();
        objectToMove = GetComponentInParent<Rigidbody2D>();
        timeToMove = GetComponentInParent<AbilityMoveSpeed>().timeToMove;
        timeToMoveCounter = timeToMove;
        moveSpeed = GetComponentInParent<AbilityMoveSpeed>().moveSpeed;

	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Return) && playerMovement.usingPower)
        {
            playerMovement.usingPower = false;
        }
        MoveObject();
       
    }

    void OnTriggerStay2D (Collider2D other)
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerMovement = player.GetComponent<PlayerMovement>();
        playerPosX = player.transform.position.x;
        playerPosY = player.transform.position.y;
        playerLastMoveX = playerMovement.lastMove.x;
        playerLastMoveY = playerMovement.lastMove.y;
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.JoystickButton0))
        {
            if (playerLastMoveX == directionToFaceX && playerLastMoveY == directionToFaceY)
            {
                playerMovement.usingPower = true;
            }
        }
    }

    void MoveObject ()
    {
        if (playerMovement.usingPower)
        {
            if (Input.GetAxisRaw("Vertical") > .5 || Input.GetAxisRaw("Vertical") < -.5f)
            {
                
                if (timeToMoveCounter > 0 && !objectInMotion)
                {
                    ConvertAxis();
                    objectInMotion = true;
                    objectToMove.velocity = new Vector2(0, vAxis * moveSpeed * Time.deltaTime);
                }
            }
            if (Input.GetAxisRaw("Horizontal") > .5f || Input.GetAxisRaw("Horizontal") < -.5f)
            {
                
                if (timeToMoveCounter > 0 && !objectInMotion)
                {
                    ConvertAxis();
                    objectInMotion = true;
                    objectToMove.velocity = new Vector2(hAxis * moveSpeed * Time.deltaTime, 0);
                }
            }
        }   
        
        if (objectInMotion)
        {
                timeToMoveCounter -= Time.deltaTime;   
        }

        if (timeToMoveCounter <= 0) 
        {
            objectToMove.velocity = Vector2.zero;
            playerMovement.usingPower = false;
            objectInMotion = false;
            timeToMoveCounter = timeToMove;
        }

        if (playerMovement.usingPower == false)
        {
            timeToMoveCounter = timeToMove;
        }
    }

    void ConvertAxis ()
    {
        if (Input.GetAxisRaw("Horizontal") > .1f)
        {
            hAxis = 1;
        }

        if (Input.GetAxisRaw("Horizontal") < -.1f)
        {
            hAxis = -1;
        }

        if (Input.GetAxisRaw("Vertical") > .1f)
        {
            vAxis = 1;
        }

        if (Input.GetAxisRaw("Vertical") < -.1f)
        {
            vAxis = -1;
        }
    }
}
