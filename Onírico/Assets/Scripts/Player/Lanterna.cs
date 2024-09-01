using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using TMPro;
public class Lanterna : MonoBehaviour
{
    public GameObject Luz;
    [SerializeField]int Energia;
    [SerializeField]int Qtd_Pilha;
    [SerializeField] Animator Stun;
    [SerializeField] TMP_Text Porcentagem;
    public bool Stunning=false;
    RaycastHit2D Hit;
    [SerializeField]LayerMask Inimigos;
    // Start is called before the first frame update
    void Start()
    {
        Luz.SetActive(false);
        Porcentagem = GameObject.Find("Hud_bateria").GetComponent<TMP_Text>();
    }
    private void OnDisable()
    {
        Luz.SetActive(false);
        Stunning = false;
    }
    // Update is called once per frame
    void Update()
    {
        
        if(Qtd_Pilha>0 && Input.GetKeyDown(KeyCode.R)&&Energia==0)
        {
            Energia = 100;
            Qtd_Pilha--;
            Stunning=false;
            CancelInvoke();
        }
        if(GameObject.Find("Player").GetComponent<Movimentacao>().Standby == true)
        {
            Luz.SetActive(false);
            CancelInvoke();
        }
        Porcentagem.text = Energia.ToString() + "%";

        if (Input.GetKeyDown(KeyCode.F) && Energia>0)
        {
            if (Luz.activeSelf == true)
            {
                Luz.SetActive(false);
                CancelInvoke();
                
            }

            else
            {
                Luz.SetActive(true);
                InvokeRepeating(nameof(Perdaenergia), 0f, 4f);
            }
        }
       if(Luz.activeSelf)
        {
            Hit = Physics2D.Raycast(transform.position, new Vector2(transform.localScale.x, 0f), 5f, Inimigos);
            {
                if (Hit )
                {
                    if (Hit.transform.gameObject.GetComponent<Escuro>() != null && Hit.transform.gameObject.GetComponent<Escuro>().comportamentoatual != "Nas sombras")
                    {
                        if (!Stunning)
                        {
                            Hit.transform.gameObject.GetComponent<Escuro>().health -= 20 * Time.deltaTime;
                        }
                        else
                        {
                            Hit.transform.gameObject.GetComponent<Escuro>().health = 0;
                        }
                    }
                    else
                    {
                        if(Hit.transform.gameObject.GetComponent<Palhaco>()&&Stunning)
                        {
                            Hit.transform.gameObject.GetComponent<Palhaco>().Stun();
                        }
                    }
                }
            }
        }
       if(Energia==0 && !Stunning)
        {
            Invoke(nameof(Perdaenergia), 0f);
        }
        if (Input.GetKeyDown(KeyCode.Space)&& Energia>0&&Luz.activeSelf==true&&!Stunning)
        {
            Stun.Play("Laterna_Stun");
            Invoke(nameof(Lettherebelight), 0.1f);
        }
        
    }
    void Perdaenergia()
    { 
     if(Energia>0)
        {
            if(GameObject.Find("Player").GetComponent<Movimentacao>().Standby == false&&!Stunning)
            {
                Energia -= 5;
            }
     
        }
     else
        {
            Luz.SetActive(false);
            CancelInvoke();
        }
    }
    void Lettherebelight()
    {
       Stunning=true;
        Energia -= 50;
       if(Energia>0)
        {
         Invoke(nameof(Cooldown), 0.6f);
        }
       if(Energia<=0)
        {
         Energia=0;
            CancelInvoke(nameof(Perdaenergia));
            Invoke(nameof(Perdaenergia), 0.5f);
        }
       
    }
   void Cooldown()
   {
    Stunning=false; 
   }
}
