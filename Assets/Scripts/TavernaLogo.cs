using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TavernaLogo : MonoBehaviour
{
    [SerializeField] private GameObject logo;

    // Start is called before the first frame update
    void Start()
    {
          if(SaveInformations.nivel > 0)
        {
            logo.SetActive(true);
        }
        else 
        {
            logo.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
      
    }
}
