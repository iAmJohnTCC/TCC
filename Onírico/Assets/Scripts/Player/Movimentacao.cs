using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;


public class Movimentacao : MonoBehaviour
{
    [Header("Movimentação")]
     public float Velocidade=6;
     float horizontal;
    public bool Standby=false;
    public bool Morte = false;
    public bool susto=false;
    Rigidbody2D Rb;
    public bool escondido = false;
    bool podeseesconder=true;

    [Header("Itens")]
    [SerializeField] public GameObject Item_Atual;
    public int Numeroitem=0;
    [SerializeField] public GameObject[] Inventario;
    public int Espaco_Livre;


    [Header("Outros")]
    public RaycastHit2D Hit;
    [SerializeField] Light2D light;
    public bool lanterna = false;
   public Porta porta;
    GameObject esconderijo;
    [SerializeField] LayerMask interagiveis;
[SerializeField] public GameObject Mapa;




    [Header("Localização")]
     public string Localizacao;
     public string AndarAtual;
    [SerializeField]TMP_Text hudlocalizacao,hudandaratual;
    
    [Header("HUD")]
    [SerializeField] GameObject Hud_inventario;
    [SerializeField] Image Itematual;
     [SerializeField] Sprite Semitem;
    public TMP_Text Textoguia;
    bool InventarioAberto = false;

   

    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
        
    }
    void Update()
    {

       
        if (Standby && escondido && Input.GetKeyDown(KeyCode.E)&&podeseesconder)
        {
            podeseesconder = false;
            GameObject.Find("GameController").GetComponent<GameController>().Fadeout(1f,true);
            Invoke(nameof(Escondido), 1.1f);
        }
        Item_Atual = Inventario[Numeroitem];
        if(Input.GetKeyDown(KeyCode.Tab))
          {
            if(Hud_inventario.activeSelf)
              {
                Hud_inventario.SetActive(false);
                Itematual.gameObject.transform.parent.gameObject.SetActive(true);
                if (Inventario[Numeroitem] != null)
                {
                    Itematual.sprite = Inventario[Numeroitem].GetComponent<SpriteRenderer>().sprite;
                    Itematual.color = Inventario[Numeroitem].GetComponent<SpriteRenderer>().color;
                }
                else
                {
                    Itematual.sprite = null;
                    Itematual.color = new Color(1, 1, 1,0);
                }
            }
             else
              {
                Itematual.gameObject.transform.parent.gameObject.SetActive(false);
               Hud_inventario.SetActive(true);
              }

          }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {


            Numeroitem = 0;

        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {


                Numeroitem = 1;
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Alpha3))
                {


                    Numeroitem = 2;
                }
                else
                {
                    if (Input.GetKeyDown(KeyCode.Alpha4))
                    {
                        Numeroitem = 3;
                    }
                    else
                    {
                        if (Input.GetKeyDown(KeyCode.Alpha5))
                        {
                            Numeroitem = 4;
                        }
                    }
                }
            }
        }
        for (int i = 0; i < Inventario.Length; i++)
        {
            if (Inventario[i] == null)
            {
                Espaco_Livre = i;
                break;
            }
            else
            {
                Espaco_Livre = 5;
            }
        }
           if(Inventario[Numeroitem]!=null)
           {
             Itematual.sprite=Inventario[Numeroitem].GetComponent<SpriteRenderer>().sprite;
             Itematual.color= Inventario[Numeroitem].GetComponent<SpriteRenderer>().color;
        }
           else
           {
             Itematual.sprite=null;
            Itematual.color = new Color(1,1,1,0);
           }
         
        if (Item_Atual != null && Item_Atual.name == "Lanterna")
        {
            gameObject.GetComponent<Lanterna>().enabled = true;
        }
        else
        {

            gameObject.GetComponent<Lanterna>().enabled = false;
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (Mapa.activeSelf)
            {
                Mapa.SetActive(false);
                GameObject.Find("CM_Mapa").GetComponent<Mapa>().Minimapa = true;
                if(Standby)
                { Standby = false; }
            }
            else
            {
                if (!Standby)
                {
                    Standby = true;
                    Mapa.SetActive(true);
                    GameObject.Find("CM_Mapa").GetComponent<Mapa>().Minimapa = false;
                }
            }
        }
        if (!Standby)
        {
            if(Input.anyKey)
            {
                 Inputs();
            }
  
        }

    }
    void Inputs()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        if (Input.GetKeyDown(KeyCode.E))
        {
            Interagir();
        }
        if (Input.GetKeyDown(KeyCode.X)&& Inventario[Numeroitem]!=null)
        {
            Instantiate(Inventario[Numeroitem],new Vector2(transform.position.x,transform.position.y-1.2f),Quaternion.identity);
            Inventario[Numeroitem] = null;
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Rb.velocity = 1.5f * horizontal * Velocidade * Vector2.right;
        }

        else
        {
            Rb.velocity = horizontal * Velocidade * Vector2.right;
        }

        if (horizontal != 0)
        {
            transform.localScale = new Vector3(horizontal, 1, 1);
        }
     


      

        
    }
    void Interagir()
    {
        Hit = Physics2D.Raycast(new Vector2(transform.position.x,transform.position.y-0.2f), new Vector2(transform.localScale.x, 0f), 1.5f, interagiveis);

        if (Hit.transform != null )
        {

                        if(Hit.transform.GetComponent<Interagiveis>()!=null)
                        {
                         Hit.transform.GetComponent<Interagiveis>().Interacao(this);
                        }
                   
                            else
                            {
                                if (Hit.transform.gameObject.CompareTag("Esconderijo") && podeseesconder)
                                {
                                    esconderijo = Hit.transform.gameObject;
                                   
                                    GameObject.Find("GameController").GetComponent<GameController>().Fadeout(1f,true);
                                    Invoke(nameof(Escondido), 1.1f);

                                }
                                else
                                {
                                    if (Hit.transform.gameObject.CompareTag("Luz_gerador"))
                                    {
                                        GameObject.Find("GameController").GetComponent<GameController>().Ligarluz(Hit.transform.gameObject);

                                    }
                               
                                }

                            }
        }
    }
            

        
    public void Susto()
    {
        susto = true;
        Invoke(nameof(Nahidwin), 0.9f);
    }
    void Nahidwin()
    {
        susto=false;
    }
    
    void Escondido()
    {
        if (!escondido)
        {
            GameObject.Find("Sons_de_fundo").GetComponent<Fundo_sons>().Sons(10);
            transform.position = esconderijo.transform.position;
            escondido = true;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            Velocidade = 0;
            Standby = true;
            

        }
        else
        {

            escondido = false;
            Standby = false;
            podeseesconder = false;
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            Velocidade = 6;
            Invoke(nameof(Cooldown), 2f);
        }
    }
   public void Teleporte()
    {
        
        Standby = false;
       
        transform.position = porta.posicao.transform.position;

        Localizacao = porta.Localizacao;
        GameObject.Find("Main Camera").GetComponent<Camera_posicoes>().Trocarcamera(Localizacao);
        if (porta.Andaratual != "")
        {
            AndarAtual = porta.Andaratual;
        }
        porta = null;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Sópracozinha"))
        {
            Localizacao=collision.gameObject.GetComponent<Porta>().Localizacao;
            GameObject.Find("Main Camera").GetComponent<Camera_posicoes>().Trocarcamera(Localizacao);
        }
        if(collision.CompareTag("Morte"))
        {
            Morte = true;
             gameObject.GetComponent<SpriteRenderer>().enabled = true;
             escondido=false;
            Invoke(nameof(morrer), 5f);
            Standby = true;
        }
    }

    public void AdicionarItem(GameObject ItemAdicionar)
    {
        for (int i = 0; i < Inventario.Length; i++)
        {
            if (Inventario[i] == null)
            {
                Inventario[Espaco_Livre] = ItemAdicionar;
                break;
            }
        }
 for (int i = 0; i < Inventario.Length; i++)
        {
            if (Inventario[i] == null)
            {
                Espaco_Livre = i;
                break;
            }
            else
            {
              Espaco_Livre=5;
            }
        }
    }
    void Cooldown()
    {
        podeseesconder = true;
    }
    private void morrer()
    {
        GameObject.Find("GameController").GetComponent<GameController>().Morte();
    }

}
