using System.Collections.Generic;
using System;
public static class StarsInfoBS
{
    private static List<StarsInfoGroupOfThree> _starsInfo = new List<StarsInfoGroupOfThree>();

    public static void AddStarsInfo(int level, int count)
    {
        for(int i = 0; i < _starsInfo.Count; i++)
            if(_starsInfo[i].level == level)
            {
                _starsInfo[i].count = count;
                return;
            }
        _starsInfo.Add(new StarsInfoGroupOfThree(level, count));
    }

    public static void ClearStarsInfo()
    {
        _starsInfo = new List<StarsInfoGroupOfThree>();
        GC.Collect();
    }


    public static void LoadStarsInfo(SaveStarsLevelInfo saveStarsLevelInfo)
    {
        ClearStarsInfo();
        List<StarsInfoGroupOfThree> starsInfoGroupOfThrees = new List<StarsInfoGroupOfThree>();

        foreach (var e in saveStarsLevelInfo.starsInfo)
            starsInfoGroupOfThrees.Add(e);

        _starsInfo = starsInfoGroupOfThrees;
    }

    public static int GetBurningStarsCount()
    {
        int sum = 0;
        foreach (var starInfo in _starsInfo) sum += starInfo.count;
        return sum;
    }

    public static List<StarsInfoGroupOfThree> GetStars() => _starsInfo;
}
