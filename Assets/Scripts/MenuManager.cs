using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;
    public string namePlayers;
    public int scorePlayers;
    public string nameBestScore;
    public int scoreBestScore;

   
    private void Awake()
    {
        // start of new code
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        // end of new code
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadScore();
    }
    public void SaveScore()
    {
        SaveData data = new SaveData();
        LoadScore();

        if (scoreBestScore < scorePlayers)
        {
            data.namePlayer = namePlayers;
            data.scorePLayer = scorePlayers;
            nameBestScore = namePlayers;
            scoreBestScore = scorePlayers;
            Debug.Log("Salvataggio dati");
            string json = JsonUtility.ToJson(data);

             File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        }
        
       
    }
    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        Debug.Log("load " + Application.persistentDataPath); 
        if (File.Exists(path))
        {
            Debug.Log("il file esiste");
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            nameBestScore = data.namePlayer;
            scoreBestScore = data.scorePLayer;
        }
    }

    [System.Serializable]
    class SaveData
    {
        public string  namePlayer;
        public int scorePLayer;
    }
}
