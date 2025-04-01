using UnityEngine;

public class SpawnOnPositions : MonoBehaviour
{

    public GameObject ObstaclePrefab;
    public Transform[] spawnPoints;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)) {
            Transform randomPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

            GameObject Instanciated = Instantiate(ObstaclePrefab, randomPoint);
        
        }
        
    }
}
