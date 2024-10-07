using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Palhaco : MonoBehaviour
{
   
    [SerializeField] GameObject[] Pontos_Finais;
    [SerializeField] GameObject[] Portas;
    [SerializeField] bool Cheguei_No_Fim;
    public bool To_Vendo_Player;
    RaycastHit2D hit;
    float speed=0.02f;
    public float Normalspeed=0.02f;
    bool Cooldown=true;
    bool Semrepetir=false;
     Porta porta;
    [SerializeField] GameObject Player;
    [SerializeField] LayerMask Player_e_Portas;
    [SerializeField] public float PararDeVer;
    [SerializeField] int Objetivo;
    [SerializeField] public string Localizacao;
    public string localizacao2;
    Vector2 Objetivotemporario;
    public int Lembrarporta=0;
    bool Stunned = false;
    public bool parar = false;
   [SerializeField] GameObject Die;
    void Start()
    {
        Player = GameObject.Find("Player");
    }
    void Update()
    {

        hit = Physics2D.Raycast(transform.position, new Vector2(transform.localScale.x*2.5f, 0), 25f, Player_e_Portas);
        if (Pontos_Finais[Objetivo].transform.position.y > gameObject.transform.position.y + 9 || Pontos_Finais[Objetivo].transform.position.y < gameObject.transform.position.y - 9)
        {
            Objetivostemporarios();

        }
        else
        {
            Objetivotemporario = Vector2.zero;
            Lembrarporta = 0;
        }
        if (hit.transform != null)
        {
            if (hit.transform.gameObject.GetComponent<Movimentacao>() != null)
            {
                if (Player.GetComponent<Movimentacao>().escondido && PararDeVer <= 9)
                {
                    PararDeVer = 0;
                    To_Vendo_Player = false;
                }
                else
                {
                    To_Vendo_Player = true;
                    if(PararDeVer==0)
                    {
                        
                        parar = true; 
                        Invoke(nameof(Comecearezar), 4f);

                    }
                    PararDeVer = 10;
                   
                    
                }
            }
            else
            {
                To_Vendo_Player = false;
            }
        }
        if (To_Vendo_Player || PararDeVer > 0)
        {
            Objetivo = Pontos_Finais.Length - 1;
            //transform.position = Vector2.MoveTowards(transform.position, new Vector2(Player.transform.position.x, transform.position.y), speed);
            //if (Player.transform.position.x > gameObject.transform.position.x && PararDeVer > 0)
            //{
            //    transform.localScale = new Vector3(1, transform.localScale.y, 1);
            //}
            //else
            //{
            //    if (Player.transform.position.x < gameObject.transform.position.x && PararDeVer > 0)
            //    {
            //        transform.localScale = new Vector3(-1, transform.localScale.y, 1);
            //    }
            //}
        }

        if (!To_Vendo_Player&&PararDeVer>0)
        {
            Invoke(nameof(PerderdeVista), 2f);
        }
        if (!To_Vendo_Player && PararDeVer <= 0 && Objetivo==15|| Cheguei_No_Fim)
        {
            parar = true;
            Invoke(nameof(NovoObjetivo), 2f);
        }

        //if (!To_Vendo_Player && PararDeVer <= 0)
        //{

            if (Objetivotemporario == Vector2.zero)
            {
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(Pontos_Finais[Objetivo].transform.position.x, transform.position.y), speed);
                if (transform.position.x == Pontos_Finais[Objetivo].transform.position.x&&Objetivo!=15)
                {
                    Cheguei_No_Fim = true;

                }
                else
                {
                    Cheguei_No_Fim = false;
                }
                if (Pontos_Finais[Objetivo].transform.position.x > gameObject.transform.position.x)
                {
                    transform.localScale = new Vector3(1, transform.localScale.y, 1);
                }
                if (Pontos_Finais[Objetivo].transform.position.x < gameObject.transform.position.x)
                {
                    transform.localScale = new Vector3(-1, transform.localScale.y, 1);
                }
            }
           
            else
            {
                transform.position = Vector2.MoveTowards(transform.position, Objetivotemporario, speed);
                if (Objetivotemporario.x > gameObject.transform.position.x&&!Stunned)
                {
                    transform.localScale = new Vector3(1, transform.localScale.y, 1);
                }
                if (Objetivotemporario.x < gameObject.transform.position.x&&!Stunned)
                {
                    transform.localScale = new Vector3(-1, transform.localScale.y, 1);
                }
            }
        //}
        if(Player.GetComponent<Movimentacao>().Standby&&!Player.GetComponent<Movimentacao>().escondido||Stunned||Cheguei_No_Fim||parar)
        {
            speed = 0;

        }
        else
        {
            speed = Normalspeed;
        }
        if(PararDeVer>0 && speed==Normalspeed&&!Cooldown)
        {
            Die.GetComponent<BoxCollider2D>().enabled = true;
        }
        else
        {
            Die.GetComponent<BoxCollider2D>().enabled = false;
        }
       


          
       


    }
    void NovoObjetivo()
    {
        parar = false;
        Objetivo = Random.Range(0, 15);
        CancelInvoke(nameof(NovoObjetivo));
    }
    void Comecearezar()
    {
        CancelInvoke(nameof(Comecearezar));
        parar = false;
        Cooldown = false;
    }
    void Objetivostemporarios ()
        {
         
         if(Pontos_Finais[Objetivo].transform.position.y>transform.position.y+9)
        {
            if(Localizacao=="1° andar")
            {
                Objetivotemporario = Portas[2].transform.position;
                Lembrarporta = 2;
            }
            else
            {
                if(Localizacao == "Porão")
                {
                    Objetivotemporario = Portas[4].transform.position;
                    Lembrarporta = 4;
                }
                else
                if (Localizacao == "2° andar")
                {
                    Objetivotemporario = Portas[7].transform.position;
                    Lembrarporta = 7;
                }
            }
        }
         else
        {
            if (Pontos_Finais[Objetivo].transform.position.y < transform.position.y - 9)
            {
                if (Localizacao == "2° andar")
                {
                    Objetivotemporario = Portas[1].transform.position;
                    Lembrarporta = 1;
                }
                else
                {
                    if (Localizacao == "1° andar")
                    {
                        Objetivotemporario = Portas[3].transform.position;
                        Lembrarporta=3;
                    }
                    else
                    {
                        if(Localizacao=="Banheiro")
                        {
                            Objetivotemporario = Portas[6].transform.position;
                            Lembrarporta = 6;
                        }
                    }
                }
            }
            else
            {
                Objetivotemporario = Vector2.zero;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Porta>() != null)
        {
            if (Player.GetComponent<Movimentacao>().Localizacao == collision.gameObject.GetComponent<Porta>().Localizacao
                || Player.GetComponent<Movimentacao>().Localizacao == localizacao2)
            {
                porta = collision.gameObject.GetComponent<Porta>();
                localizacao2 = collision.gameObject.GetComponent<Porta>().Localizacao;
                GameObject.Find("GameController").GetComponent<GameController>().Fadeout(1.4f);
                Invoke("Teleporte", 1.5f);
                GameObject.Find("Sons_de_fundo").GetComponent<Fundo_sons>().Sons(1);
                Cooldown = true;
                Invoke(nameof(Comecearezar), 2f);

            }
            else
            {
                transform.position = collision.gameObject.GetComponent<Porta>().posicao.transform.position;
                localizacao2 = collision.gameObject.GetComponent<Porta>().Localizacao;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       
            if (collision.gameObject == Portas[Lembrarporta])
            {

                porta = Portas[Lembrarporta].gameObject.GetComponent<Porta>();


                if (Lembrarporta == 7)
                {
                    Localizacao = porta.Localizacao;
                   
                }
                else
                {
                    Localizacao = porta.Andaratual;
                   
                }
                if ((Player.GetComponent<Movimentacao>().Localizacao == collision.gameObject.GetComponent<Porta>().Localizacao || 
                Player.GetComponent<Movimentacao>().Localizacao == localizacao2)&&!Semrepetir)
                {
                Semrepetir = true;
                    porta = collision.gameObject.GetComponent<Porta>();
                    localizacao2 = collision.gameObject.GetComponent<Porta>().Localizacao;
                    GameObject.Find("GameController").GetComponent<GameController>().Fadeout(1.4f);
                    Invoke("Teleporte", 1.5f);
                    GameObject.Find("Sons_de_fundo").GetComponent<Fundo_sons>().Sons(1);
                    Cooldown = true;
                    Invoke(nameof(Comecearezar), 2f);
                }
                else
                {
                    transform.position = porta.posicao.transform.position;
                    localizacao2 = collision.gameObject.GetComponent<Porta>().Localizacao;
                    Objetivostemporarios();
                }

            }
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
       
           
            if (collision.gameObject == Portas[Lembrarporta])
            {

                porta = Portas[Lembrarporta].gameObject.GetComponent<Porta>();


                if (Lembrarporta == 7)
                {
                    Localizacao = porta.Localizacao;
                   
                }
                else
                {
                    Localizacao = porta.Andaratual;
                   
                }
            if ((Player.GetComponent<Movimentacao>().Localizacao == collision.gameObject.GetComponent<Porta>().Localizacao ||
           Player.GetComponent<Movimentacao>().Localizacao == localizacao2) && !Semrepetir)
            {
                Semrepetir = true;
                    porta = collision.gameObject.GetComponent<Porta>();
                    GameObject.Find("GameController").GetComponent<GameController>().Fadeout(1.4f);
                    Invoke("Teleporte", 1.5f);
                    GameObject.Find("Sons_de_fundo").GetComponent<Fundo_sons>().Sons(1);
                    Cooldown = true;
                    Invoke(nameof(Comecearezar), 2f);
                }
                else
                {
                    transform.position = porta.posicao.transform.position;

                    Objetivostemporarios();
                }

            
        }
    }
    void Teleporte()
    {
       CancelInvoke(nameof(Teleporte));
        transform.position = porta.posicao.transform.position;
        if (!Player.GetComponent<Movimentacao>().escondido)
        {
            Player.GetComponent<Movimentacao>().Standby = false;
        }
        Semrepetir = false;
        porta=null;
    }
    public void PerderdeVista()
    {
        PararDeVer --;
        CancelInvoke(nameof(PerderdeVista));

    }
    public void Stun()
    {
        Stunned = true;
        gameObject.GetComponent<Collider2D>().isTrigger=true;
        gameObject.GetComponent<Rigidbody2D>().isKinematic=true;
        Invoke(nameof(Unstun), 5f);

    }
    void Unstun()
    {
        gameObject.GetComponent<Collider2D>().isTrigger = false;
        gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
        PararDeVer = 10;
        speed = Normalspeed;
        Stunned = false;
    }
    
}
   
