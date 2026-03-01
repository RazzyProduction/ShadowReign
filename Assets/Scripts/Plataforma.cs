using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataforma : MonoBehaviour
{
    private GameObject player;
    private BoxCollider2D meuCollider;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerMovementation>().gameObject;
        meuCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.y > transform.position.y)
        {
            meuCollider.enabled = true;
        }
        else 
        {
            meuCollider.enabled = false;
        }
    }
}
