using UnityEngine;
using UnityEngine.UI;

public class StarsGroupOfThreeUI : MonoBehaviour
{
    [SerializeField] private Image[] _stars;
    [SerializeField] private Sprite _dimStar;
    [SerializeField] private Sprite _burnigStar;

    public int countBurningStars { get; private set; }

    public void InstallBurningStars(int count)
    {
        if (count > _stars.Length) throw new System.Exception(count + " звезда из " + countBurningStars);

        if (count == countBurningStars) return;

        for(int i = 0; i < _stars.Length; i++)
        {
            Image star = _stars[i];
            if (i < count) star.sprite = _burnigStar;
            else star.sprite = _dimStar;
        }

        countBurningStars = count;
    }
}
