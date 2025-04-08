using UnityEngine;

public class SpawnZone : MonoBehaviour
{
    public GameObject[] ObstaclePrefab;

    public Vector2 zoneSize;

    private float spawnInterval = 5f; // Intervalle de 5 secondes
    private float nextSpawnTime = 0f;

    public float ObstacleSpeed;
    public float ObstacleDuration = 2f; // Durée (en secondes) pour atteindre la cible.
    public bool ObstacleIsPrecis; //followDuration
    public float ObstacleFollowDuration;
    public Vector2 ObstacleVelocity = Vector2.zero;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        // Vérifie si le temps écoulé est suffisant pour spawn un nouvel obstacle
        if (Time.time >= nextSpawnTime)
        {
            SpawnObstacle();
            nextSpawnTime = Time.time + spawnInterval; // Réinitialise le temps pour le prochain spawn
        }
    }

    void SpawnObstacle()
    {

        GameObject prefabUsed = ObstaclePrefab[Random.Range(0, ObstaclePrefab.Length)];
        GameObject instantiated = Instantiate(prefabUsed);
        // Vérification
        if (prefabUsed == ObstaclePrefab[0])
        {
            Debug.Log("Prefab 0 utilisé");
        }
        else if (prefabUsed == ObstaclePrefab[1])
        {
            instantiated.SetActive(false); // Désactiver temporairement l'objet

            //Modifier les variables avant qu'il apparaisse
        Autoguider obstacleScript = instantiated.GetComponent<Autoguider>();

            if (obstacleScript != null)
            {
                //obstacleScript.speed = Random.Range(1f, 5f);
                //obstacleScript.size = Random.Range(1, 10);
                obstacleScript.speed = ObstacleSpeed;
                obstacleScript.duration = ObstacleDuration;
                obstacleScript.velocity = ObstacleVelocity;
                obstacleScript.isPrecis = ObstacleIsPrecis;
                obstacleScript.followDuration = ObstacleFollowDuration;
            }

            instantiated.SetActive(true); // Afficher l'objet sur la scène
    }
    //GameObject instantiated = Instantiate(ObstaclePrefab[Random.Range(0, ObstaclePrefab.Length)]);

        instantiated.transform.position = new Vector2(
            Random.Range(transform.position.x - zoneSize.x / 2, transform.position.x + zoneSize.x / 2),
            Random.Range(transform.position.y - zoneSize.y / 2, transform.position.y + zoneSize.y / 2)
        );
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(transform.position, zoneSize);
    }
}
