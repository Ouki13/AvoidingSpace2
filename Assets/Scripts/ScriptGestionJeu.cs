using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScriptGestionJeu : MonoBehaviour {

    private const float TEMPS_ENTRE_LANCERS = 1.0f;//seconde
    private float timer = 0.0f;//ajout d'une variable timer pour calculer le temps entre les lancers

    //public int NbFruitsRestants = 20;

    public GameObject PrefabFruit;

    private float minX, maxX, minY, maxY;//utilisé pour obtenir les limites de l'écran

    // Use this for initialization
    void Start ()
    {
        // If you want the min max values to update if the resolution changes 
        // set them in update else set them in Start
        float camDistance = Vector3.Distance(transform.position, Camera.main.transform.position);
        Vector2 bottomCorner = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, camDistance));
        Vector2 topCorner = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, camDistance));

        minX = bottomCorner.x;
        maxX = topCorner.x;
        minY = bottomCorner.y;
        maxY = topCorner.y;

        Debug.Log(string.Format("Dimensions ecran : {0}, {1}, {2}, {3}", minX, maxX, minY, maxY));
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButtonDown(0)) //Si on clique sur l'ecran on quitte l'application
        {
            Application.Quit();
        }

        timer += Time.deltaTime;//ajouter le temps depuis la dernière image(frame)

        if (timer >= TEMPS_ENTRE_LANCERS)//reste des fruits à lancer ET c'est maintenant le temps de lancer un nouveau fruit?
        {
            Vector3 positionFruit = new Vector3(Random.Range(minX + 2, maxX - 2), minY);//placer le fruit à une position aléatoire en bas de l'écran au début

            GameObject nouveauFruit = Instantiate(PrefabFruit, positionFruit, Quaternion.identity) as GameObject;//créer un nouveau fruit(copie de notre prefab)
            nouveauFruit.tag = "Fruit";
            int forceLancer = Random.Range(400, 700);//une force aléatoire pour le lancer du fruit
            Vector3 angleLancer = new Vector3(Random.Range(-.5f, .5f), 1);//on lance le fruit dans un angle aléatoire aussi
            nouveauFruit.GetComponent<Rigidbody2D>().AddForce(angleLancer * forceLancer);//on lance le fruit en lui appliquant une force(physique)

            //NbFruitsRestants--; //revient à dire NbFruitsRestants - 1... un fruit de moins à lancer

            timer = 0;//redémarrer le timer
        }

        //pour optimiser pour éviter que le jeu ralentisse si il y a trop d'objets
        foreach(GameObject obj in GameObject.FindGameObjectsWithTag("Fruit"))
        {
            //Si le fruit est en dehors des limites de l'écran on supprime l'objet
            if(obj.transform.position.y < minX || obj.transform.position.x < minX || obj.transform.position.x > maxX)
            {
                Destroy(obj);
            }
        }

        //changer les textes pour affichers nos variables de fruits restants et de pointage
        //GameObject.Find("txtNbLancersRestants").GetComponent<Text>().text = "Nb lancers restants : " + NbFruitsRestants;
        int scoreJ1 = GameObject.Find("KatanaJoueur1").GetComponent<ScriptKatana>().pointage;
        int scoreJ2 = GameObject.Find("KatanaJoueur2").GetComponent<ScriptKatana>().pointage;
        GameObject.Find("txtPointage").GetComponent<Text>().text = "Pointage joueur 1 : " + scoreJ1 + "\r\n" + "Pointage joueur 2 : " + scoreJ2;

        //fin de partie?
        /*if(NbFruitsRestants == 0 && timer >= TEMPS_ENTRE_LANCERS)//ne reste plus de fruits à lancer ET lancer depuis x temps?
        {
            Application.Quit();
        }*/
    }
}
