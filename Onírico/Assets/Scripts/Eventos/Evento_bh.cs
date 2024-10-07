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
        if(!Movi.escondido&&seescondeu&&GameObject.Find("Palhaco").GetComponent<Palhaco>().PararDeVer<=0)
        {
            GameObject.Find("Insetos").GetComponent<Insetos>().enabled = true;
            GameObject.Find("Insetos").GetComponent<BoxCollider2D>().enabled = true;

            Destroy(Ev.Escuro);
            Instantiate(Escuro);
            Destroy(Ev);
            GameObject.Find("Escadas_2andar").GetComponent<Porta>().Aberto = true;
            Destroy(this.gameObject);
        }
    }
}
