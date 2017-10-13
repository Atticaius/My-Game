using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogManager : MonoBehaviour {

    public GameObject dialogBox;
    public GameObject dialogText;
    public bool isActive = false;

    public float timePassed = 0f;
    public float keyDelay = 1f;
    
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        DialogBox();
    }

    public void ShowBox ()
    {
        isActive = true;
        if (isActive)
        {
            dialogBox.gameObject.SetActive(true);
        }
    }

    public void HideBox ()
    {
        isActive = false;
        dialogBox.gameObject.SetActive(false);
    }

    void DialogBox ()
    {
        if (isActive == true)
        {
            timePassed += Time.deltaTime;
            if (timePassed >= keyDelay && Input.GetKey(KeyCode.Return))
            {
                timePassed = 0f;
                isActive = false;
            }
        }

        if (!isActive)
        {
            dialogBox.gameObject.SetActive(false);
        }
    }
}
