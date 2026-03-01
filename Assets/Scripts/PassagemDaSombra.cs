using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassagemDaSombra : MonoBehaviour
{
    [SerializeField] private GameObject sombra;


    private bool morrendo = false;
    private float morreu;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if(morrendo == true)
        {
            sombra.GetComponent<SpriteRenderer>().color -= new Color(0f, 0f, 0f, Time.deltaTime);

            if(sombra.GetComponent<SpriteRenderer>().color.a <= 0)
            {
                sombra.SetActive(false);
            }
        }
           
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Shadow"))
        {
            morrendo = true;
            morreu = 1f;
        }
    }
}
