using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerState : MonoBehaviour {

    void Update ()
    {
        SaveOrLoad();    
    }

    void SaveOrLoad ()
    {
        if (Input.GetKeyDown(KeyCode.F5))
        {
            GameState.state.playerX = this.transform.position.x;
            GameState.state.playerY = this.transform.position.y;
            GameState.state.playerScene = LevelManager.levelManager.CurrentScene();
            GameState.state.wasSaved = true;
            GameState.state.Save();
            
            Debug.Log("Game Saved");
        }

        if (Input.GetKeyDown(KeyCode.F7))
        {
            GameState.state.Load();
            transform.position = new Vector2(GameState.state.playerX, GameState.state.playerY);
            Debug.Log("Game Loaded");
        }
    }
}
