using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour {

    public GameObject switchTarget;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerStay2D (Collider2D other)
    {
        if (other.tag == "MoveObject" || other.tag == "Player")
        {
            switchTarget.SetActive(false);
        }
    }

    void OnTriggerExit2D (Collider2D other)
    {
        if (other.tag == "MoveObject" || other.tag == "Player")
        {
            switchTarget.SetActive(true);
        }
    }
}
