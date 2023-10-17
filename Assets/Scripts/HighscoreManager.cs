using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class HighscoreManager : MonoBehaviour
{
    public string newPlayerName = string.Empty;
    public string playerName = string.Empty;
    public int highscore = 0;

    public static HighscoreManager Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadHighscore();
    }

    [Serializable]
    class SaveData
    {
        public string playerName;
        public int highscore;
    }

    public void SaveHighscore()
    {
        SaveData data = new SaveData();

        data.playerName = playerName;
        data.highscore = highscore;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/highscore.json", json);
    }

    public void LoadHighscore()
    {
        string path = Application.persistentDataPath + "/highscore.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highscore = data.highscore;
            playerName = data.playerName;
        }
    }
}
