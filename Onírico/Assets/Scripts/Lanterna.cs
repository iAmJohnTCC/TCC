using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using TMPro;
public class Lanterna : MonoBehaviour
{
    [SerializeField] GameObject Luz;
    [SerializeField]int Energia;
    [SerializeField]int Qtd_Pilha;
    [SerializeField] Animator Stun;
    [SerializeField] TMP_Text Porcentagem;
    // Start is called before the first frame update
    void Start()
    {
        Luz.SetActive(false);
       
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Qtd_Pilha>0 && Input.GetKeyDown(KeyCode.R)&&Energia==0)
        {
            Energia = 100;
            Qtd_Pilha--;
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
                InvokeRepeating("Perdaenergia", 0f, 4f);
            }
        }
        if(Input.GetKeyDown(KeyCode.Space)&& Energia>50&&Luz.active==true)
        {
            Stun.Play("Laterna_Stun");
            Invoke("Lettherebelight", 0.1f);
        }
        
    }
    void Perdaenergia()
    { 
     if(Energia>0)
        {
            Energia -= 5;

            if(Energia==0)
            {
                Luz.SetActive(false);
                CancelInvoke();
            }
        }
     else
        {
            CancelInvoke();
        }
    }
    void Lettherebelight()
    {
       
        Energia -= 50;
    }
}
