using UnityEngine;

public class Destroyer : MonoBehaviour
{
    [SerializeField] private Background _background;
    [SerializeField] private BoundForDestroy[] _boundsForDestroy;
    [SerializeField] private LevelGameEnder _gameEnder;
    private float _indentFromBackground = 5;

    private void Start()
    {
        float positionY = transform.position.y;
        _boundsForDestroy[0].InstallPosition(new Vector2(_background.GetLeftBoundPositionOnXBackground() - _indentFromBackground, positionY));
        _boundsForDestroy[1].InstallPosition(new Vector2(_background.GetRightBoundPositionOnXBackground() + _indentFromBackground, positionY));
    }
    public void DestroyForCounter(GameObject gameObject)
    {
        if (gameObject.TryGetComponent(out Enemy _) && _gameEnder.isGameContinue) _gameEnder.EndGame(false);
        Destroy(gameObject);
    }
}
