using UnityEngine;

public class BoundForDestroy : MonoBehaviour
{
    [SerializeField] private Destroyer _destroyer;

    private void OnTriggerEnter2D(Collider2D collision) => _destroyer.DestroyForCounter(collision.gameObject);

    public void InstallPosition(Vector2 position) => transform.position = position;
}
