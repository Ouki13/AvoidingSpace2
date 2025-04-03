using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptKatana : MonoBehaviour {
    public bool collision;
    public int pointage;
    private string nomSprite;
    
    void Start () {
        pointage = 0;
        collision = false;
        nomSprite = "Asteroid"; //pour le fruit c'est melon_eau
	}

    //Cette fonction sera appelée lorsque la collision sera détectée par Unity
    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Collision détectée");

        if (collision && col.GetComponent<SpriteRenderer>().sprite.name == nomSprite)
        {
            //détruire notre fruit de notre scène
            GameObject fruit = col.gameObject;
            if (!fruit.GetComponent<ScriptFruit>().couper)
            {
                pointage++;
                fruit.GetComponent<ScriptFruit>().couper = true;
            }
        }
    }
}
