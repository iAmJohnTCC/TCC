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
    // [SerializeField] public string [] ItemAtual;
    [SerializeField] public GameObject Item_Atual;
    [SerializeField] public GameObject[] Inventario;
    public int Espaco_Livre;


    [Header("Outros")]
    RaycastHit2D Hit;
    [SerializeField] Light2D light;
    public bool lanterna = false;
    Porta porta;
    GameObject esconderijo;
    [SerializeField] LayerMask interagiveis;


    [Header("Localização")]
     public TMP_Text Localizacao;
     public TMP_Text AndarAtual;

    [Header("HUD")]
    [SerializeField] GameObject RESIDENTEVIL6INVENTARIO;
    bool InventarioAberto = false;

   

    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {

        GameObject ItemAnterior;

        if (Standby && escondido && Input.GetKeyDown(KeyCode.E))
        {
            GameObject.Find("GameController").GetComponent<GameController>().Fadeout(0.5f);
            Invoke(nameof(Escondido), 0.51f);
        }

        if (!Standby)
        {
            horizontal = Input.GetAxisRaw("Horizontal");

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


            if (Input.GetKeyDown(KeyCode.Tab))
            {

                if (InventarioAberto)
                {
                    RESIDENTEVIL6INVENTARIO.SetActive(false);
                    InventarioAberto = false;
                }

                else
                {
                    RESIDENTEVIL6INVENTARIO.SetActive(true);
                    InventarioAberto = true;
                }

            }

            //if (ItemAtual[0] == "Vela" && ItemAtual[1] == "Acendedor_de_fogão")

            //{
            //    ItemAtual[0] = "Velaacesa";
            //    ItemAtual[1] = "";
            //}

            //if (ItemAtual[0] == "Chave_lavanderia")
            //{
            //    light.intensity = 0.18f;
            //}

            if (Input.GetKeyDown(KeyCode.E))
            {
                Interagir();
            }

           

        }

    }
    void Interagir()
    {
        Hit = Physics2D.Raycast(transform.position, new Vector2(transform.localScale.x, 0f), 1.5f, interagiveis);

        if (Hit.transform != null )
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
                    //if (porta.CompareTag("PortaComTeia") && !porta.Aberto && ItemAtual[0] == "Velaacesa")
                    //{
                    //    Destroy(porta.Bloqueio);
                    //    porta.Aberto = true;
                    //}

                    //if (porta.Iten_desbloqueio == ItemAtual[0] && !porta.CompareTag("PortaComTeia"))
                    //{
                    //    porta.Aberto = true;
                    //}
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
                    if (Hit.transform.gameObject.CompareTag("Esconderijo"))
                    {
                        esconderijo = Hit.transform.gameObject;
                        Standby = true;
                        GameObject.Find("GameController").GetComponent<GameController>().Fadeout(0.5f);
                        Invoke(nameof(Escondido), 0.7f);
                        
                    }
                    else
                    {
                        if(Hit.transform.gameObject.CompareTag("Luz_gerador"))
                        {
                            GameObject.Find("GameController").GetComponent<GameController>().Ligarluz(Hit.transform.gameObject);

                        }
                        else
                        {
                            if(Hit.transform.gameObject.name== "Puzzle_Qt_irma")
                            {
                                Hit.transform.gameObject.GetComponent<Puzzle_qt_irma>().Iniciar();
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
        }
        else
        {

            escondido = false;
            Standby = false;
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }
    }
    void Teleporte()
    {
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
