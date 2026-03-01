using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class SaveInformations : MonoBehaviour
{
    public static int nivel;
    public static bool gacialFeito = false;
    public static bool vulcanoFeito = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SubirNivel()
    {
        nivel++;
        Debug.Log(nivel);
    }

}
