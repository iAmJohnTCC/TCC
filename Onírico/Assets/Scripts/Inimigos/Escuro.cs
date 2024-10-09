using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Escuro : MonoBehaviour
{
    [SerializeField] string[] Comportamentos;
    public float health = 5;
    public Vector2 posicaoPlayer;
    bool Bossfight = false;
    [SerializeField] float velo;
    public string comportamentoatual = "Stalking";
    public string Backupcomportamento;
    [SerializeField]GameObject Morre;
    bool Possoatacar=false;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
       if (GameObject.Find("Player").GetComponent<Movimentacao>().Standby == true&&Possoatacar)
        {
            velo = 0f;
            Possoatacar = false;
            
        }

        else
        {
            velo = 0.02f;
        }
       if(!GameObject.Find("Player").GetComponent<Movimentacao>().Standby  && !Possoatacar&& 
            (comportamentoatual == "Stalking" || comportamentoatual == "Boss" || comportamentoatual == "Ataque"))
        {
            Invoke(nameof(Yougondielilman), 2f);
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
            comportamentoatual = "Boss";
            Trocadecomportamento();
        }
        if( (comportamentoatual == "Stalking"|| comportamentoatual == "Boss"|| comportamentoatual == "Ataque")&&Possoatacar)
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
 posicaoPlayer = GameObject.Find("Player").transform.position;
        if (GameObject.Find("Player").GetComponent<Movimentacao>().Localizacao == "Sala do gerador")
            {
                comportamentoatual = "Boss";
                GameObject.Find("Player").GetComponent<Movimentacao>().Textoguia.text="Parece que agora a lanterna não vai ser o suficiente para ele me deixar em paz, mas será que aquele botão naquele canto seja a resposta?";
                int i = Random.Range(0, 2);
                if (i == 0)
                {
                    transform.position = new Vector2(4.18f, posicaoPlayer.y + 1.2f);
                }
                else
                {
                    transform.position = new Vector2(25.69f, posicaoPlayer.y + 1.2f);
                }
                health = 10;

            }
        this.gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        if (GameObject.Find("Player").GetComponent<Movimentacao>().Standby&&comportamentoatual!="Boss")
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
           
                Invoke(nameof(Trocadecomportamento), Random.Range(10, 30));
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
                    Invoke(nameof(Trocadecomportamento), Random.Range(10, 30));
                }
                
            }

        
      
            if(GameObject.Find("Player").GetComponent<Movimentacao>().Localizacao == "Sala do gerador")
            {
                comportamentoatual = "Boss";
                int i = Random.Range(0, 2);
                if (i == 0)
                {
                    transform.position = new Vector2(4.18f, posicaoPlayer.y + 1.2f);
                }
                else
                {
                    transform.position = new Vector2(25.69f, posicaoPlayer.y + 1.2f);
                }
                health = 10;
                Backupcomportamento = comportamentoatual;
                comportamentoatual = "Summon";
                
                Invoke(nameof(Ativar), 1.5f);
                Animator anim = GetComponent<Animator>();
                anim.Play("Escuro_summon");

               
            }
            else
            {
                Invoke(nameof(Trocadecomportamento), Random.Range(10, 30));
            }
           
        
    }
    
        
        
        void Ativar()
    {
       
        comportamentoatual = Backupcomportamento;
       
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
            
            comportamentoatual = "Unsummon";
            anim.Play("Escuro_unsummon");
            Invoke(nameof(Ativar), 1.6f);
            Invoke(nameof(Trocadecomportamento), 1.61f);
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
            Invoke(nameof(Ativar),1.3f);
            Invoke(nameof(Trocadecomportamento), Random.Range(10, 30));
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
            Invoke(nameof(Trocadecomportamento), Random.Range(10, 30));
            Invoke(nameof(Ativar), 1.3f);
        }
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Luz_gerador") && collision.GetComponent<PolygonCollider2D>().isActiveAndEnabled)
        {
            GameObject.Find("Chave_lavanderia").transform.position=transform.position;
            GameObject.Find("Porta_D_gerador").GetComponent<Porta>().Aberto = true;
            GameObject.Find("Player").GetComponent<Movimentacao>().Textoguia.text="Parece que ele não vai mais me pertubar. Espera,ele derrubou uma chave? ";
            Destroy(this.gameObject);
        }
    }
   public void Yougondielilman()
    {
        CancelInvoke(nameof(Yougondielilman));
        {
            if (!GameObject.Find("Player").GetComponent<Movimentacao>().Standby)
            {
               
                Possoatacar = true;
                Invoke("Yougondielilman", 5f);
            }
        }
    }
}
