using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField] private GameObject _backgroundImagePrefab;
    private int countImages = 1;
    public BoxCollider2D _lastBoxCollider2d { private set; get; }
    private float _aspectRatio;
    void Awake()
    {
        _aspectRatio = (float)Screen.width / Screen.height;
        _lastBoxCollider2d = transform.GetComponentInChildren<BoxCollider2D>();

        float cameraRigthBoundPositionX = Camera.main.transform.position.x + Camera.main.orthographicSize * _aspectRatio;

        _lastBoxCollider2d = SpawnBackground();

        while (GetRigthBoundPositionOnX() < cameraRigthBoundPositionX)
            _lastBoxCollider2d = SpawnBackground();
    }

    public float GetRightBoundPositionOnXBackground()
    {
        return _lastBoxCollider2d.transform.position.x + _lastBoxCollider2d.bounds.size.x / 2;
    }

    public float GetLeftBoundPositionOnXBackground()
    {
        float positionOnX = _lastBoxCollider2d.transform.position.x;
        float boundsSizeOnX = _lastBoxCollider2d.bounds.size.x;
        return positionOnX - boundsSizeOnX / 2 - (countImages - 1) * boundsSizeOnX;
    }



    private float GetRigthBoundPositionOnX()
    {
        return _lastBoxCollider2d.transform.position.x + _lastBoxCollider2d.bounds.size.x / 2;
    }

    private BoxCollider2D SpawnBackground()
    {
        Vector3 position = new Vector3(GetRigthBoundPositionOnX() + _lastBoxCollider2d.bounds.size.x / 2, _lastBoxCollider2d.transform.position.y);
        countImages++;
        return Instantiate(_backgroundImagePrefab, position, _backgroundImagePrefab.transform.rotation, transform).GetComponent<BoxCollider2D>();
    }
}
