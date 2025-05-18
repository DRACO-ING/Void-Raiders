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
    public GameObject bossPrefab; // Prefab del jefe
    private bool bossSpawned = false; // Variable para verificar si el jefe ya ha aparecido
    private bool isBossRound = false; // Variable para saber si la ronda es ronda de jefe


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
        isBossRound = false;

        if (wave % 10 == 0 && bossSpawned == false)
        {
            StartCoroutine(SpawnBoss());
            bossSpawned = true;
            isBossRound = true;
        }
        else
        {
            StartCoroutine(SpawnWave(waveCount));
        }

        yield return new WaitUntil(() => activeEnemies <= 0 && !spawning);
        yield return new WaitForSeconds(2);

        if (!isBossRound)
        {
            wave++;
            waveCount += 2;
            StartCoroutine(StartRound()); //  Solo continuar si no fue ronda de jefe
        }
        //  Si fue ronda de jefe, no avanzamos. El avance se hará desde EnemyDestroyed cuando el boss muera
    }



    IEnumerator SpawnBoss()
    {
        spawning = true;
        Debug.Log("¡Boss apareciendo en la ronda " + wave + "!");

        int index = Random.Range(0, spawnPoints.Length);
        GameObject spawnPoint = spawnPoints[index];

        GameObject boss = Instantiate(bossPrefab, spawnPoint.transform.position, Quaternion.identity);
        boss.name = "Boss_" + wave;

        activeEnemies++; // para verificar despues si hay enemigos activos y iniciar otra ronda
        enemies.Add(boss); //se añade el boss a la lista de enemigos

        DeletEnemy enemyScript = boss.AddComponent<DeletEnemy>();
        enemyScript.SetSpawnManager(this);

        spawning = false;
        yield return null;
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
        activeEnemies--;
        enemies.Remove(enemy);
        Debug.Log("Enemigo destruido. Enemigos restantes: " + activeEnemies);

        if (enemy.name.Contains("Boss"))
        {
            bossSpawned = false;

            //  Solo si el jefe ha muerto y no hay enemigos vivos, continuar la ronda
            if (activeEnemies <= 0)
            {
                wave++;
                waveCount += 2;
                StartCoroutine(StartRound());
            }
        }
    }



    void Update()
    {
        // Si el jugador presiona "E", eliminar todos los enemigos
        if (Input.GetKeyDown(KeyCode.E))
        {
            DeleteAllEnemies();
            bossSpawned = false;
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
