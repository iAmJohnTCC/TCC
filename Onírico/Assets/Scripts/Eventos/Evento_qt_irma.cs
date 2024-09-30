using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evento_qt_irma : MonoBehaviour
{
    [SerializeField] GameObject Palhaco_intro;
    [SerializeField] public GameObject Palhaco;
    public GameObject Lanterna;
    bool semRepetir = false;
    [SerializeField] public GameObject Escuro;
    Escuro scrEscuro;
    [SerializeField] GameObject Banheiro;
 
    //[SerializeField] Vector2
    private void Start()
    {
        Palhaco = GameObject.Find("Palhaco");
        Palhaco_intro = GameObject.Find("Teste (2)");
    }
    void Update()
    {
        if(Lanterna == null && !semRepetir)
        {
            Intro();
            semRepetir = true;
        }
        
    }
    void Intro()
    {
        GameObject.Find("Player").GetComponent<Movimentacao>().Standby = true;
        Palhaco_intro.GetComponent<Animator>().Play("Palhaco_intro");
        Invoke(nameof(Funbegins), 3f);
        GameObject.Find("Player").GetComponent<Movimentacao>().Textoguia.text = "Objetivo: Se esconder no banheiro(CORRE)";
    }
    void Funbegins()
    {
        Palhaco.transform.position = Palhaco_intro.transform.position;
        Destroy(Palhaco_intro);
        Palhaco.GetComponent<Palhaco>().To_Vendo_Player = true;
        Palhaco.GetComponent<Palhaco>().PararDeVer = 10;
        GameObject.Find("Player").GetComponent<Movimentacao>().Standby = false;
        Escuro = Instantiate(Escuro, new Vector2 (1.04f, 0.66f), Quaternion.identity);
        Banheiro = Instantiate(Banheiro );
        Banheiro.GetComponent<Evento_bh>().Ev=this;
        //Escuro.GetComponent<Escuro>().comportamentoatual="Stalking";     
    }
}
