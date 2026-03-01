using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI.Table;

public class ShadowControl : MonoBehaviour
{
    private Vector2 distancia = new Vector2(-1f, -1f);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(0, Quaternion.identity.y, Quaternion.identity.z);

        if(FindObjectOfType<PlayerMovementation>().taComOBumbumNoChao == true)
        {
            transform.position = new Vector2(FindObjectOfType<PlayerMovementation>().transform.position.x, FindObjectOfType<PlayerMovementation>().transform.position.y);
        }
        else
        {
        transform.position = new Vector2(FindObjectOfType<PlayerMovementation>().transform.position.x, transform.position.y);
        }

        transform.localScale = new Vector2(-distancia.x, 1f);

        if(transform.localScale.x > 2f)
        {
            transform.localScale = new Vector2(2f, transform.localScale.y);
        }

        if (transform.localScale.x < -2f)
        {
            transform.localScale = new Vector2(-2f, transform.localScale.y);
        }

    }

    public void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Light"))
        {
              var objColidido = other.GetComponent<Transform>();

              distancia = transform.position - objColidido.position;
        }
      
    }
}
