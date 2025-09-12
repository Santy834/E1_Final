using UnityEngine;

public class E_Controller : MonoBehaviour
{
    [SerializeField]
    private GameObject enemy;

    [SerializeField]
    private Transform player;



    [SerializeField]
    private float spawnRadius = 10f;

    [SerializeField]
    private float minDistance = 5f;

    private int round = 0;

    private int totalEnemies = 0;


    
    void Start()
    {

        NuevaRonda();
        
    }

    
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            NuevaRonda();
        }
        Debug.Log(player.position);
    }

    void NuevaRonda()
    {
        round++;

        player.position = new Vector3(0, 1.74f, 0);
        Debug.Log(player.position + "�������������NUEVA RONDA!!!!!!!!!!!");
        int enemigosExtra = Random.Range(3, 5);
        totalEnemies += enemigosExtra;

        SpawnEnemies(totalEnemies);
        Debug.Log($"Ronda{round} - Enemigos: {totalEnemies}");

        
    }

    void SpawnEnemies(int cantidad)
    {
        for (int i = 0; i < cantidad; i++)
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

