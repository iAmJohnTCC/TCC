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
        Escuro = Ev.Escuro;   
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
        if(Movi.Localizacao=="Corredor(2°andar)"&& GameObject.Find("Insetos").GetComponent<Insetos>().enabled)
        {
            Movi.Textoguia.text = "Eu não sei o que é esse troço preto, mas tenho certeza que contato com ele não é uma boa, acho que a lanterna poderia espantar ele";
        }
        if(Escuro.GetComponent<Escuro>().health<=0)
        {
            GameObject.Find("Escadas_2andar").GetComponent<Porta>().Aberto = true;
            GameObject.Find("Insetos").GetComponent<Insetos>().enabled = true;
            GameObject.Find("Insetos").GetComponent<BoxCollider2D>().enabled = true;
            Destroy(Ev);
            Destroy(this);
        }
    }
    void Creepycrawlers()
    {
        GameObject.Find("Insetos").GetComponent<Insetos>().enabled = true;
        GameObject.Find("Insetos").GetComponent<BoxCollider2D>().enabled = true;
        Movi.Textoguia.text = "Eu não vou me esconder aqui, enquanto tiver esses insetos";
    }
}
