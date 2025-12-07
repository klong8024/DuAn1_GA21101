using System.IO;
using UnityEngine;
using System;
using Newtonsoft.Json;

public class FileDataHandler 
{
    private string fullPath;
    private bool encryptData;
    private string codeWord = "DuAn1";

    public FileDataHandler(string dataDirPath, string dataFileName, bool encryptData)
    {
        fullPath = Path.Combine(dataDirPath, dataFileName);
        this.encryptData = encryptData;
    }

    public void SaveData(GameData gameData)
    {
        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(fullPath));

            //string dataToSave = JsonUtility.ToJson(gameData, true);
            string dataToSave = JsonConvert.SerializeObject(gameData, Formatting.Indented);

            if (encryptData)
                dataToSave = EncryptDecrypt(dataToSave);

            using (FileStream stream = new FileStream(fullPath, FileMode.Create))
            {
                using (StreamWriter write = new StreamWriter(stream))
                {
                    write.Write(dataToSave);
                }
            }
        }

        catch (Exception e)
        {
            Debug.LogError("Error on trying to save data to file: " + fullPath + "\n" + e);
        }
    }

    public GameData LoadData()
    {
        GameData loadData = null;

        if(File.Exists(fullPath))
        {
            try
            {
                string dataToLoad = "";

                using (FileStream stream = new FileStream(fullPath, FileMode.Open))
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        dataToLoad = reader.ReadToEnd();
                    }
                }

                if(encryptData)
                    dataToLoad = EncryptDecrypt(dataToLoad);

                //loadData = JsonUtility.FromJson<GameData>(dataToLoad);
                loadData = JsonConvert.DeserializeObject<GameData>(dataToLoad);
            }

            catch (Exception e)
            {
                Debug.LogError("Error on trying to load data to file: " + fullPath + "\n" + e);
            }
        }

        return loadData;
    }

    public void Delete()
    {
        if(File.Exists(fullPath))
            File.Delete(fullPath);
    }

    private string EncryptDecrypt(string data)
    {
        string modifiedData = "";

        for(int i = 0; i < data.Length; i++)
        {
            modifiedData += (char)(data[i] ^ codeWord[i % codeWord.Length]);
        }

        return modifiedData;
    }
}
