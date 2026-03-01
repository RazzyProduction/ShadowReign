using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTeleport : MonoBehaviour
{
   [SerializeField] private GameObject transitionGelo;
   [SerializeField] private GameObject transitionLava;
   [SerializeField] private GameObject transitionVazio;

   [SerializeField] private GameObject portalVazio;

    private SaveInformations variavel;


    // Start is called before the first frame update
    void Start()
    {
        variavel = FindAnyObjectByType<SaveInformations>();
    }

    // Update is called once per frame
    void Update()
    {
        if(SaveInformations.gacialFeito == true && SaveInformations.vulcanoFeito == true)
        {
            portalVazio.SetActive(true);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("GlacialPortal") && Input.GetKeyDown(KeyCode.W))
        {
            transitionGelo.SetActive(true);
            variavel.SubirNivel();

        }
        else if (collision.gameObject.CompareTag("VulcanoPortal") && Input.GetKeyDown(KeyCode.W))
        {
            transitionLava.SetActive(true);
            variavel.SubirNivel();
        }
        else if (collision.gameObject.CompareTag("CreditsPortal") && Input.GetKeyDown(KeyCode.W))
        {
            transitionVazio.SetActive(true);
        }
    }
}
