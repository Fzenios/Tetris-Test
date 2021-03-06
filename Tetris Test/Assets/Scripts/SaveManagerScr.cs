using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveManagerScr : MonoBehaviour
{
    public HighScoresObject highScoresObject;
    string SaveDataName = "/Save.dat";

    public void Save()
    {
        FileStream file = new FileStream(Application.persistentDataPath + SaveDataName, FileMode.OpenOrCreate);
        BinaryFormatter formatter = new BinaryFormatter();

        formatter.Serialize(file, highScoresObject.dataForSaving);

        Debug.Log("egine to save");

        file.Close();
    }

    public void Load()
    {
        string path = Application.persistentDataPath + SaveDataName;

        if (File.Exists(path))
        {
            FileStream file = new FileStream(Application.persistentDataPath + SaveDataName, FileMode.Open);
            BinaryFormatter formatter = new BinaryFormatter();

            highScoresObject.dataForSaving = (HighScoresObject.DataForSaving)formatter.Deserialize(file);

            Debug.Log("egine to load");

            file.Close();
        }
    }
}
