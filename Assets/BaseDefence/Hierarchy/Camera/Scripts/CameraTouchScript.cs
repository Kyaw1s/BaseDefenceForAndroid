using UnityEngine;
using UnityEngine.EventSystems;

public class CameraTouchScript : MonoBehaviour, IDragHandler
{
    [SerializeField] private Background _background;
    [SerializeField] private Transform _camera;
    private float _speed = 2f;

    public void OnDrag(PointerEventData eventData)
    {
        _camera.Translate(new Vector3(-eventData.delta.x * Time.deltaTime * _speed, 0));
        CheckBounds();
    }



    private void CheckBounds()
    {
        float rigthBoundOnX = _background.GetRightBoundPositionOnXBackground();
        float leftBoundOnX = _background.GetLeftBoundPositionOnXBackground();

        float aspectRatio = (float)Screen.width / Screen.height;
        float size = Camera.main.orthographicSize * aspectRatio;

        if (_camera.position.x + size > rigthBoundOnX) _camera.position = GetPositionForRigthBackgroundBound(size, rigthBoundOnX);

        else if (_camera.position.x - size < leftBoundOnX) _camera.position = GetPositionForLeftBackgroundBound(size, leftBoundOnX);
    }

    private Vector3 GetPositionForLeftBackgroundBound(float size, float leftBoundOnX)
    {
        return new Vector3(leftBoundOnX + size, _camera.position.y, _camera.position.z);
    }

    private Vector3 GetPositionForRigthBackgroundBound(float size, float rigthBoundOnX)
    {
        return new Vector3(rigthBoundOnX - size, _camera.position.y, _camera.position.z);
    }


}
