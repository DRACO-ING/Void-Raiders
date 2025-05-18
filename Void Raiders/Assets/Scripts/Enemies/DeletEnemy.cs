using UnityEngine;

public class DeletEnemy : MonoBehaviour
{
    private SpawnManagerPrueba spawnManager;

    public void SetSpawnManager(SpawnManagerPrueba manager)
    {
        spawnManager = manager;
    }

    void OnDestroy()
    {
        if (spawnManager != null)
        {
            spawnManager.EnemyDestroyed(gameObject);
        }
    }
}