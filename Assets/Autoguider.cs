using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;


public class Autoguider : MonoBehaviour
{
    private Transform player; // Stocke le transform du joueur
    public float speed = 2f;
    public float duration = 2f; // Durée (en secondes) pour atteindre la cible.
    public Vector2 velocity = Vector2.zero;
    public bool isPrecis;
    public float followDuration = 5f;
    private float elapsedTime = 0f; // Temps écoulé depuis le début du déplacement.
    private bool isFollowing = true;
    private Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = PlayerCtrl.Instance?.transform; // Accès rapide au joueur
        Debug.Log("autoguider start");
        rb = GetComponent<Rigidbody2D>(); // Récupération du Rigidbody2D
        if (rb)
        {
            rb.gravityScale = 0; // Désactiver la gravité pendant le suivi
        }
    }


    // Update is called once per frame
    void Update()
    {

      

        float smoothTime = 1f / speed; // Utiliser l’inverse de la vitesse pour `SmoothDamp`
        if (isPrecis) {
            if (player == null) return;

            if (isFollowing)
            {
                // Missile suit le joueur
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

                // Mise à jour du timer
                elapsedTime += Time.deltaTime;
                if (elapsedTime >= followDuration)
                {
                    StopFollowing();
                }
            }

        } 
        else {
            transform.position = Vector2.SmoothDamp(transform.position, player.position, ref velocity, smoothTime);
        }
        
        //}
    }

    void StopFollowing()
    {
        isFollowing = false; // Arrêter le suivi
        if (rb)
        {
            rb.gravityScale = 1; // Activer la gravité pour la chute
        }
    }
}
