using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SobeLava : MonoBehaviour
{
    [SerializeField] private GameObject lava;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(lava.transform.position.y >= 13.34f)
        {
            lava.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        lava.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 1f);
        SaveInformations.vulcanoFeito = true;
    }
}
