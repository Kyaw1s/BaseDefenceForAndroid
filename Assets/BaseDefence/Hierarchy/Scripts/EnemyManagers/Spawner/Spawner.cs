using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private LevelGameEnder _gameEnder;
    [SerializeField] private Background _background;
    [SerializeField] private Transform[] placesForSpawn;
    [SerializeField] private GameObject[] enemies;
    private float timeBetweenSpawn = GameplayInfoBS.timeBetweenEnemySpawn;
    void Start()
    {
        transform.position = new Vector2(_background.GetRightBoundPositionOnXBackground() + 2, transform.position.y);
        StartCoroutine(nameof(CR_Spawn));
    }

    private IEnumerator CR_Spawn()
    {
        while(_gameEnder.isGameContinue)
        {
            yield return new WaitForSeconds(timeBetweenSpawn);
            Spawn();
        }
    }

    private void Spawn()
    {
        Transform place = placesForSpawn[Random.Range(0, placesForSpawn.Length)];
        int indexInEnemies = Random.Range(0, enemies.Length);
        GameObject enemy = enemies[indexInEnemies];
        GameObject enemyInScene = Instantiate(enemy, place.position, enemy.transform.rotation, transform);
        enemyInScene.GetComponent<SpriteRenderer>().sortingOrder = GetOrderInLayer(indexInEnemies);
    }

    private int GetOrderInLayer(int index) => index + 10;
}
