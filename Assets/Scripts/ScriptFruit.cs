using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptFruit : MonoBehaviour
{
    public bool couper;
    public Sprite SpriteCouper;
    
    // Start is called before the first frame update
    void Start()
    {
        couper = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (couper)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = SpriteCouper;
        }
    }
}
