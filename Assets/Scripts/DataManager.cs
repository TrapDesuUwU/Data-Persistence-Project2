using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

    public int maxScore;

    public string nameMaxScore;

    public string currentName;

    // Start is called before the first frame update
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadScore();
    }

    [System.Serializable]
    class SaveData
    {
        public int maxScore;

        public string nameMaxScore;
    }

    public void SaveScore()
    {
        SaveData data = new SaveData();
        data.maxScore = maxScore;
        data.nameMaxScore = nameMaxScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            maxScore = data.maxScore;
            nameMaxScore = data.nameMaxScore;
        }
    }

}
