using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class SaveLoadGame : MonoBehaviour
{
    [SerializeField] private LevelsStarsInstaller _starsInstaller;
    public static SaveLoadGame instance = null;
    private string _filePath;

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
        _filePath = Application.persistentDataPath + "/starsSave.gamesave";
    }

    private void OnApplicationFocus(bool focus)
    {
        if (focus) LoadStarsInfo();
        else SaveStarsInfo();
    }
    public void SaveStarsInfo()
    {
        SaveStarsLevelInfo saveStarsLevelInfo = new SaveStarsLevelInfo();
        saveStarsLevelInfo.SaveStars();

        BinaryFormatter bf = new BinaryFormatter();
        FileStream fs = new FileStream(_filePath, FileMode.Create);

        bf.Serialize(fs, saveStarsLevelInfo);
        fs.Close();
    }

    public void LoadStarsInfo()
    {
        if (!File.Exists(_filePath)) return;

        BinaryFormatter bf = new BinaryFormatter();
        FileStream fs = new FileStream(_filePath, FileMode.Open);

        SaveStarsLevelInfo saveStarsLevelInfo = bf.Deserialize(fs) as SaveStarsLevelInfo;
        StarsInfoBS.LoadStarsInfo(saveStarsLevelInfo);
        fs.Close();
    }

    public void ClearStarsInfo()
    {
        File.Delete(_filePath);
        _starsInstaller.ClearAllStars();
        StarsInfoBS.ClearStarsInfo();
    }
}

[Serializable]
public class SaveStarsLevelInfo
{
    public StarsInfoGroupOfThree[] starsInfo { get; private set; }

    public void SaveStars()
    {
        List<StarsInfoGroupOfThree> starsInfoBS = StarsInfoBS.GetStars();
        int length = starsInfoBS.Count;

        starsInfo = new StarsInfoGroupOfThree[length];

        for (int i = 0; i < length; i++)
            starsInfo[i] = new StarsInfoGroupOfThree(starsInfoBS[i].level, starsInfoBS[i].count);

    }
}

[Serializable]
public class StarsInfoGroupOfThree
{
    public int level;
    public int count;

    public StarsInfoGroupOfThree(int level, int count)
    {
        this.level = level;
        this.count = count;
    }
}
