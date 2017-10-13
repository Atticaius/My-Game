using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour {

    private static PlayerSpawner playerSpawner = null;
    public GameObject player;

    void Awake ()
    {
        // Prevents duplication
        if (playerSpawner == this)
        {
            playerSpawner = this;
            DontDestroyOnLoad(gameObject);

        }
        else if (playerSpawner != null &&  playerSpawner != this)
        {
            Destroy(gameObject);
        }
    }
    // Use this for initialization
    void Start () {
        if (GameState.state.wasLoaded)
        {
            Instantiate(player, transform.position = new Vector3(GameState.state.playerX, GameState.state.playerY), Quaternion.identity);
        } else
        {
            Instantiate(player, transform.position, Quaternion.identity);
        }
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
