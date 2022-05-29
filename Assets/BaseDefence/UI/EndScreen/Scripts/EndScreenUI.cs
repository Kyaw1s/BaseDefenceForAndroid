using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EndScreenUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private GameObject _ribbon;
    [SerializeField] private Image _ribbonImage;

    public void ChangeText(string text) => _text.text = text;
    public void ChangeRibbonColor(Color color) => _ribbonImage.color = color;

    public void ChangeRibbonActive(bool status) => _ribbon.SetActive(status);
}
