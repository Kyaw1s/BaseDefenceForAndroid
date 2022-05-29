using UnityEngine;

public class DetectorForTank : MonoBehaviour
{
    [SerializeField] private Tank myTank;
    private int countBuildingsInDetection = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Building building))
        {
            myTank.StartAttacking(building);
            countBuildingsInDetection++;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Building _))
        {
            countBuildingsInDetection--;
            if(countBuildingsInDetection == 0) myTank.EndAttacking();
        }
    }
}
