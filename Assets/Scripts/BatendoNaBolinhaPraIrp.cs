using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class BatendoNaBolinhaPraIrp : MonoBehaviour
{
    [SerializeField] private int cenaacarregar;
    [SerializeField] private GameObject transitando;
    private float tempodetroca;
    private bool podeTrocar = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tempodetroca -= Time.deltaTime;

        if(podeTrocar == true && tempodetroca < 0)
        {
            SceneManager.LoadScene(cenaacarregar);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Sword"))
        {
            transitando.SetActive(true);
            tempodetroca = 1.5f;
            podeTrocar = true;
        }
    }
}
