using UnityEngine;

public class E_Controller : MonoBehaviour
{
    [SerializeField]
    private GameObject enemy;

    [SerializeField]
    private Transform player;

    [SerializeField]
    public static int enemy_n;

    [SerializeField]
    private float spawnRadius = 10f;

    [SerializeField]
    private float minDistance = 3f;


    
    void Start()
    {
        enemy_n = Random.Range(3, 5);
        SpawnEnemies();
    }

    
    void Update()
    {
        if (enemy_n <= 0)
        {
            Start();
        }
    }

    void SpawnEnemies()
    {
        for (int i = 0; i < enemy_n; i++)
        {
            Vector3 spawnPos = GetRandomPosition();
            Instantiate(enemy, spawnPos, Quaternion.identity);
        }

    }

    Vector3 GetRandomPosition()
    {
        Vector3 spawnPos;
        do
        {
            Vector2 randomCircle = Random.insideUnitCircle * spawnRadius;
            spawnPos = new Vector3(randomCircle.x, 0, randomCircle.y) + player.position;
        }
        while (Vector3.Distance(spawnPos, player.position) < minDistance);
        return spawnPos;

    }
}

