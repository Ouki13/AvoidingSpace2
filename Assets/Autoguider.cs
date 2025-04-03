using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;


public class Autoguider : MonoBehaviour
{
    private Transform player; // Stocke le transform du joueur
    public float speed = 2f;
    public float duration = 2f; // Dur�e (en secondes) pour atteindre la cible.
    public Vector2 velocity = Vector2.zero;
    public bool isPrecis;
    public float followDuration = 5f;
    private float elapsedTime = 0f; // Temps �coul� depuis le d�but du d�placement.
    private bool isFollowing = true;
    private Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = PlayerCtrl.Instance?.transform; // Acc�s rapide au joueur
        Debug.Log("autoguider start");
        rb = GetComponent<Rigidbody2D>(); // R�cup�ration du Rigidbody2D
        if (rb)
        {
            rb.gravityScale = 0; // D�sactiver la gravit� pendant le suivi
        }
    }


    // Update is called once per frame
    void Update()
    {

      

        float smoothTime = 1f / speed; // Utiliser l�inverse de la vitesse pour `SmoothDamp`
        if (isPrecis) {
            if (player == null) return;

            if (isFollowing)
            {
                // Missile suit le joueur
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

                // Mise � jour du timer
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
        isFollowing = false; // Arr�ter le suivi
        if (rb)
        {
            rb.gravityScale = 1; // Activer la gravit� pour la chute
        }
    }
}
