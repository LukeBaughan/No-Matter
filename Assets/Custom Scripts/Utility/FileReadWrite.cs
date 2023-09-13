using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class FileReadWrite
{

    public static void Write(Game game)
    {
        BinaryFormatter bf = new BinaryFormatter();
        // Creates a save file 
        FileStream file = File.Create(Application.persistentDataPath + "/saveFile.save");
        // Converts the data to a byte array and closes the file
        bf.Serialize(file, game);
        file.Close();
    }

    public static Game Read()
    {
        // If there is a save file, open it and seserializes the data
        if (File.Exists(Application.persistentDataPath + "/saveFile.save"))
        {
            BinaryFormatter bf = new BinaryFormatter();

            FileStream file = File.Open(Application.persistentDataPath + "/saveFile.save", FileMode.Open);
            Game game = (Game)bf.Deserialize(file);
            file.Close();
            return game;
        }
        else
        {
            Game game = new Game();
            return game;
        }
    }
}
