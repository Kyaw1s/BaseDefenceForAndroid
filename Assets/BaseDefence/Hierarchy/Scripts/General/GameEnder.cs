using UnityEngine;

public class GameEnder : MonoBehaviour
{
    public void CloseApplication()
    {
        SaveLoadGame.instance.SaveStarsInfo();
        Application.Quit();
    }

}
