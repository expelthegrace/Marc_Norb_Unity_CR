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
        Debug.Log("fitxer guardat a disk");
        listData = new List<DataPack>();
        listData.Add(dataP);

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/data.LUL");
        bf.Serialize(file, listData);
        file.Close();
    }

    public DataPack Load()  // retorna un DataPack amb les dades 
    {
        DataPack dataP = new DataPack();
        if (File.Exists(Application.persistentDataPath + "/data.LUL"))
        {
            Debug.Log("fitxer carregat");
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/data.LUL", FileMode.Open);
            List<DataPack> l =  (List<DataPack>)bf.Deserialize(file);
            dataP = l[0];
            file.Close();
        }
        else
        {
            Debug.Log("fitxer no carregat");   
            dataP.totalcoins = 50;
            dataP.playerSelect = 1;
            dataP.avatar2 = false;
            dataP.avatar3 = false;
            dataP.best1 = 0;
            dataP.best2 = 0;
            dataP.best3 = 0;
        }

        return dataP;
    }

    public void ClearData()
    {
        File.Delete(Application.persistentDataPath + "/data.LUL");
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
    public int best3;
}
