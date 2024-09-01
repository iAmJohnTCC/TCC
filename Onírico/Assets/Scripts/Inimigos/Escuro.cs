using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Escuro : MonoBehaviour
{
    [SerializeField] string[] Comportamentos;
    public float health = 0;
    public Vector2 posicaoPlayer;
    [SerializeField] float velo;
    public string comportamentoatual = "Nas sombras";
    string Backupcomportamento;
    // Start is called before the first frame update
    void Start()
    {
       
        Invoke(nameof(Trocadecomportamento), Random.Range(20, 60));
    }

    // Update is called once per frame
    void Update()
    {
       
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
       

        if (GameObject.Find("Player").GetComponent<Movimentacao>().Localizacao.text == "Sala do gerador")
        {
            comportamentoatual = "Boss";
            transform.position = new Vector2(25.69f, transform.position.y);
            Invoke(nameof(Trocadecomportamento), 0f);
        }
       
       
        
    }

    void Trocadecomportamento()
    {
        CancelInvoke();
        if (GameObject.Find("Player").GetComponent<Movimentacao>().Localizacao.text == "Sala do gerador")
        {
            comportamentoatual = "Boss";
            transform.position = new Vector2(25.69f, transform.position.y);
        }
        else
        {


            comportamentoatual = Comportamentos[Random.Range(1, 3)];
            posicaoPlayer = GameObject.Find("Player").transform.position;
            transform.position = new Vector2(transform.position.x, posicaoPlayer.y);
        }
        if(comportamentoatual!="Nas sombras")
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }
       
           if(comportamentoatual == "Nas sombras")
            {
                Invoke(nameof(Trocadecomportamento), Random.Range(20, 60));
            }
           else
            {

                Summon();
            }


    }
    void Summon()
    {
       
        Backupcomportamento = comportamentoatual;
        comportamentoatual = "Summon";
        if(!GameObject.Find("Player").GetComponent<Movimentacao>().Standby||GameObject.Find("Teste").GetComponent<Palhaco>().speed!>0.01f)
        {
            Animator anim =GetComponent<Animator>();
            anim.Play("Escuro_summon");
            if(Backupcomportamento=="Ataque")
            {
               Invoke(nameof(Ataque),2f);
            }
            else
            {
                if (Backupcomportamento == "Boss")
                {
                    Invoke(nameof(Boss), 2f);
                }
                else
                {
                    Invoke(nameof(Stalking), 2f);
                }
            }
            
        }
        Invoke(nameof(Trocadecomportamento), Random.Range(20, 60));
        comportamentoatual = "Nas sombras";
        
    }
    void Boss()
    {
        comportamentoatual = "Boss";
        posicaoPlayer = GameObject.Find("Player").transform.position;
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
            int i = Random.Range(0, 2);
            if (i == 0)
            {
                transform.position = new Vector2(4.18f, transform.position.y);
            }
            else
            {
                transform.position = new Vector2(25.69f, transform.position.y);
            }
            health = 10;
        }

    }

    void Nassombras()
    {
        if (GameObject.Find("Player").GetComponent<Movimentacao>().Localizacao.text == "Sala do gerador")
        {
            
            Invoke(nameof(Trocadecomportamento), 0f);
            return;
        }
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        health = 5;
    }

    void Ataque()
    {
        if (GameObject.Find("Player").GetComponent<Movimentacao>().Localizacao.text == "Sala do gerador")
        {
            
            Invoke(nameof(Trocadecomportamento), 0f);
            return;
        }
        posicaoPlayer = GameObject.Find("Player").transform.position;
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(posicaoPlayer.x, transform.position.y), velo);
        comportamentoatual = "Ataque";
      
        if (GameObject.Find("Player").GetComponent<Movimentacao>().Standby == true)
        {
            velo = 0f;
        }
        else
        {
            velo = 0.01f;
        }
        if (health <= 0)
        {
            CancelInvoke();
            comportamentoatual = "Nas sombras";
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
        if(GameObject.Find("Player").transform.position.y != transform.position.y||health<=0)
        {
            comportamentoatual = "Nas sombras";
            Nassombras();
        }
    }

    void Stalking()
    {
        if (GameObject.Find("Player").transform.position.x > gameObject.transform.position.x)
        {
            transform.localScale = new Vector3(-1, transform.localScale.y, 1);
        }
        if (GameObject.Find("Player").transform.position.x < gameObject.transform.position.x)
        {
            transform.localScale = new Vector3(1, transform.localScale.y, 1);
        }
        comportamentoatual = "Stalking";
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if(collision.gameObject.CompareTag("Luz_gerador")&&collision.GetComponent<PolygonCollider2D>().isActiveAndEnabled)
        {
            Destroy(this);
        }
    }

}
