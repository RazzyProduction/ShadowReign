using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class ReposicaoDoPlayer : MonoBehaviour
{
    [SerializeField] private GameObject portalGlacial;
    [SerializeField] private GameObject portalVulcano;
    [SerializeField] private GameObject camerazinha;

    // Start is called before the first frame update
    void Start()
    {
          if(SaveInformations.nivel >= 1f)
        {
            transform.position = new Vector3(29.33f, -14.93f, -1.39f);
            camerazinha.transform.position = new Vector3(2.32f, -13.21f, -10f);
        }

          if(SaveInformations.gacialFeito == true)
        {
            portalGlacial.SetActive(false);
        }
          if(SaveInformations.vulcanoFeito == true)
        {
            portalVulcano.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
      
    }
}
