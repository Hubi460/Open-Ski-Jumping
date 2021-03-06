﻿using System.Collections.Generic;
using System.IO;
using CompCal;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.U2D;

public class DatabaseObject<T>
{
    private string fileName;
    private T data;
    private bool loaded;

    public T Data { get => data; set => data = value; }
    public bool Loaded { get => loaded; set => loaded = value; }

    public DatabaseObject(string fileName)
    {
        this.fileName = fileName;
        this.loaded = false;
    }

    public bool LoadData()
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, this.fileName);
        if (File.Exists(filePath))
        {
            string dataAsJson = File.ReadAllText(filePath);
            this.data = JsonConvert.DeserializeObject<T>(dataAsJson);
            this.loaded = true;
            return true;
        }
        this.loaded = false;
        return false;
    }

    public void SaveData()
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, this.fileName);
        string dataAsJson = JsonConvert.SerializeObject(this.data);
        File.WriteAllText(filePath, dataAsJson);
    }
}

public class DatabaseManager : MonoBehaviour
{
    public bool loadRoundInfoPresets;
    public DatabaseObject<List<RoundInfoPreset>> dbRoundInfoPresets = new DatabaseObject<List<RoundInfoPreset>>("presets.json");

    public bool loadCalendars;
    public DatabaseObject<List<CompCal.Calendar>> dbCalendars = new DatabaseObject<List<CompCal.Calendar>>("calendars.json");

    public bool loadCompetitors;
    public DatabaseObject<List<CompCal.Competitor>> dbCompetitors = new DatabaseObject<List<CompCal.Competitor>>("competitors.json");

    public bool loadHills;
    public DatabaseObject<HillProfile.AllData> dbHills = new DatabaseObject<HillProfile.AllData>("data.json");

    public bool loadSavesData;
    public SaveData dbSaveData;


    private void Awake()
    {
        if (loadCalendars) { dbCalendars.LoadData(); }
        if (loadCompetitors) { dbCompetitors.LoadData(); }
        if (loadHills) { dbHills.LoadData(); }
        if (loadRoundInfoPresets) { dbRoundInfoPresets.LoadData(); }

        if (loadSavesData)
        {
            this.dbSaveData = SavesSystem.Load();
            if (this.dbSaveData == null)
            {
                this.dbSaveData = new SaveData(-1, new List<GameSave>());
            }
        }
    }

    public void Save()
    {
        if (loadCalendars) { this.dbCalendars.SaveData(); }
        if (loadCompetitors) { this.dbCompetitors.SaveData(); }
        if (loadHills) { this.dbHills.SaveData(); }
        if (loadRoundInfoPresets) { dbRoundInfoPresets.SaveData(); }
        if (loadSavesData) { SavesSystem.Save(this.dbSaveData); }
    }

}
