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
    public string Backupcomportamento;
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
            velo = 0.03f;
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


        if (GameObject.Find("Player").GetComponent<Movimentacao>().Localizacao == "Sala do gerador"&&comportamentoatual!="Boss")
        {
            Trocadecomportamento();
        }



    }

    void Trocadecomportamento()
    {
        CancelInvoke();
        this.gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        if (GameObject.Find("Player").GetComponent<Movimentacao>().Localizacao== "Sala do gerador")
        {
            comportamentoatual = "Boss";
            transform.position = new Vector2(4.18f, GameObject.Find("Player").transform.position.y);
        }
        else
        {


            comportamentoatual = Comportamentos[Random.Range(1, 3)];
            posicaoPlayer = GameObject.Find("Player").transform.position;
            transform.position = new Vector2( posicaoPlayer.x-1f, posicaoPlayer.y);
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

            Animator anim = GetComponent<Animator>();
            anim.Play("Escuro_summon");
            if (comportamentoatual != "Boss")
            {
                Invoke(nameof(Trocadecomportamento), Random.Range(20, 60));
            }
        }


    }
    void Summon()
    {
       this.gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        health = 5;
        Backupcomportamento = comportamentoatual;
        comportamentoatual = "Summon";
        
            
            if(Backupcomportamento=="Ataque")
            {
               Invoke(nameof(Ataque),2f);
                Invoke(nameof(Trocadecomportamento), Random.Range(20, 60));
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
                    Invoke(nameof(Trocadecomportamento), Random.Range(20, 60));
                }
            }
            
    }
        
        
        
    
    void Boss()
    {
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
        if (GameObject.Find("Player").GetComponent<Movimentacao>().Localizacao == "Sala do gerador")
        {
            
            Invoke(nameof(Trocadecomportamento), 0f);
            return;
        }
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        health = 5;
    }

    void Ataque()
    {
       
        if (GameObject.Find("Player").GetComponent<Movimentacao>().Localizacao == "Sala do gerador")
        {
            
            Invoke(nameof(Trocadecomportamento), 0f);
            return;
        }
        posicaoPlayer = GameObject.Find("Player").transform.position;
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(posicaoPlayer.x, transform.position.y), velo);
        comportamentoatual = "Ataque";
      
        
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
       if(GameObject.Find("Player").transform.position.y != transform.position.y||health<=0)
        {
 this.gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
            comportamentoatual = "Nas sombras";
            Nassombras();
        }
        comportamentoatual = "Stalking";
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
