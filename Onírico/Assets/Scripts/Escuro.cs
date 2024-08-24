using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escuro : MonoBehaviour
{
    [SerializeField]string[]Comportamentos;
    public float health = 0;
    public Vector2 posicaoPlayer;
    [SerializeField] float velo;
    public string comportamentoatual="Nas sombras";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Player").transform.position.x > gameObject.transform.position.x)
        {
            transform.localScale = new Vector3(-1, transform.localScale.y, 1);
        }
        if (GameObject.Find("Player").transform.position.x < gameObject.transform.position.x)
        {
            transform.localScale = new Vector3(1, transform.localScale.y, 1);
        }
        if (comportamentoatual != "Nas sombras"&&GameObject.Find("Player").transform.position.y!=transform.position.y)
        {
            comportamentoatual = "Nas sombras";
            Invoke(nameof(Trocadecomportamento), Random.Range(20, 60));
        }
       
        if(GameObject.Find("Player").GetComponent<Movimentacao>().Standby==true)
        {
            velo = 0f;
        }
        else
        {
            velo = 0.01f;
        }
        if(comportamentoatual=="Nas sombras")
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }
       
        if(comportamentoatual=="Ataque"||comportamentoatual=="Boss")
        {
            posicaoPlayer = GameObject.Find("Player").transform.position;
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(posicaoPlayer.x, transform.position.y), velo);
        }

        if(health<=0&&comportamentoatual!="Boss")
        {
            CancelInvoke();
            comportamentoatual = "Nas sombras";
            health = 5;
            Invoke(nameof(Trocadecomportamento), Random.Range(20, 60));
        }
        if (GameObject.Find("Player").GetComponent<Movimentacao>().Localizacao.text == "Sala do gerador"&&comportamentoatual!="Boss")
        {
            comportamentoatual = "Boss";
            transform.position = new Vector2(25.69f, transform.position.y);
        }
        if (comportamentoatual=="Boss"&& health<=0)
        {
            int i = Random.Range(0, 2);
            if(i==0)
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

    void Trocadecomportamento()
    {
        CancelInvoke();
        comportamentoatual = Comportamentos[Random.Range(1, 3)];
        posicaoPlayer = GameObject.Find("Player").transform.position;       
        transform.position=new Vector2(transform.position.x,posicaoPlayer.y);
        Invoke(nameof(Trocadecomportamento), Random.Range(20, 60));
       
    }
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if(collision.gameObject.CompareTag("Luz_gerador")&&collision.GetComponent<PolygonCollider2D>().isActiveAndEnabled)
        {
            Destroy(this);
        }
    }

}
