using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Escuro : MonoBehaviour
{
    [SerializeField] string[] Comportamentos;
    public float health = 0;
    public Vector2 posicaoPlayer;
    bool Bossfight = false;
    [SerializeField] float velo;
    public string comportamentoatual = "Nas sombras";
    public string Backupcomportamento;
    [SerializeField]GameObject Morre;
    // Start is called before the first frame update
    void Start()
    {
       
        Invoke(nameof(Trocadecomportamento), Random.Range(20, 60));
        
    }

    // Update is called once per frame
    void Update()
    {
       if (GameObject.Find("Player").GetComponent<Movimentacao>().Standby == true)
        {
            velo = 0f;
        }
        else
        {
            velo = 0.02f;
        }
        if (comportamentoatual == "Nas sombras"  )
        {

            Nassombras();
            
        }
        if (comportamentoatual == "Stalking")
        {
            Stalking();
        }
        if (comportamentoatual == "Boss")
        {
            Boss(); 
        }
        if(comportamentoatual == "Ataque")
        {
            Ataque();
        }


        if (GameObject.Find("Player").GetComponent<Movimentacao>().Localizacao == "Sala do gerador"&&!Bossfight)
        {
            Bossfight=true;
            Trocadecomportamento();
        }
        if( comportamentoatual == "Stalking"|| comportamentoatual == "Boss"|| comportamentoatual == "Ataque")
        {
            Morre.GetComponent<BoxCollider2D>().enabled = true;
        }
        else
        {
            Morre.GetComponent<BoxCollider2D>().enabled = false;
        }


    }

    void Trocadecomportamento()
    {
        CancelInvoke();
        this.gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        if (!GameObject.Find("Player").GetComponent<Movimentacao>().Standby)
        {
            if (GameObject.Find("Player").GetComponent<Movimentacao>().Localizacao == "Sala do gerador")
            {
                comportamentoatual = "Boss";
                int i = Random.Range(0, 2);
                if (i == 0)
                {
                    transform.position = new Vector2(4.18f, transform.position.y + 1.2f);
                }
                else
                {
                    transform.position = new Vector2(25.69f, transform.position.y + 1.2f);
                }
                health = 10;

            }
            else
            {


                comportamentoatual = Comportamentos[Random.Range(1, 3)];
                posicaoPlayer = GameObject.Find("Player").transform.position;
                transform.position = new Vector2(posicaoPlayer.x + Random.Range(-8f,8f), posicaoPlayer.y+1.2f);
            }
            if (comportamentoatual != "Nas sombras")
            {
                gameObject.GetComponent<SpriteRenderer>().enabled = true;
            }

            if (comportamentoatual == "Nas sombras")
            {
                Invoke(nameof(Trocadecomportamento), Random.Range(20, 60));
            }
            else
            {
                Backupcomportamento = comportamentoatual;
                comportamentoatual = "Summon";
                Invoke(nameof(Ativar), 1.5f);
                Animator anim = GetComponent<Animator>();
                anim.Play("Escuro_summon");
                
                if (comportamentoatual != "Boss")
                {
                    Invoke(nameof(Trocadecomportamento), Random.Range(20, 60));
                }
                
            }

        }
        else
        {
            if(GameObject.Find("Player").GetComponent<Movimentacao>().Localizacao == "Sala do gerador")
            {
                comportamentoatual = "Boss";
                Backupcomportamento = comportamentoatual;
                comportamentoatual = "Summon";
                Invoke(nameof(Ativar), 1.5f);
                Animator anim = GetComponent<Animator>();
                anim.Play("Escuro_summon");

               
            }
            else
            {
                Invoke(nameof(Trocadecomportamento), Random.Range(10, 20));
            }
           
        }
    }
    
        
        
        void Ativar()
    {
       
        comportamentoatual = Backupcomportamento;
        if(Backupcomportamento == "Boss")
        {
            Debug.Log("Work");
         
            comportamentoatual = "Boss";
            Boss();
        }
    }
    
    void Boss()
    {
       
        Animator anim = GetComponent<Animator>();
        anim.Play("Escuro_idle");
        comportamentoatual = "Boss";
        posicaoPlayer = GameObject.Find("Player").transform.position;
        GameObject.Find("Porta_D_gerador").GetComponent<Porta>().Aberto = false;
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(posicaoPlayer.x, transform.position.y), velo);
        if (GameObject.Find("Player").transform.position.x > gameObject.transform.position.x)
        {
            transform.localScale = new Vector3(-1, transform.localScale.y, 1);
        }
        if (GameObject.Find("Player").transform.position.x < gameObject.transform.position.x)
        {
            transform.localScale = new Vector3(1, transform.localScale.y, 1);
        }
        if (health <= 0)
        {
            
            comportamentoatual = "DAMEDANE";
            anim.Play("Escuro_unsummon");
            Invoke(nameof(Ativar), 1.5f);
            Invoke(nameof(Trocadecomportamento), 2f);
        }

    }

    void Nassombras()
    {
         Animator anim = GetComponent<Animator>();
        anim.Play("Escuro_idle");
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        health = 5;
    }

    void Ataque()
    {
        Animator anim = GetComponent<Animator>();
        anim.Play("Escuro_idle");

        posicaoPlayer = GameObject.Find("Player").transform.position;
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(posicaoPlayer.x, transform.position.y), velo);
        comportamentoatual = "Ataque";
      
        
        if (health <= 0)
        {
            CancelInvoke();
            Backupcomportamento = "Nas sombras";
            comportamentoatual = "Unsummon";
            anim.Play("Escuro_unsummon");
            Invoke(nameof(Ativar),1.5f);
            Invoke(nameof(Trocadecomportamento), Random.Range(20, 60));
        }
        if (GameObject.Find("Player").transform.position.x > gameObject.transform.position.x)
        {
            transform.localScale = new Vector3(-1, transform.localScale.y, 1);
        }
        if (GameObject.Find("Player").transform.position.x < gameObject.transform.position.x)
        {
            transform.localScale = new Vector3(1, transform.localScale.y, 1);
        }
        
    }

    void Stalking()
    {
        comportamentoatual = "Stalking";
        Animator anim = GetComponent<Animator>();
        anim.Play("Escuro_idle");

        if (GameObject.Find("Player").transform.position.x > gameObject.transform.position.x)
        {
            transform.localScale = new Vector3(-1, transform.localScale.y, 1);
        }
        if (GameObject.Find("Player").transform.position.x < gameObject.transform.position.x)
        {
            transform.localScale = new Vector3(1, transform.localScale.y, 1);
        }
       if(health<=0)
        {
            CancelInvoke();
            Backupcomportamento = "Nas sombras";
            comportamentoatual = "Unsummon";
            anim.Play("Escuro_unsummon");
            Invoke(nameof(Trocadecomportamento), Random.Range(20, 60));
            Invoke(nameof(Ativar), 1.5f);
        }
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Luz_gerador") && collision.GetComponent<PolygonCollider2D>().isActiveAndEnabled)
        {
            GameObject.Find("Chave_lavanderia").transform.position=transform.position;
            GameObject.Find("Porta_D_gerador").GetComponent<Porta>().Aberto = true;
            Destroy(this.gameObject);
        }
    }

}
