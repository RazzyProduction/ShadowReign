using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MorrerEResetarCena : MonoBehaviour
{
    [SerializeField] private GameObject trasicaoMorte;
    [SerializeField] private int cenaACarregar;
    private float carregando;
    private bool podeCarregar = false;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        Time.fixedDeltaTime = 0.02f * Time.timeScale;
    }

    // Update is called once per frame
    void Update()
    {
        carregando -= Time.deltaTime;

        if(podeCarregar == true)
        {
            if(carregando < 0)
            {
                SceneManager.LoadScene(cenaACarregar);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Boss"))
        {
            Morrer();
        }
    }

    private void Morrer()
    {
        trasicaoMorte.SetActive(true);
        //Codigo do flip dog
        Time.timeScale = 0.3f;
        Time.fixedDeltaTime = 0.02f * Time.timeScale;
        carregando = 3f;
        podeCarregar = true;
    }
}
