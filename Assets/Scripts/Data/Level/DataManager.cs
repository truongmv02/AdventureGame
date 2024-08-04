using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using System.IO;

using Newtonsoft.Json;
public class DataManager
{
    private static DataManager instance;
    private const string FILE_NAME = "Data.json";

    int levelOpen;
    List<Level> levels;
    private DataManager()
    {
        LoadData();
    }

    public static DataManager Instance()
    {
        instance = instance != null ? instance : new DataManager();
        return instance;
    }

    public int GetLevelOpen()
    {
        return levelOpen;
    }

    public Level GetLevel(int level)
    {
        var l = levels.Find(x => x.LevelNum == level);
        return l;
    }


    public void SetLevelOpen(int level)
    {
        levelOpen = level;
        var l = new Level() { Star = 0, LevelNum = level };
        levels.Add(l);
        SaveData();
    }

    public void SetStar(int level, int star)
    {
        var l = levels.Find(x => x.LevelNum == level);
        l.Star = star;
        SaveData();
    }

    private void SaveData()
    {
        /*  string s = JsonConvert.SerializeObject(this.data);
          File.WriteAllText(FILE_NAME, s);*/

        PlayerPrefs.SetInt("LevelOpen", levelOpen);
        var levelsString = JsonConvert.SerializeObject(levels);
        PlayerPrefs.SetString("Levels", levelsString);
    }

    private void LoadData()
    {
        //   string s = File.ReadAllText(FILE_NAME);
        // this.data = JsonConvert.DeserializeObject<GameData>(s);
        levelOpen = PlayerPrefs.GetInt("LevelOpen", 1);
        var levelsString = PlayerPrefs.GetString("Levels", "[{\"LevelNum\":1,\"Star\":0,\"Time\":0.0}]");
        levels = JsonConvert.DeserializeObject<List<Level>>(levelsString);
    }

}