using UnityEngine;

public class TubeSpawner : MonoBehaviour
{
    public GameObject tubePrefab; // El prefab de los tubos
    public float spawnInterval = 2f; // Tiempo entre spawns
    public float spawnXPosition = 10f; // Posición X para spawnear
    public float minY = -2f; // Altura mínima de los tubos
    public float maxY = 2f;  // Altura máxima de los tubos
    public float initialSpawnOffset = 5f; // Distancia entre los tubos iniciales

    private void Start()
    {
        // Generar dos tubos iniciales al comienzo
        SpawnTubeAtOffset(-7f); // Primer tubo
        SpawnTubeAtOffset(initialSpawnOffset); // Segundo tubo

        // Comenzar el spawn continuo de tubos
        InvokeRepeating(nameof(SpawnTube), 1f, spawnInterval);
    }

    void SpawnTube()
    {
        // Generar una altura aleatoria
        float randomY = Random.Range(minY, maxY);

        // Crear la posición de spawn
        Vector3 spawnPosition = new Vector3(spawnXPosition, randomY, 0);

        // Instanciar el prefab
        Instantiate(tubePrefab, spawnPosition, Quaternion.identity);
    }

    void SpawnTubeAtOffset(float offset)
    {
        // Generar una altura aleatoria
        float randomY = Random.Range(minY, maxY);

        // Crear la posición de spawn con un desplazamiento adicional
        Vector3 spawnPosition = new Vector3(spawnXPosition + offset, randomY, 0);

        // Instanciar el prefab
        Instantiate(tubePrefab, spawnPosition, Quaternion.identity);
    }
}
