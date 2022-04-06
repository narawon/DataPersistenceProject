using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;



public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    private const string DataFileName = "GameData.json";

    public string bestPlayerName;
    public string playerName;
    public int bestScore;

    private static GameData Data = new GameData();

    private void Awake()
    {
        

        if (Instance != null)
        {
            // To delete duplicated instances
            Debug.Log("Destroied: " + Instance);
            Destroy(gameObject);
            return;
        }


        
        
        
        Debug.Log("Created: " + Instance);
        LoadData();

        Instance = this;
        DontDestroyOnLoad(gameObject);

    }

    public void SaveData()
    {
        GameData data = new GameData();
        data.bestPlayerName = bestPlayerName;
        data.bestScore = bestScore;
        data.playerName = playerName;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/" + DataFileName, json);
    }

    public void LoadData()
    {
        string filePath = Application.persistentDataPath + "/" + DataFileName;
        
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            GameData data = JsonUtility.FromJson<GameData>(json);
            bestScore = data.bestScore;
            playerName = data.playerName;
            bestPlayerName = data.bestPlayerName;
        }

        //Debug.Log("Data Loaded");
    }

    [System.Serializable]
    public class GameData
    {
        public string playerName;
        public string bestPlayerName;
        public int bestScore; 
    }

}
