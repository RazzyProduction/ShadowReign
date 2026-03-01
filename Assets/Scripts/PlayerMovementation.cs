using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovementation : MonoBehaviour
{
    [SerializeField] private AudioSource land;
    [SerializeField] private AudioSource pulo;
    [SerializeField] private float velocity;
    [SerializeField] private float jumpForce;
    [SerializeField] private GameObject sword;
    [SerializeField] private GameObject swordDown;
    [SerializeField] private Vector3 offsetDaSword;
    [SerializeField] private Vector3 offsetDaSwordBaixo;
    [SerializeField] private GameObject hideTutorial;

    private Animator anim;
    private Rigidbody2D rb;
    public bool taComOBumbumNoChao;
    private float paradinha;
    private float coolDown; 



    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        sword.transform.position = new Vector3(transform.position.x, transform.position.y, -2f) + offsetDaSword;

        swordDown.transform.position = new Vector3(transform.position.x, transform.position.y, -2f) + offsetDaSwordBaixo;

        paradinha -= Time.deltaTime;

        coolDown -= Time.deltaTime;

        var tempoPardinha = false;
        var lado = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(lado * velocity, rb.velocity.y);

        if(transform.localScale.x < 0.5f )
        {
            sword.transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else
        {
            sword.transform.localScale = new Vector3(1f, 1f, 1f);
        }

        if(coolDown <= 0f)
        {
            if(Input.GetKey(KeyCode.Mouse0) && !Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.E) && !Input.GetKey(KeyCode.S))
            {
                sword.SetActive(true);
                var escolha = Random.Range(0, 2);
                sword.GetComponent<Animator>().SetInteger("Atk01", escolha);
                coolDown = 0.5f;
                swordDown.SetActive(false);
            }
            else if(Input.GetKey(KeyCode.Mouse0) && Input.GetKey(KeyCode.S) && taComOBumbumNoChao == false || Input.GetKey(KeyCode.E) && Input.GetKey(KeyCode.S) && taComOBumbumNoChao == false)
            {
                swordDown.SetActive(true);
                coolDown = 0.5f;
                sword.SetActive(false);
            }
        }
        else if(coolDown <= 0.2f)
        {
            sword.SetActive(false);
            swordDown.SetActive(false);
        }

        if(paradinha < 0) 
        {
            tempoPardinha = false;
        }

        if(tempoPardinha == true)
        {
            rb.velocity = Vector2.zero; 
            anim.SetTrigger("Paradinha");
            paradinha = 0.2f;

        }

        //tô testando como usa o switch, deve ta bem nada haver esse codigo e muito porco
        switch(lado)
        {
            case > 0f:
                anim.SetBool("Walk", true);
                break;

            case -1f:
                anim.SetBool("Walk", true);
                break;

            default:
                anim.SetBool("Walk", false);
                break;
        }

        if(Input.GetKeyDown(KeyCode.A))
        {
            transform.localScale = new Vector2(-1f, transform.localScale.y);

            if(rb.velocity.x > 0f && taComOBumbumNoChao)
            {
                paradinha = 0.2f;
            }
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            transform.localScale = new Vector2(1f, transform.localScale.y);

            if (rb.velocity.x > 0f && taComOBumbumNoChao)
            {
                paradinha = 0.2f;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && taComOBumbumNoChao == true)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            anim.SetTrigger("Jump");
            pulo.Play();
        }

        if(rb.velocity.y < 0.5f && taComOBumbumNoChao == false)
        {
            anim.SetBool("Fall", true);
        }
        else
        {
            anim.SetBool("Fall", false);
        }

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
          if(collision.gameObject.CompareTag("Ground"))
        {
            taComOBumbumNoChao = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            taComOBumbumNoChao = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("HideTutorial"))
        {
            collision.gameObject.SetActive(false);
            hideTutorial.SetActive(true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            land.Play();
        }
    }

    public void BateuEmAlgo()
    {
        rb.AddForce(new Vector2(0, 8f), ForceMode2D.Impulse);
    }
}
