using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TocarSom : MonoBehaviour
{
    [SerializeField] private string esseSomFaz;
    [SerializeField] private AudioSource somATocar;
    [SerializeField] private bool mudaOPitch = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Tocarsom()
    {
        if(mudaOPitch == true)
        {
            somATocar.pitch = Random.Range(0.8f, 1.2f);
        }
        somATocar.Play();
    }
}
