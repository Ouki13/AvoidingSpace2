using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    public static PlayerCtrl Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Z)) {
            transform.position += (Vector3.up * 20) * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.position += (Vector3.down * 20) * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position += (Vector3.right * 20)  * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.Q))
        {
            transform.position += (Vector3.left * 20) * Time.deltaTime;
        }
    }
}
