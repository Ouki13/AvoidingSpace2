using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;


public class Autoguider : MonoBehaviour
{
    private Transform player; // Stocke le transform du joueur
    public float speed = 0.005f;
    public float duration = 20000000000000f; // Durée (en secondes) pour atteindre la cible.

    private float elapsedTime = 0f; // Temps écoulé depuis le début du déplacement.

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = PlayerCtrl.Instance?.transform; // Accès rapide au joueur
        Debug.Log("autoguider start");
    }


    // Update is called once per frame
    void Update()
    {

        //transform.position = player.position;

        if (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime * speed; // Multiplie par speed pour ajuster la vitesse

            // Limite t pour ne pas dépasser 1
            float t = Mathf.Clamp01(elapsedTime / duration);

            // Applique Lerp en fonction du facteur t ajusté
            transform.position = Vector3.Lerp(transform.position, player.position, elapsedTime / duration);
        }
    }
}
