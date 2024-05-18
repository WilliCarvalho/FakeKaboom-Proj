using System.Collections;
using UnityEngine;

public class FallingSpawner : MonoBehaviour
{
    [SerializeField] private float minSpawnPositionX;
    [SerializeField] private float maxSpawnPositionX;
    [SerializeField] private float spawnRate;
    [SerializeField] private FallingCollectable coinCollectable;
    [SerializeField] private FallingCollectable hearthCollectable;

    private void Start()
    {
        StartCoroutine(SpawnObject());
    }

    private IEnumerator SpawnObject()
    {
        while (GameManager.Instance.GetIsGameOver() == false)
        {
            float randomXPosition = Random.Range(minSpawnPositionX, maxSpawnPositionX);
            Vector2 spawnPosition = new Vector2(randomXPosition, transform.position.y);

            yield return new WaitForSeconds(spawnRate);

            float hearthSpawnChance = Random.Range(0, 100);
            if (hearthSpawnChance == 2)
            {
                Instantiate(hearthCollectable, spawnPosition, transform.rotation);
            }
            else
            {
                Instantiate(coinCollectable, spawnPosition, transform.rotation);
            }

        }
    }

    public void ChangeSpawnRate(float amount)
    {
        spawnRate = amount;
    }
}