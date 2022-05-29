using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private BoxCollider2D _background;
    private Vector3 _backgroundBoundsExtents;
    private float _aspectRatio;
    private float _zoom = 1f;
    void Awake()
    {
        _aspectRatio = (float)Screen.width / Screen.height;
        _backgroundBoundsExtents = _background.bounds.extents;
        Camera.main.orthographicSize = _backgroundBoundsExtents.y * _zoom;

        transform.position = GetPositionFromLeftAndBottomBackgroundSide();
    }


    private Vector3 GetPositionFromLeftAndBottomBackgroundSide()
    {
        Vector3 backgroundPosition = _background.transform.position;
        return new Vector3(backgroundPosition.x - _backgroundBoundsExtents.x + Camera.main.orthographicSize * _aspectRatio,
            backgroundPosition.y - _backgroundBoundsExtents.y + Camera.main.orthographicSize, transform.position.z);
    }
}
