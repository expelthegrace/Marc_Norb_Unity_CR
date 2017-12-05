using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class saveLoad : MonoBehaviour {

    DataPack datapack;

    List<DataPack> listData;

    public void Save(DataPack dataP) // li passem un DataPack i el guarda
    {
        listData = new List<DataPack>();
        listData.Add(dataP);

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/data.LUL");
        bf.Serialize(file, listData);
        file.Close();
    }

    public DataPack Load()
    {
        DataPack dataP = new DataPack();
        if (File.Exists(Application.persistentDataPath + "/data.LUL"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/savedGames.gd", FileMode.Open);
            List<DataPack> l =  (List<DataPack>)bf.Deserialize(file);
            dataP = l[0];
            file.Close();
        }

        return dataP;
    }

    
}

[System.Serializable]
public class DataPack
{
    public int totalcoins;
    public int playerSelect;

    public bool avatar2;
    public bool avatar3;

    public int best1;
    public int best2;
}
