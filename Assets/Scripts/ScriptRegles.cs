using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScriptRegles : MonoBehaviour
{
    private const float TEMPS_INFOS = 5.0f;
    private float timer = 0.0f;

    void Update()
    {
        timer += Time.deltaTime;//ajouter le temps depuis la dernière image(frame)
        float tempsRestant = TEMPS_INFOS - timer;
        if (tempsRestant >= 10)
        {
            GameObject.Find("txtTimer").GetComponent<Text>().text = "Début du jeu dans : " + tempsRestant.ToString().Substring(0, 4);
        }
        else if (tempsRestant < 10 && tempsRestant >= 0)
        {
            GameObject.Find("txtTimer").GetComponent<Text>().text = "Début du jeu dans : " + tempsRestant.ToString().Substring(0, 3);
        }


        if (timer >= TEMPS_INFOS)
        {
            SceneManager.LoadScene(1);
        }
    }
}
