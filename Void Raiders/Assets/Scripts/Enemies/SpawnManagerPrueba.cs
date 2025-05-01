using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnManagerPrueba : MonoBehaviour
{
    public GameObject[] spawnPoints; // Puntos de spawn
    public GameObject enemyPrefab; // Prefab de enemigos
    public int waveCount; // Número de enemigos por oleada
    public int wave; // Contador de oleadas
    public bool spawning;
    private int activeEnemies; // Contador de enemigos activos
    private GameManager gameManager;
    private List<GameObject> enemies = new List<GameObject>(); // Lista de enemigos para eliminarlos con "E"

    void Start()
    {
        waveCount = 2; // Número inicial de enemigos por oleada
        wave = 1; // Primera oleada
        spawning = false; // No está spawneando al inicio
        activeEnemies = 0; // Inicialmente no hay enemigos
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        StartCoroutine(StartRound());
    }

    IEnumerator StartRound()
    {
        Debug.Log("Inicio de ronda " + wave);

        // Iniciar la oleada de enemigos
        StartCoroutine(SpawnWave(waveCount));

        // Esperar hasta que no haya enemigos activos y que el spawning haya terminado
        yield return new WaitUntil(() => activeEnemies <= 0 && !spawning);

        // Esperamos un poco antes de la siguiente ronda
        yield return new WaitForSeconds(2);

        wave++; // Aumentamos la ronda
        waveCount += 2; // Incrementamos el número de enemigos
        StartCoroutine(StartRound());
    }


    IEnumerator SpawnWave(int waveC)
    {
        spawning = true;
        Debug.Log("Ronda " + wave + " iniciando...");

        for (int i = 0; i < waveC; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(2);
        }

        spawning = false;
    }

    void SpawnEnemy()
    {
        // Seleccionamos un punto de spawn aleatorio
        int index = Random.Range(0, spawnPoints.Length);
        GameObject spawnPoint = spawnPoints[index];

        // Instanciamos el enemigo y le agregamos la función de destrucción
        GameObject enemy = Instantiate(enemyPrefab, spawnPoint.transform.position, Quaternion.identity);

        activeEnemies++; // Aumentamos el contador de enemigos
        enemies.Add(enemy); // Guardamos el enemigo en la lista

        // Asegurarnos de que el enemigo llame a EnemyDestroyed() al morir
        DeletEnemy enemyScript = enemy.AddComponent<DeletEnemy>();
        enemyScript.SetSpawnManager(this);

        Debug.Log("Spawn enemigo en: " + spawnPoint.transform.position);
    }

    public void EnemyDestroyed(GameObject enemy)
    {
        activeEnemies--; // Disminuimos el contador cuando un enemigo muere
        enemies.Remove(enemy); // Eliminamos el enemigo de la lista
        Debug.Log("Enemigo destruido. Enemigos restantes: " + activeEnemies);
    }

    void Update()
    {
        // Si el jugador presiona "E", eliminar todos los enemigos
        if (Input.GetKeyDown(KeyCode.E))
        {
            DeleteAllEnemies();
        }
    }

    public void DeleteAllEnemies()
    {
        foreach (GameObject enemy in enemies)
        {
            if (enemy != null)
            {
                Destroy(enemy);
            }
        }
        enemies.Clear(); // Limpiamos la lista de enemigos
        activeEnemies = 0; // Reseteamos el contador
    }
}
