using UnityEngine;
using UnityEngine.UI;

public class HealthProgressBar : MonoBehaviour
{
    private Image _progress;
    [SerializeField] private GameObject _IDamagableGameObject;
    private IGetDamageable _IGetDamagableObject;

    private void Start()
    {
        _progress = GetComponent<Image>();
        _IGetDamagableObject = GetDamageableFromGameObject(_IDamagableGameObject);
        _IGetDamagableObject.HealthChangedEvent += ChangeProgress;
    }

    public void ChangeProgress(int hp, int maxHp)
    {
        _progress.fillAmount = (float)hp / maxHp;
    }

    public IGetDamageable GetDamageableFromGameObject(GameObject _IDamagableGameObject)
    {
        try
        {
            return _IDamagableGameObject.GetComponent<IGetDamageable>();
        }
        catch
        {
            throw new System.Exception("Объект не имеет интерфейса " + nameof(IGetDamageable));
        }
    }
}
