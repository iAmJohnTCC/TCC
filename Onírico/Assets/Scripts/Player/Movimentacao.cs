using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Rendering.Universal;



public class Movimentacao : MonoBehaviour
{
    [Header("Movimentação")]
     float Velocidade=6;
     float horizontal;
    public bool Standby=false;
    public bool Morte = false;
    Rigidbody2D Rb;
    public bool escondido = false;

    [Header("Itens")]
    [SerializeField] public GameObject Item_Atual;
    [SerializeField] public GameObject[] Inventario;
    public int Espaco_Livre;


    [Header("Outros")]
    public RaycastHit2D Hit;
    [SerializeField] Light2D light;
    public bool lanterna = false;
   public Porta porta;
    GameObject esconderijo;
    [SerializeField] LayerMask interagiveis;




    [Header("Localização")]
     public string Localizacao;
     public string AndarAtual;
    [SerializeField]TMP_Text hudlocalizacao,hudandaratual;
    
    [Header("HUD")]
    [SerializeField] GameObject Hud_inventario;
    public TMP_Text Textoguia;
    bool InventarioAberto = false;

   

    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
        Item_Atual = null;
    }
    void Update()
    {

        hudandaratual.text = AndarAtual;
        hudlocalizacao.text = Localizacao;
        if (Standby && escondido && Input.GetKeyDown(KeyCode.E))
        {
            GameObject.Find("GameController").GetComponent<GameController>().Fadeout(0.8f);
            Invoke(nameof(Escondido), 0.9f);
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
        if (Input.GetKeyDown(KeyCode.X)&& Inventario[0]!=null)
        {
            Instantiate(Inventario[0],(Vector2)transform.position,Quaternion.identity);
            Inventario[0] = null;
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

       
        GameObject ItemAnterior;
        Item_Atual = Inventario[0];
        if (Input.GetKeyDown(KeyCode.Alpha1) && Inventario[1] != null)
        {
            ItemAnterior = Item_Atual;
            Inventario[0] = Inventario[1];
            Inventario[1] = ItemAnterior;
        }
        else
      {
        if (Input.GetKeyDown(KeyCode.Alpha2) && Inventario[2] != null)
        {
            ItemAnterior = Item_Atual;
            Inventario[0] = Inventario[2];
            Inventario[2] = ItemAnterior;
        }
         else
        {
        if (Input.GetKeyDown(KeyCode.Alpha3) && Inventario[3] != null)
        {
            ItemAnterior = Item_Atual;
            Inventario[0] = Inventario[3];
            Inventario[3] = ItemAnterior;
        }
        else
     {
        if (Input.GetKeyDown(KeyCode.Alpha4) && Inventario[4] != null)
        {
            ItemAnterior = Item_Atual;
            Inventario[0] = Inventario[4];
            Inventario[4] = ItemAnterior;
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
              Espaco_Livre=5;
            }
        }
        if (Item_Atual!=null&&Item_Atual.name == "Lanterna")
        {
            gameObject.GetComponent<Lanterna>().enabled = true;
        }
        else
        { 
           
            gameObject.GetComponent<Lanterna>().enabled = false;
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {

            if (InventarioAberto)
            {
                Hud_inventario.SetActive(false);
                InventarioAberto = false;
            }

            else
            {
                Hud_inventario.SetActive(true);
                InventarioAberto = true;
            }

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
                                if (Hit.transform.gameObject.CompareTag("Esconderijo") //&& Hit.transform.gameObject.GetComponent<Insetos>().TemInsetos == true
                                                                                           )
                                {
                                    esconderijo = Hit.transform.gameObject;
                                   
                                    GameObject.Find("GameController").GetComponent<GameController>().Fadeout(0.8f);
                                    Invoke(nameof(Escondido), 0.9f);

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
            

        

    
    void Escondido()
    {
        if (!escondido)
        {
            transform.position = esconderijo.transform.position;
            escondido = true;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            Rb.isKinematic = true;
            Standby = true;
            gameObject.GetComponent<CapsuleCollider2D>().isTrigger = true;

        }
        else
        {

            escondido = false;
            Standby = false;
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            Rb.isKinematic = false;
            gameObject.GetComponent<CapsuleCollider2D>().isTrigger = false;
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

    private void morrer()
    {
        GameObject.Find("GameController").GetComponent<GameController>().Morte();
    }

}
