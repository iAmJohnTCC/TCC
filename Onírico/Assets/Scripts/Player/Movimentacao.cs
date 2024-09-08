using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using TMPro;
using UnityEngine.Rendering.Universal;
using UnityEditor.Experimental.GraphView;


public class Movimentacao : MonoBehaviour
{
    [Header("Movimentação")]
     float Velocidade=6;
     float horizontal;
    public bool Standby=false;
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
    Porta porta;
    GameObject esconderijo;
    [SerializeField] LayerMask interagiveis;



    [Header("Localização")]
     public TMP_Text Localizacao;
     public TMP_Text AndarAtual;

    [Header("HUD")]
    [SerializeField] GameObject Hud_inventario;
    bool InventarioAberto = false;

   

    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
        Item_Atual = null;
    }
    void Update()
    {

       

        if (Standby && escondido && Input.GetKeyDown(KeyCode.E))
        {
            GameObject.Find("GameController").GetComponent<GameController>().Fadeout(0.5f);
            Invoke(nameof(Escondido), 0.51f);
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

        for (int i = 0; i < Inventario.Length; i++)
        {
            if (Inventario[i] == null)
            {
                Espaco_Livre = i;
                break;
            }
        }
        GameObject ItemAnterior;
        Item_Atual = Inventario[0];
        if (Input.GetKeyDown(KeyCode.Alpha1) && Inventario[1] != null)
        {
            ItemAnterior = Item_Atual;
            Inventario[0] = Inventario[1];
            Inventario[1] = ItemAnterior;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && Inventario[2] != null)
        {
            ItemAnterior = Item_Atual;
            Inventario[0] = Inventario[2];
            Inventario[2] = ItemAnterior;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && Inventario[3] != null)
        {
            ItemAnterior = Item_Atual;
            Inventario[0] = Inventario[3];
            Inventario[3] = ItemAnterior;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4) && Inventario[4] != null)
        {
            ItemAnterior = Item_Atual;
            Inventario[0] = Inventario[3];
            Inventario[3] = ItemAnterior;
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
        Hit = Physics2D.Raycast(transform.position, new Vector2(transform.localScale.x, 0f), 1.5f, interagiveis);

        if (Hit.transform != null )
        {
            if (Hit.transform.gameObject.GetComponent<Maquinas_de_lavar>() != null  )
            {
                if (Item_Atual != null && Item_Atual.GetComponent<scr_roupas>() != null)
                {

                    Hit.transform.gameObject.GetComponent<Maquinas_de_lavar>().colocar();
                }
            }
            else
            {
                if (Hit.transform.gameObject.GetComponent<Item2>() != null&& Hit.transform.gameObject.GetComponent<Item2>().enabled)
                {
                    Hit.transform.gameObject.GetComponent<Item2>().Adicionarinventario(this);
                }
                else
                {
                    if (Hit.transform.gameObject.GetComponent<Porta>() != null && !Hit.transform.gameObject.CompareTag("Sópracozinha"))
                    {
                        porta = Hit.transform.gameObject.GetComponent<Porta>();

                        if (porta.Aberto)
                        {
                            GameObject.Find("GameController").GetComponent<GameController>().Fadeout(1.4f);
                            Invoke(nameof(Teleporte), 1.5f);
                        }
                        else
                        {
                            if (porta.name == "Escada_bloqueada" && Item_Atual.name == "Vela_Acesa")
                            {
                                Destroy(porta.Bloqueio);
                                porta.Aberto = true;
                            }
                        }


                    }
                    else
                    {

                        porta = null;

                        if (Hit.transform.gameObject.GetComponent<Notas>() != null)
                        {
                            GameObject.Find("Display_notas").GetComponent<Display_notas>().Pegarnota(Hit.transform.gameObject.GetComponent<Notas>());
                        }
                        else
                        {
                            if (Hit.transform.gameObject.CompareTag("Esconderijo") && Hit.transform.gameObject.GetComponent<Insetos>().TemInsetos == true)
                            {
                                esconderijo = Hit.transform.gameObject;
                                Standby = true;
                                GameObject.Find("GameController").GetComponent<GameController>().Fadeout(0.5f);
                                Invoke(nameof(Escondido), 0.7f);

                            }
                            else
                            {
                                if (Hit.transform.gameObject.CompareTag("Luz_gerador"))
                                {
                                    GameObject.Find("GameController").GetComponent<GameController>().Ligarluz(Hit.transform.gameObject);

                                }
                                else
                                {
                                    if (Hit.transform.gameObject.name == "Puzzle_Qt_irma")
                                    {
                                        Hit.transform.gameObject.GetComponent<Puzzle_qt_irma>().Iniciar();
                                    }
                                }
                            }

                        }

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
    void Teleporte()
    {
        Standby = false;
        transform.position = porta.posicao.transform.position;

        Localizacao.text = porta.Localizacao;

        if (porta.Andaratual != "")
        {
            AndarAtual.text = porta.Andaratual;
        }
        porta = null;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Sópracozinha"))
        {
            Localizacao.text=collision.gameObject.GetComponent<Porta>().Localizacao;
        }
    }

    public void AdicionarItem(GameObject ItemAdicionar)
    {
        for (int i = 0; i < Inventario.Length; i++)
        {
            if (Inventario[i] == null)
            {
                Inventario[Espaco_Livre] = ItemAdicionar;
            }
        }
    }


}
