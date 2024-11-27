using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evento_bh : MonoBehaviour
{
    Movimentacao Movi;
   [SerializeField] public Evento_qt_irma Ev;
    bool seescondeu = false;
    void Start()
    {
        Movi = GameObject.Find("Player").GetComponent<Movimentacao>();
     
    }

      
    void Update()
    {
        
        if (Movi.escondido&& !GameObject.Find("Insetos").GetComponent<Insetos>().enabled)
        {
            seescondeu = true;
            
        }
        if(!Movi.escondido&&seescondeu&&GameObject.Find("Palhaco").GetComponent<Palhaco>().PararDeVer<=0)
        {
            seescondeu = false;

            Invoke(nameof(Creepycrawlers), 0.3f);
           
           
            GameObject.Find("Escadas_2andar").GetComponent<Porta>().Aberto = true;
          
            
        }
      
       
    }
    void Creepycrawlers()
    {
        GameObject.Find("Palhaco").GetComponent<Palhaco>().Normalspeed = 2;
        GameObject.Find("Insetos").GetComponent<Insetos>().enabled = true;
        GameObject.Find("Insetos").GetComponent<BoxCollider2D>().enabled = true;
        Movi.Textoguia.text = "Eu não vou me esconder aqui, enquanto tiver esses insetos";
        GameObject.Find("CM_Mapa").GetComponent<Mapa>().objetivo.text = "-Explorar o terreo";
        Destroy(Ev.Bloqueiotutorial);
        Destroy(Ev);
        Destroy(this);
    }
}
