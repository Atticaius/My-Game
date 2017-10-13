using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour {

    public static GameState state; // Creates an Instance of this class so it can be called from other scripts
    public float playerX;
    public float playerY;
    public string playerScene;
    public bool wasLoaded = false;
    public bool wasSaved = false;

    void Awake ()
    {
        // Prevents duplication
        if (state == null)
        {
            DontDestroyOnLoad(gameObject);
            state = this;
        } else if (state != this)
        {
            Destroy(gameObject);
        }
    }

    void Start ()
    {
        
    }

    public void Save ()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/Save.save");

        PlayerData data = new PlayerData();
        data.playerX = playerX;
        data.playerY = playerY;
        data.playerScene = playerScene;
        data.wasSaved = wasSaved;
        Debug.Log(playerScene);
        formatter.Serialize(file, data);
        
        file.Close();

        
    }

    public void Load ()
    {
        if (File.Exists(Application.persistentDataPath + "/Save.save"))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/Save.save", FileMode.Open);
            PlayerData data = (PlayerData)formatter.Deserialize(file);
            file.Close();

            playerX = data.playerX;
            playerY = data.playerY;
            playerScene = data.playerScene;
            wasSaved = data.wasSaved;
            wasLoaded = true;
            Debug.Log(wasSaved);
            
                LevelManager.levelManager.LoadLevel(playerScene);
        }
        else
        {
            Debug.Log("No Save");
        }
    }

    public void Delete ()
    {
        if (File.Exists(Application.persistentDataPath + "/Save.save"))
        {
             
            File.Delete(Application.persistentDataPath + "/Save.save");
            wasSaved = false;
            Debug.Log("Save deleted");
        }
    }
    
}

    [Serializable]
    class PlayerData
    {
        public float playerX;
        public float playerY;
        public string playerScene;
        public bool wasSaved;
    }


