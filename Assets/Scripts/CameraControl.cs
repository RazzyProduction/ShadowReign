using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    //Script reutilizado do spaceshooter

    [SerializeField] private float menorQueX = 0.9f;
    [SerializeField] private float maiorQuex = 24f;
    [SerializeField] private float menorQueY = -14f;
    [SerializeField] private float maiorQueY = 0f;

    private GameObject player;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {       
        var paraOndeIr = player.transform.position - transform.position;
        paraOndeIr.Normalize();

        rb.velocity = paraOndeIr * 7f;

        if(transform.position == player.transform.position)
        {
            rb.velocity = Vector2.zero;
        }

        if (transform.position.x <= menorQueX)
        {
            transform.position = new Vector3(menorQueX, transform.position.y, -10f);
        }
        else if (transform.position.x >= maiorQuex)
        {
            transform.position = new Vector3(maiorQuex, transform.position.y, -10f);
        }

        if (transform.position.y <= menorQueY)
        {
            transform.position = new Vector3(transform.position.x, menorQueY, -10f);
        }
        else if (transform.position.y >= maiorQueY)
        {
            transform.position = new Vector3(transform.position.x, maiorQueY, -10f);
        }
    }
}
