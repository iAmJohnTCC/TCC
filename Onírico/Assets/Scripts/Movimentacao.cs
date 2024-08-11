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

    [Header("Itens")]
    [SerializeField] public string [] ItemAtual;
    

    [Header("Outros")]
    RaycastHit2D Hit;
    [SerializeField] Light2D light;
    public bool lanterna = false;


    [Header("Localização")]
    [SerializeField] public TMP_Text Localizacao;
    [SerializeField] public TMP_Text AndarAtual;
    
   
    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (!Standby)
        {
            horizontal = Input.GetAxisRaw("Horizontal");

            if (Input.GetKey(KeyCode.LeftShift))
            {
                Rb.velocity = Vector2.right * horizontal * Velocidade * 1.5f;
            }

            else
            {
                Rb.velocity = Vector2.right * horizontal * Velocidade;
            }

            if (horizontal != 0)
            {
                transform.localScale = new Vector3(horizontal, 1, 1);
            }


            if (ItemAtual[0] == "Vela" && ItemAtual[1] == "Acendedor_de_fogão")

            {
                ItemAtual[0] = "Velaacesa";
                ItemAtual[1] = "";
            }

            if (ItemAtual[0] == "Chave_lavanderia")
            {
                light.intensity = 0.18f;
            }

            Hit = Physics2D.Raycast(transform.position, new Vector2(transform.localScale.x, 0f), 1.5f);

            if (Hit.transform != null && Input.GetKeyDown(KeyCode.E))
            {
                if (Hit.transform.gameObject.GetComponent<Porta>() != null && !Hit.transform.gameObject.CompareTag("Sópracozinha"))
                {
                    Porta porta = Hit.transform.gameObject.GetComponent<Porta>();

                    if (porta.Aberto)
                    {
                        transform.position = porta.posicao.transform.position;

                        Localizacao.text = porta.Localizacao;

                        if (porta.Andaratual != "")
                        {
                            AndarAtual.text = porta.Andaratual;
                        }
                    }

                    else
                    {
                        if (porta.CompareTag("PortaComTeia") && !porta.Aberto && ItemAtual[0] == "Velaacesa")
                        {
                            Destroy(porta.Bloqueio);
                            porta.Aberto = true;
                        }

                        if (porta.Iten_desbloqueio == ItemAtual[0] && !porta.CompareTag("PortaComTeia"))
                        {
                            porta.Aberto = true;
                        }
                    }
                }
                else
                {
                    if (Hit.transform.gameObject.GetComponent<Notas>() != null)
                    {
                        GameObject.Find("Display_notas").GetComponent<Display_notas>().Pegarnota(Hit.transform.gameObject.GetComponent<Notas>());
                    }
                }
            }

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Sópracozinha"))
        {
            Localizacao.text=collision.gameObject.GetComponent<Porta>().Localizacao;
        }
    }
}
