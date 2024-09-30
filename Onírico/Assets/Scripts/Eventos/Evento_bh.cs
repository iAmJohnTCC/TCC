using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evento_bh : MonoBehaviour
{
    Movimentacao Movi;
   [SerializeField] public Evento_qt_irma Ev;
   [SerializeField] GameObject Escuro;
    bool seescondeu = false;
    void Start()
    {
        Movi = GameObject.Find("Player").GetComponent<Movimentacao>();
        
    }

      
    void Update()
    {
        if (Movi.escondido)
        {
            seescondeu = true;
            
        }
        if(!Movi.escondido&&seescondeu)
        {
            GameObject.Find("Insetos").GetComponent<Insetos>().enabled = true;
            GameObject.Find("Insetos").transform.position = GameObject.Find("Insetos").GetComponent<Insetos>().Esconderijos[0].transform.position;
            Destroy(Ev.Escuro);
            Instantiate(Escuro);
            Destroy(Ev);
            GameObject.Find("Escadas_2andar").GetComponent<Porta>().Aberto = true;
            Destroy(this.gameObject);
        }
    }
}
