using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evento_qt_irma : MonoBehaviour
{
    [SerializeField] GameObject Palhaco_intro;
    [SerializeField] public GameObject Palhaco;
    public GameObject Lanterna;
    bool Theclownisintown = false;
    int energia=50;
    bool Stoptalking = false;
    bool GetStunned = false;
    bool consumir = true;
    [SerializeField] public GameObject Escuro;
    Escuro scrEscuro;
    [SerializeField] Sprite Abriu;
    [SerializeField] public GameObject Bloqueiotutorial;
    [SerializeField] GameObject Banheiro;
 
    //[SerializeField] Vector2
    private void Start()
    {
      
        GameObject.Find("QuartoIrma_cofre").GetComponent<SpriteRenderer>().sprite=Abriu;
        Bloqueiotutorial = Instantiate(Bloqueiotutorial);
        Escuro = Instantiate(Escuro, new Vector2(37,0.45f), Quaternion.identity);
        GameObject.Find("Porta_qt_irma_D").GetComponent<Porta>().Aberto = false;
        Palhaco = GameObject.Find("Palhaco");
        Palhaco_intro = GameObject.Find("Teste (2)");
        GameObject.Find("Player").GetComponent<Movimentacao>().Textoguia.text = "Estou sentindo uma presen�a estranha,n�o vou sair daqui at� eu ligar a lanterna e apontar pra essa presen�a(Aperte F para ligar a lanterna)";
    }
    void Update()
    {
        if (!Stoptalking)
        {
            if (consumir)
            {
                GameObject.Find("Player").GetComponent<Lanterna>().Energia = energia;
            }
            if (!Theclownisintown)
            {
                GameObject.Find("Player").GetComponent<Movimentacao>().Textoguia.text = "Estou sentindo algo estranho naquela caixa,n�o vou sair daqui at� eu ligar a lanterna e apontar pra caixa(Aperte F para ligar a lanterna)";
            }
            if (Lanterna == null && !Theclownisintown && GameObject.Find("Player").GetComponent<Lanterna>().Luz.activeSelf && GameObject.Find("Player").transform.localScale.x == -1)
            {
                Intro();
                Theclownisintown = true;
            }

            if (!GetStunned)
            {
                Palhaco.GetComponent<Palhaco>().Normalspeed = 0f;
            }
            if (Palhaco.GetComponent<Palhaco>().PararDeVer > 0)
            {
                GameObject.Find("Player").GetComponent<Movimentacao>().Textoguia.text = "Um Pa-Pa-palha�o? Eu tenho que ligar a lanterna e apertar espa�o para cega-lo e conseguir fugir!";
            }
            if (Palhaco.GetComponent<Palhaco>().Stunned|| GameObject.Find("Player").GetComponent<Movimentacao>().Localizacao!="Quarto da Irm�")
            {
                GetStunned = true;
                Stoptalking = true;
                GameObject.Find("Player").GetComponent<Movimentacao>().Velocidade = 6;

            }
        }
        else
        {
            if (Palhaco.GetComponent<Palhaco>().Normalspeed != 0.02f)
            {
                GameObject.Find("Player").GetComponent<Movimentacao>().Textoguia.text = "Eu tenho que me esconder! Talvez no banheiro tenha algum lugar que eu posso usar";
                Palhaco.GetComponent<Palhaco>().Normalspeed = 0.02f;
            }
        }
    }
    void Intro()
    {
        Bloqueiotutorial.transform.position = new Vector2(11.5f, -2.89f);

        GameObject.Find("Player").GetComponent<Movimentacao>().Standby = true;
        Palhaco_intro.GetComponent<Animator>().Play("Palhaco_intro");
        Invoke(nameof(Funbegins), 3f);
        Palhaco.GetComponent<AudioSource>().enabled = true;
       
    }
    void Funbegins()
    {
        GameObject.Find("Player").GetComponent<Movimentacao>().Velocidade = 0;
       consumir = false;
        GameObject.Find("Porta_qt_irma_D").GetComponent<Porta>().Aberto = true;
        Palhaco.transform.position = Palhaco_intro.transform.position;
        Destroy(Palhaco_intro);
        GameObject.Find("Player").GetComponent<Movimentacao>().Textoguia.text = "Um Pa-Pa-palha�o? Eu tenho que ligar a lanterna e apertar espa�o para cega-lo e conseguir fugir!";
        Palhaco.GetComponent<Palhaco>().To_Vendo_Player = true;
        GameObject.Find("Player").GetComponent<Movimentacao>().Standby = false;
        
        Banheiro = Instantiate(Banheiro );
        Banheiro.GetComponent<Evento_bh>().Ev=this;
         
    }
}
