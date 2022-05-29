using UnityEngine;

public class ShopPanelButtonMoving : MonoBehaviour
{
    private static string TRIGGER_UPPING = "Upping";
    private static string TRIGGER_FALLING = "Falling";

    private Animator _animator;

    private bool _raised = true;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void Clicked()
    {
        if (_raised) _animator.SetTrigger(TRIGGER_FALLING);
        else _animator.SetTrigger(TRIGGER_UPPING);
        _raised = !_raised;
    }
}
