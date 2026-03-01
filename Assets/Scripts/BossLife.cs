using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLife : MonoBehaviour
{
    private float vida = 10;

    [SerializeField] private GameObject boss;
    [SerializeField] private GameObject braco1;
    [SerializeField] private GameObject braco2;
    [SerializeField] private GameObject fimFase;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        boss.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, vida / 10);
        braco1.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, vida / 10);
        braco2.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, vida / 10);

        if (vida <= 0f)
        {
            boss.SetActive(false);
            braco1.SetActive(false);
            braco2.SetActive(false);
            fimFase.SetActive(true);
            SaveInformations.gacialFeito = true;
        }
        else
        {
            boss.SetActive(true);
            braco1.SetActive(true);
            braco2.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Sword"))
        {
            vida--;
        }
    }
}
