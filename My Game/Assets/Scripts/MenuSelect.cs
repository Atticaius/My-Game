using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSelect : MonoBehaviour
{

    public int numOptions;
    public float inputTimer;
    private float cursorY;
    public int index;

    private int offset = 45;
    public float inputTimerCounter;
    private LevelManager levelManager;
    private GameState gameState;
    private GameObject selectionArrow;
    public bool dpadPressed = false;

    // Use this for initialization
    void Start ()
    {
        selectionArrow = this.gameObject;
        levelManager = FindObjectOfType<LevelManager>();
        gameState = FindObjectOfType<GameState>();
        index = 0;
        inputTimerCounter = inputTimer;
    }

    // Update is called once per frame
    void Update ()
    {
        
        if (index < numOptions - 1)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                index++;
                selectionArrow.transform.position += Vector3.down * offset;
            }
            if (Input.GetAxis("VerticalDpad") <= -1f && dpadPressed == false)
            {
                
                    dpadPressed = true;
                    Debug.Log(Input.GetAxis("VerticalDpad"));
                    if (dpadPressed == true)
                    {
                        index++;
                        selectionArrow.transform.position += Vector3.down * offset;
                    }
                
            }

        }

        if (index > 0)
        {
            if (Input.GetKeyUp(KeyCode.UpArrow))
            {
                index--;
                selectionArrow.transform.position += Vector3.up * offset;
            }

            if (Input.GetAxis("VerticalDpad") >= 1f && dpadPressed == false)
            {
                dpadPressed = true;
                if (dpadPressed == true)
                {
                    index--;
                    selectionArrow.transform.position += Vector3.up * offset;
                }
            }
            
        }

        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.JoystickButton0))
        {
            switch(index)
            {
                case 0:
                    levelManager.LoadLevel("Game");
                    return;
                case 1:
                    gameState.Load();
                    return;
                case 2:
                    gameState.Delete();
                    return;
            }
        }

        if (dpadPressed == true)
        {
            inputTimerCounter -= Time.deltaTime;
            if (inputTimerCounter <= 0)
            {
                dpadPressed = false;
                inputTimerCounter = inputTimer;
            }
        }


    }

    void JoystickAsButton ()
    {
        if (Input.GetAxisRaw("VerticalDpad") != 0) {
            if (dpadPressed == false)
            {
                dpadPressed = true;
            }
        }

        if (Input.GetAxisRaw("VerticalDpad") ==0)
        {
            dpadPressed = false;
        }
    }

    /*
     * Have default option selected
     * Scroll down on vertical down, up on vertical up
     * Move cursor with selection
     * Load gamestate depending on selection
     *  - New Game: LevelManager.LoadLevel "Game"
     *  - Load Game: GameState.Load
     *  - Delete: GameState.Delete
     * Variables:
     *  - Currently selected option = index: increases when pressing down, decreases when pressing up
     *  - Cursor position y
     *
     */
}


