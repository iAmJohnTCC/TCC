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
    [SerializeField] GameObject Player;
    [SerializeField] LayerMask Player_e_Portas;
    [SerializeField] float PararDeVer;
    [SerializeField] int Objetivo;
    [SerializeField] string Localizacao;
    Vector2 Objetivotemporario;
    public int Lembrarporta=0;
    void Start()
    {
        Player = GameObject.Find("Player");
    }
    void Update()
    {
        hit = Physics2D.Raycast(transform.position, new Vector2(transform.localScale.x, 0), 7.5f, Player_e_Portas);

        if (hit.transform != null)
        {
            if (hit.transform.gameObject.GetComponent<Movimentacao>() != null)
            {
               
                PararDeVer = 10;
                To_Vendo_Player = true;

            }
            else
            {
                To_Vendo_Player = false;
            }
        }
        if (To_Vendo_Player || PararDeVer > 0)
        {
            Objetivo = Pontos_Finais.Length-1;
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(Player.transform.position.x, transform.position.y), 0.01f);
            if (Player.transform.position.x > gameObject.transform.position.x && PararDeVer > 0)
            {
                transform.localScale = new Vector3(-1, transform.localScale.y, 1);
            }
            else
            {
                if (Player.transform.position.x < gameObject.transform.position.x && PararDeVer > 0)
                {
                    transform.localScale = new Vector3(1, transform.localScale.y, 1);
                }
            }
        }

        if (!To_Vendo_Player)
        {
            Invoke(nameof(PfVai), 2f);
        }
        if (!To_Vendo_Player && PararDeVer == 0 && Objetivo == Pontos_Finais.Length-1 || Cheguei_No_Fim)
        {
            Objetivo = Random.Range(0, Pontos_Finais.Length-1);
            
        }

        if (!To_Vendo_Player && PararDeVer <= 0)
        {
    
            if (Objetivotemporario == Vector2.zero)
            {
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(Pontos_Finais[Objetivo].transform.position.x, transform.position.y), 0.01f);
                if (transform.position.x == Pontos_Finais[Objetivo].transform.position.x)
                {
                    Cheguei_No_Fim = true;

                }
                else
                {
                    Cheguei_No_Fim = false;
                }
                if (Pontos_Finais[Objetivo].transform.position.x > gameObject.transform.position.x)
                {
                    transform.localScale = new Vector3(-1, transform.localScale.y, 1);
                }
                if (Pontos_Finais[Objetivo].transform.position.x < gameObject.transform.position.x)
                {
                    transform.localScale = new Vector3(1, transform.localScale.y, 1);
                }
            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position, Objetivotemporario, 0.02f);
                
            }
        }
 if(Pontos_Finais[Objetivo].transform.position.y>gameObject.transform.position.y+9|| Pontos_Finais[Objetivo].transform.position.y < gameObject.transform.position.y - 9)
        {
            vaitercoisaaq();
       
        }
          
       


    }
    void vaitercoisaaq ()
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
                            Objetivotemporario = Portas[7].transform.position;
                            Lembrarporta = 7;
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
        if(collision.gameObject.GetComponent<Porta>()!=null)
        {
            transform.position= collision.gameObject.GetComponent<Porta>().posicao.transform.position;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == Portas[Lembrarporta])
                {

            Porta porta = Portas[Lembrarporta].gameObject.GetComponent<Porta>();

            transform.position = porta.posicao.transform.position;
            if(Lembrarporta==6)
            {
               Localizacao=porta.Localizacao;
             }
             else
             {
                Localizacao = porta.Andaratual;
             }
           
            vaitercoisaaq();


        }
    }
    public void PfVai()
    {
        PararDeVer --;
        CancelInvoke();

    }
}
   
