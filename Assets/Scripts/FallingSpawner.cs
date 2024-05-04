using System.Collections;
using UnityEngine;

public class FallingSpawner : MonoBehaviour
{
    [SerializeField] private float minSpawnPositionX;
    [SerializeField] private float maxSpawnPositionX;
    [SerializeField] private int spawnRate;
    [SerializeField] private FallingCollectable fallingCollectable;

    private void Start()
    {
        StartCoroutine(SpawnObject());
    }

    private IEnumerator SpawnObject()
    {
        while (true)
        {
            float randomXPosition = Random.Range(minSpawnPositionX, maxSpawnPositionX);
            Vector2 spawnPosition = new Vector2(randomXPosition, transform.position.y);

            yield return new WaitForSeconds(spawnRate);

            Instantiate(fallingCollectable, spawnPosition, transform.rotation);
        }
    }
}