using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hearts : MonoBehaviour {

    public static Hearts heart;
    public Sprite[] heartSprites;
    
    private int healthPerHeart = 2;
    public int healthRemaining = 2;
    
    public bool isCollected;
    public int heartNumber;

    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void Update () {
        if (isCollected)
        {
            GetComponent<Image>().enabled = true;
            if (healthRemaining == 2)
            {
                GetComponent<Image>().sprite = heartSprites[2];
            }
            else if (healthRemaining == 1)
            {
                GetComponent<Image>().sprite = heartSprites[1];
            }
            else if (healthRemaining == 0)
            {
                GetComponent<Image>().sprite = heartSprites[0];
            }
        } else
        {
            GetComponent<Image>().enabled = false;
        }
    }

    public void FillHeart()
    {
        healthRemaining = 2;
    }
}
	

