using UnityEngine;

public class SpawnOnPositions : MonoBehaviour
{

    public GameObject ObstaclePrefab;
    public Transform[] spawnPoints;
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
        if (Input.GetKeyDown(KeyCode.F)) {
            Transform randomPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

            // Instancier l'objet mais sans l'afficher
            GameObject instanciated = Instantiate(ObstaclePrefab);
            instanciated.SetActive(false); // Désactiver temporairement l'objet

            // Modifier les variables avant qu'il apparaisse
            Autoguider obstacleScript = instanciated.GetComponent<Autoguider>();

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

            // Déplacer l'objet et l'activer  ObstacleFollowDuration
            instanciated.transform.position = randomPoint.position;
            instanciated.transform.rotation = randomPoint.rotation;
            instanciated.SetActive(true); // Afficher l'objet sur la scène


        }
        
    }
}
