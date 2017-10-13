using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartBar : MonoBehaviour {

    public static HeartBar heartBar;
    public Image[] heartImages;

    public int numHeartsCollected;
    public static int totalHeartsCollected;
    private int heartNumber = 0;
    private int maxHearts;

    // Use this for initialization
    void Start () {
        numHeartsCollected = 2;
	}
	
	// Update is called once per frame
	void Update () {
        
        for (int i = 0; i <= numHeartsCollected; i++)
        {
            if (i <= numHeartsCollected)
            {
                heartNumber = i;
                heartImages[heartNumber].GetComponent<Hearts>().isCollected = true;
                heartImages[heartNumber].GetComponent<Image>().enabled = true;   
            }
            else
            {
                heartNumber = i;
                heartImages[heartNumber].GetComponent<Image>().enabled = false;
            }
        }
        
    }

    public void TakeDamage()
    {

        int heartToDamage = heartNumber;
        int heartHealth = heartImages[heartToDamage].GetComponent<Hearts>().healthRemaining;
        if (heartHealth > 0)
        {
            heartImages[heartToDamage].GetComponent<Hearts>().healthRemaining--;
        }
        else
        {
            if (heartToDamage >= numHeartsCollected)
            {
                heartToDamage--;
                heartImages[heartToDamage].GetComponent<Hearts>().healthRemaining--;
            }
            
        }
    }

    public void HealDamage()
    {
        int heartToHeal = heartNumber - 1;
        int heartHealth = heartImages[heartToHeal].GetComponent<Hearts>().healthRemaining;
        if (heartHealth < 2)
        {
            heartImages[heartToHeal].GetComponent<Hearts>().healthRemaining++;
        }
        else
        {
            if (heartToHeal <= numHeartsCollected)
            {
                heartToHeal++;
                heartImages[heartToHeal].GetComponent<Hearts>().healthRemaining++;
            }
            
        }
    }

    public void CollectHeart()
    {
        numHeartsCollected++;
        int heartHeal = 0;
        for (int i = 0; i < numHeartsCollected; i++)
        {
            heartImages[heartHeal].GetComponent<Hearts>().FillHeart();
            heartHeal++;
            
            heartImages[i].GetComponent<Hearts>().isCollected = true;
        }
        
        
    }
}
