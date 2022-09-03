using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    public String playerName;

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
        public String playerName;
    }
    
}
