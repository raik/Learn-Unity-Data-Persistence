using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    public string currentPlayerName;
    public string topPlayerName;
    public int topScore;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [System.Serializable]
    class SaveData
    {
        public string topPlayerName;
        public int topScore;
    }
    
    public void SaveTopScore()
    {
        SaveData data = new SaveData();
        
        data.topPlayerName = topPlayerName;
        data.topScore = topScore;
        Debug.Log(Application.persistentDataPath);
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadTopScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            
            topPlayerName = data.topPlayerName;
            topScore = data.topScore;
        }
 
    }

}
