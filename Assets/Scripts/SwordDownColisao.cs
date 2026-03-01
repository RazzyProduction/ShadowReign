using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordDownColisao : MonoBehaviour
{
    [SerializeField] private AudioSource tocaBaixo;
    [SerializeField] private bool queroMorrer;

    [SerializeField] private GameObject EfeitoDecolisao;
    [SerializeField] private Vector3 colisaoBaixoSword = new Vector3(0.023f, -0.336f, -0.7f);

    private PlayerMovementation player;
    private float morrendo;
    

    // Start is called before the first frame update
    void Start()
    {
        player = FindAnyObjectByType<PlayerMovementation>();
    }

    // Update is called once per frame
    void Update()
    {
        if(queroMorrer == true)
        {
        morrendo -= Time.deltaTime; 
        
        if(morrendo <= 0) 
        {
            Destroy(gameObject);
        }

        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Spike"))
        {
            player.BateuEmAlgo();
            Instantiate(EfeitoDecolisao, transform.position + colisaoBaixoSword, Quaternion.identity);
            tocaBaixo.pitch = Random.Range(0.8f, 1.2f);
            tocaBaixo.Play();
        }
    }

    //já criei o metodo de morrer e não sei o que isso ta fazendo aqui, mas vou deixar pra não dar confusão
    private void Morrer()
    {
        morrendo = 0.5f;
        queroMorrer = true;
    }

}
