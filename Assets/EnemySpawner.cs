using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Prefab del enemigo a clonar
    public int numberOfEnemies = 10; // Número de enemigos a crear
    public float spawnInterval = 3f; // Intervalo entre cada spawn


    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        for (int i = 0; i < numberOfEnemies; i++)
        {
            // Instancia un nuevo enemigo en la posición del spawner
            Instantiate(enemyPrefab, transform.position, Quaternion.identity);

            // Espera el intervalo de tiempo antes de instanciar el siguiente enemigo
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
