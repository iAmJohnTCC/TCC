using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sinal_interagir : MonoBehaviour
{
    public GameObject Objeto_me_utilizando;
    [SerializeField] GameObject Canvas;
    private void Update()
    {
        if(Objeto_me_utilizando != null)
        {
            Canvas.SetActive(true);
        }
        else
        {
            Canvas.SetActive(false);
        }
    }

}
