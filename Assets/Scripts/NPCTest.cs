using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCTest : MonoBehaviour {

    public DialogManager dialogManager;
    public bool dialogOpen = false;
    public String NPCText;
    public DialogText dialogText;

    private float timePassed;
    private float keyDelay = 1.5f;
	// Use this for initialization
	void Start () {
        dialogManager = FindObjectOfType<DialogManager>();
        
        NPCText = "Hey!";
	}
	
	// Update is called once per frame
	void Update () {
        dialogOpen = dialogManager.isActive;
	}

    private void OnTriggerStay2D (Collider2D collision)
    {
        if (Input.GetKey(KeyCode.Return) && dialogOpen == false)
        { 

            dialogManager.ShowBox();
            NPCText = "Hey!";
            dialogText.GetComponent<Text>().text = NPCText;
            dialogOpen = true;
            if (dialogManager.isActive == false)
            {
                dialogOpen = false;
                dialogManager.HideBox();
            }
        }
    }
}
