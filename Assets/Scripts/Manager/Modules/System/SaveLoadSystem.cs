using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class SaveLoadSystem : Sington<SaveLoadSystem>
{
    public UnityEvent<bool> saveEvent;
    public UnityEvent<bool> loadEvent;
    public UnityEvent<PlayRecodeData> loadDataEvent;

    public PlayRecodeData saveLoadOptionData;
    public SaveLoadPathData saveLoadPathData;


    protected override void Awake()
    {
        base.Awake();

        Load();
    }

    public bool Load()
    {
        var success = false;

        Debug.Log($"Save Path :: {Application.persistentDataPath}");

        string destination = Application.persistentDataPath + $"/{saveLoadPathData.SaveFileName}.json";

        if (System.IO.File.Exists(destination))
        {
            try
            {
                var file = System.IO.File.ReadAllText(destination);
                saveLoadOptionData = JsonUtility.FromJson<PlayRecodeOptionData>(file);
                success = true;
            }
            catch (Exception e)
            {
                Debug.LogError(e.Message);
            }
        }
        else
        {
            Debug.LogWarning($"[SaveLoadSystem] :: {saveLoadPathData.SaveFileName}.dat is not found");
        }

        loadEvent?.Invoke(success);
        if (success)
        {
            loadDataEvent?.Invoke(saveLoadOptionData);
        }

        return success;
    }

    public bool Save()
    {
        var success = false;

        Debug.Log(Application.persistentDataPath);

        try
        {
            if (saveLoadOptionData != null)
            {
                var dataPersistences = FindAllDataPersistences();
                foreach (IDataPersistence dataPersistenceObj in dataPersistences)
                {
                    dataPersistenceObj.SaveData(ref saveLoadOptionData);
                }

                string destination = Application.persistentDataPath + $"/{saveLoadPathData.SaveFileName}.json";
                var jsonData = JsonUtility.ToJson(saveLoadOptionData);
                System.IO.File.WriteAllText(destination, jsonData);
                success = true;
            }
        }
        catch (Exception e)
        {
            Debug.LogError(e.Message);
        }

        saveEvent.Invoke(success);

        return success;
    }

    private List<IDataPersistence> FindAllDataPersistences()
    {
        IEnumerable<IDataPersistence> dataPersistences = FindObjectsOfType<MonoBehaviour>(true).OfType<IDataPersistence>();

        return new List<IDataPersistence>(dataPersistences);
    }
}
