﻿using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

[System.Serializable]
public class MemorySystemData
{
    public int bestLevel;
    public int bestScore;
    public int coins;

    public MemorySystemData()
    {
        bestLevel = 0;
        bestScore = 0;
        coins = 0;
    }
}

[System.Serializable]
public class MemorySystem
{
    public static void SaveFile(MemorySystemData p_data)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + "/save.bin";

        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream, p_data);

        stream.Close();

    }

    public static MemorySystemData LoadFile()
    {
        string path = Application.persistentDataPath + "/save.bin";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            MemorySystemData data = formatter.Deserialize(stream) as MemorySystemData;
            stream.Close();
            return data;
        }
        else
        {
            return null;
        }
    }

    public static void DeleteFile()
    {
        string path = Application.persistentDataPath + "/save.bin";

        if (File.Exists(path))
            File.Delete(path);
    }
}
