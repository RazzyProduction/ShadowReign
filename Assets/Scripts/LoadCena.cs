using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadCena : MonoBehaviour
{
    [SerializeField] private Animator musica;
    [SerializeField] private int caregacena;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
  
    }

    private void CarregaCena()
    {
        SceneManager.LoadScene(caregacena);
    }

    private void MorrendoVolume()
    {
        musica.SetTrigger("TrocandoCena");
    }
}
