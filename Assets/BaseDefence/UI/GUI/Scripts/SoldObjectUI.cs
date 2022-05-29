using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SoldObjectUI : MonoBehaviour
{
    [SerializeField] private Button _buttonForBuy;
    [SerializeField] private TextMeshProUGUI _buttonText;
    [SerializeField] private TextMeshProUGUI _priceText;
    [SerializeField] private Image _buildingImage;
    private Graphic _buttonGraphic;

    public int placeNumberInShop;

    public SoldObjectInfo soldObjectInfo;


    private void Awake()
    {
        _buttonGraphic = _buttonForBuy.GetComponent<Graphic>();
        _buttonForBuy.onClick.AddListener(Buying);
        soldObjectInfo = new SoldObjectInfo();
    }
    public void ChangeButtonText(string text) => _buttonText.text = text;

    public void CheckButtonActivity()
    {
        if (soldObjectInfo.hasNextLevel) SetButtonEnable(Bank.instance.IsCoinsEnough(soldObjectInfo.price));
        else
        {
            SetButtonEnable(false);
            ChangeButtonText("Макс. уровень");
            _priceText.text = "???";
        }

    }

    public void ChangeUIParametrs(BuildingData buildingData)
    {
        if (buildingData == null)
        {
            soldObjectInfo.hasNextLevel = false;
            return;
        }

        soldObjectInfo.hasNextLevel = true;
        SetButtonEnable(true);

        _buildingImage.sprite = buildingData.sprite;
        _priceText.text = buildingData.price.ToString();
        soldObjectInfo.price = buildingData.price;
    }

    public void ChangeSoldObjectInfoPrefab(GameObject prefab) => soldObjectInfo.buildingPrefab = prefab;

    public void Initialize(BuildingData buildingData, GameObject prefab, int placeNumberInShop)
    {
        this.placeNumberInShop = placeNumberInShop;
        soldObjectInfo.buildingPrefab = prefab;
        ChangeUIParametrs(buildingData);
        CheckButtonActivity();
    }

    private void Buying()
    {
        ChangeUIParametrs(Shop.instance.BuySoldObject(soldObjectInfo.buildingPrefab, soldObjectInfo.price, placeNumberInShop));
        CheckButtonActivity();
    }


    private void SetButtonEnable(bool status)
    {
        _buttonForBuy.enabled = status;
        if (status)
        {
            ChangeButtonText("Установить");
            _buttonGraphic.color = Color.green;
        }
        else _buttonGraphic.color = Color.red;
    }
}
