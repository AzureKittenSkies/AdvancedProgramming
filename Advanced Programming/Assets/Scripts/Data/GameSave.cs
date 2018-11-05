using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//---XML Saving namespaces---//
using System.Xml; // Includes XML classes
using System.Xml.Serialization; // Includes ability to 'serialize' classes
using System.IO; // Adds file io functionality

using System;

/*
[XmlRoot("Game Data")]
public class GameData
{
    //---All game data able to be saved to a file---//
    public Vector3 playerPosition;
    public int score;

    public void Save(string filePath)
    {
        // Create a tool for converting class into XML
        XmlSerializer serializer = new XmlSerializer(typeof(GameData));
        // Generate a file stream and open file stream to path
        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            // Save file to path
            serializer.Serialize(stream, this);
        }
    }

    public void Load(string filePath)
    {
        // Only if the file exists at the path
        if (File.Exists(filePath))
        {
            // Create a tool for converting XML into class
            XmlSerializer serializer = new XmlSerializer(typeof(GameData));
            // Generate a file stream with the mode 'Open' to read file
            using (var stream = new FileStream(filePath, FileMode.Open))
            {
                // Deserialize
                GameData data = serializer.Deserialize(stream) as GameData;
                //------Load the game data values here-----//
                playerPosition = data.playerPosition;
                score = data.score;
            }
        }
    }
}
*/

[Serializable]
public class GameData
{
    public Vector3 playerPosition;
    public int score;
}

public class GameSave : MonoBehaviour
{
    #region Singleton
    public static GameSave Instance = null;
    private void Awake()
    {
        Instance = this;
        Load(); // Try to load the Game Data
    }
    public static GameData GetData()
    {
        return Instance.data;
    }
    #endregion

    public GameData data = new GameData();
    public string fileName = "GameSave";

    public void Save()
    {
        string fullPath = Application.dataPath + "/Data/" + fileName + ".json";
        // C:/Users/Manny/AppData/Local/CompanyName/ProductName/GameSave.xml
        //data.Save(fullPath);
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(fullPath, json);

        // Display where the file saved
        print("Saved to path: " + fullPath);
    }

    public void Load()
    {
        string fullPath = Application.dataPath + "/Data/" + fileName + ".json";
        // C:/Users/Manny/AppData/Local/CompanyName/ProductName/GameSave.xml
        //data.Load(fullPath);
        string json = File.ReadAllText(fullPath);
        data = JsonUtility.FromJson<GameData>(json);
        // Display where the file saved
        print("Loaded from path: " + fullPath);
    }

    public static bool Exists()
    {
        string fullPath = Application.dataPath + "/Data/" + Instance.fileName + ".json";
        return File.Exists(fullPath);
    }
}
