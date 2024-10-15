using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Display_notas : MonoBehaviour
{
    [SerializeField]TMP_Text Notatexto;
    [SerializeField] TMP_Text Paginas;
    [SerializeField] GameObject Escuro;
    [SerializeField]public Notas nota;
    [SerializeField] Image imagem;
    [SerializeField] Image Notaimg;
    bool Trava;
     int Num_pagina;
    // Start is called before the first frame update
    void Start()
    {
      
       
    }

    // Update is called once per frame
    void Update()
    {
        if(nota!=null)
        {
            Notatexto.text = nota.Paginas[Num_pagina];
            
            if(Notatexto.text=="Imagem")
            {
                Notatexto.text = "";
                imagem.gameObject.SetActive(true);
                imagem.sprite = nota.imagem;
                imagem.CrossFadeAlpha(1, 1, false);

            }
            else 
            {
                imagem.gameObject.SetActive(false);
                
            }
            Paginas.text = (Num_pagina+1).ToString("00")+"/"+nota.Paginas.Length.ToString("00");
            if(Input.GetButtonDown("Horizontal"))
            {
                if(Input.GetAxisRaw("Horizontal")>0&&Num_pagina!=nota.Paginas.Length-1)
                {
                    Num_pagina+= 1;
                    imagem.CrossFadeAlpha(0, 0, false);
                   
                    Notatexto.CrossFadeAlpha(0, 0, false);
                    Notatexto.CrossFadeAlpha(1, 1, false);
                   
                       
                    

                }
                if (Input.GetAxisRaw("Horizontal") <0&&Num_pagina!=0)
                {
                    Num_pagina -= 1;
                    Notatexto.CrossFadeAlpha(0, 0, false);
                    Notatexto.CrossFadeAlpha(1, 1, false);
                   
                      
                    
                }
            }
            if(Input.GetKeyDown(KeyCode.E) && !Trava)
            {
              
                Notatexto.CrossFadeAlpha(0, 1, false);
                Paginas.CrossFadeAlpha(0, 1, false);
                Escuro.GetComponent<Image>().CrossFadeAlpha(0, 1, false);
                imagem.CrossFadeAlpha(0, 1, false);
                Notaimg.CrossFadeAlpha(1, 0, false);
                Notaimg.CrossFadeAlpha(0F, 1, false);
                Invoke("Desativar", 1f);
                if (nota.gameObject.name == "Nota_Lavanderia")
                {
                    GameObject.Find("Player").GetComponent<Movimentacao>().Textoguia.text = " Roupa rosa? onde que eu vi isso antes?";
                }
                else
                {
                    if(nota.gameObject.name == "Nota_Despensa")
                    {
                        GameObject.Find("Player").GetComponent<Movimentacao>().Textoguia.text = "Um Manequim de Roupa rosa?";
                    }
                }
                GameObject.Find("Player").GetComponent<Movimentacao>().Standby = false;
                nota = null;
            }
        }
    }
   
    public void Pegarnota (Notas note)
    {    
        nota = note;
       Notaimg.gameObject.SetActive(true);
        Notatexto.gameObject.SetActive(true);
        Escuro.SetActive(true);
        Paginas.gameObject.SetActive(true);
        GameObject.Find("Player").GetComponent<Movimentacao>().Standby=true;
        Notatexto.CrossFadeAlpha(0, 0, false);
        Paginas.CrossFadeAlpha(0, 0, false);
        Escuro.GetComponent<Image>().CrossFadeAlpha(0, 0, false);
        Notaimg.CrossFadeAlpha(0, 0, false);
        Notatexto.CrossFadeAlpha(1, 1, false);
        Paginas.CrossFadeAlpha(1, 1, false);
        Notaimg.CrossFadeAlpha(1f, 1, false);
        Escuro.GetComponent<Image>().CrossFadeAlpha(0.69f, 1, false);
        Trava = true;
        Invoke(nameof(Destravar), 2f);

        Num_pagina = 0;
      
    }   
    void Destravar()
    {
        Trava = false;
    }
    void Desativar()
    {
       
        Notatexto.gameObject.SetActive(false);
        Escuro.SetActive(false);
        Notaimg.gameObject.SetActive(false);
        Paginas.gameObject.SetActive(false);
        imagem.gameObject.SetActive(false);
    }
}
