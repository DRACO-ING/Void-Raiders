using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int defeatEnemies;
    public int vida;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        defeatEnemies = 0;
        vida = 10;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
