using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float playerSpeed;
    public DialogManager dialogManager;
    public float diagonalMoveModifier;

    private GameObject player;
    public Rigidbody2D myRigidBody;
    private Animator anim;
    private bool heroIdleDown, heroIdleUp, heroIdleLeft, heroIdleRight;
    private bool dialogActive;
    private int hAxis;
    private int vAxis;
    public bool playerMoving;
    public Vector2 lastMove;
    private float currentMoveSpeed;
    public bool usingPower;

    private void Awake ()
    {
       
    }

    void Start () {
        player = this.gameObject;
        anim = player.GetComponent<Animator>();
        dialogManager = FindObjectOfType<DialogManager>();
        myRigidBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        dialogActive = dialogManager.isActive;
        playerMoving = false;
        Walk();
    }

    void Walk ()
    {
        

        if (!dialogActive)
        {
            if (!usingPower)
            {
                // Walk Horizontally
                if (Input.GetAxisRaw("Horizontal") > .5f || Input.GetAxisRaw("Horizontal") < -.5f)
                {
                    ConvertAxis();
                    myRigidBody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * playerSpeed * Time.deltaTime, myRigidBody.velocity.y);
                    playerMoving = true;
                    lastMove = new Vector2(hAxis, 0);
                }
                else
                {
                    hAxis = 0;
                    myRigidBody.velocity = new Vector2(0, myRigidBody.velocity.y);
                }

                // Walk Vertically
                if (Input.GetAxisRaw("Vertical") > .5f || Input.GetAxisRaw("Vertical") < -.5f)
                {
                    ConvertAxis();
                    myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, Input.GetAxisRaw("Vertical") * playerSpeed * Time.deltaTime);
                    playerMoving = true;
                    lastMove = new Vector2(0, vAxis);
                }
                else
                {
                    vAxis = 0;
                    myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, 0);
                }

                // Diagonal Movement
                if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) > .5f && Mathf.Abs(Input.GetAxisRaw("Vertical")) > .5f)
                {
                    currentMoveSpeed = playerSpeed / diagonalMoveModifier;
                }
                else
                {
                    currentMoveSpeed = playerSpeed;
                }

            }

            if (usingPower)
            {
                myRigidBody.velocity = new Vector2(0, 0);
            }
        }

        anim.SetFloat("MoveX", hAxis);
        anim.SetFloat("MoveY", vAxis);
        anim.SetBool("PlayerMoving", playerMoving);
        anim.SetFloat("LastMoveX", lastMove.x);
        anim.SetFloat("LastMoveY", lastMove.y);


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
