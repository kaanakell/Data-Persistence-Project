using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class SecondManager : MonoBehaviour
{
    public static SecondManager Instance;

    public string newName;
    public int highScore;
    public string oldName;


    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        //LoadHighScore();
    }

    /*public void NewNameEntered(string name)
    {
        SecondManager.Instance.enterName = name;
    }*/

    [System.Serializable]
    class SaveData
    {
        public string newName;
        public int highScore;
    }

    public void SaveHighScore()
    {
        SaveData data = new SaveData
        {
            highScore = highScore,
            newName = newName
        };
        

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            newName = data.newName;
            highScore = data.highScore;
        }
    }


}
