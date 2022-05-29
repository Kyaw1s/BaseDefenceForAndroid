using System.Collections.Generic;
using UnityEngine;

public class LevelsStarsInstaller : MonoBehaviour
{
    [SerializeField] private StarsGroupOfThreeUI[] _stars;

    private void Start()
    {
        List<StarsInfoGroupOfThree> starsInfo = StarsInfoBS.GetStars();
        foreach (var starInfo in starsInfo)
            _stars[starInfo.level - 1].InstallBurningStars(starInfo.count);
    }


    public void ClearAllStars()
    {
        foreach (var star in _stars) star.InstallBurningStars(0);
    }
}
