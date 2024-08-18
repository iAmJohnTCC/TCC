using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Palhaco : MonoBehaviour
{
    [SerializeField] GameObject [] Pontos_Finais;
    [SerializeField] GameObject[] Portas;
    [SerializeField] bool Cheguei_No_Fim;
    [SerializeField] bool To_Vendo_Player;
    RaycastHit2D hit;
    [SerializeField] GameObject Player;
    [SerializeField] LayerMask Player_e_Portas;
    [SerializeField] float PararDeVer;
    [SerializeField] int Objetivo;
    
    void Start()
    {

    }
    void Update()
    {
        hit = Physics2D.Raycast(transform.position, new Vector2 (transform.localScale.x, 0), 666f,Player_e_Portas);
        if (hit.transform != null)
        {
            if (hit.transform.gameObject.GetComponent<Movimentacao>() != null)
            {
                PararDeVer = 5;
                To_Vendo_Player = true;
                
            }
            else
            {
                To_Vendo_Player = false;
            }
        }
        if(To_Vendo_Player || PararDeVer > 0)
        {
            Objetivo = 666;
           transform.position= Vector2.MoveTowards(transform.position, new Vector2(Player.transform.position.x, transform.position.y),0.01f );
            if(Player.transform.position.x > gameObject.transform.position.x && PararDeVer > 0)
            {
                transform.localScale = new Vector3(-1, transform.localScale.y, 1);
            }
            else
            {
                if(Player.transform.position.x < gameObject.transform.position.x && PararDeVer > 0)
                {
                    transform.localScale = new Vector3(1, transform.localScale.y, 1);
                }
            }
        }
        
            if (!To_Vendo_Player)
            {
                Invoke("PfVai", 2f);
            }      
                if (!To_Vendo_Player && PararDeVer == 0 && Objetivo==666 || Cheguei_No_Fim)
                {
                   Objetivo=Random.Range(0, Pontos_Finais.Length);
                }

        if (!To_Vendo_Player && PararDeVer <= 0 )
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
            if (Pontos_Finais[Objetivo].transform.position.x > gameObject.transform.position.x )
            {
                transform.localScale = new Vector3(-1, transform.localScale.y, 1);
            }
            if (Pontos_Finais[Objetivo].transform.position.x < gameObject.transform.position.x )
            {
                transform.localScale = new Vector3(1, transform.localScale.y, 1);
            }
        }
//        if(Pontos_Finais[Objetivo].transform.position.y>gameObject.transform.position.y)
      //  {
           // if (Pontos_Finais[Objetivo].transform.position.y < -0.93)
            //{
               // transform.position = Vector2.MoveTowards();
             //}
       // }
       // else
       // {
        //    if(Pontos_Finais[Objetivo].transform.position.y > gameObject.transform.position.y)
        //    {
//
         //   }
        //}
        

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<Porta>()!=null)
        {
            transform.position= collision.gameObject.GetComponent<Porta>().posicao.transform.position;
        }
    }
    public void PfVai()
    {
        PararDeVer --;
        CancelInvoke();

    }
}
   
