using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public string playerName;
    public int highScore;
    
    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        DontDestroyOnLoad(gameObject);



        //Barrier for readability



        LoadInfo();
    }

    [System.Serializable]
    public class SaveData
    {
        public string name;
        public int highScore;
    }

    public void SaveInfo()
    {
        SaveData data = new SaveData();

        //highScore = 0;

        //playerName = null;

        data.name = playerName;

        data.highScore = highScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadInfo()
    {
        SaveData data = new SaveData();

        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            
            data = JsonUtility.FromJson<SaveData>(json);

            playerName = data.name;

            highScore = data.highScore;
        }

    }
}
