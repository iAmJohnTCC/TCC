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
            if(Input.GetKeyDown(KeyCode.Escape))
            {
              
                Notatexto.CrossFadeAlpha(0, 1, false);
                Paginas.CrossFadeAlpha(0, 1, false);
                Escuro.GetComponent<Image>().CrossFadeAlpha(0, 1, false);
                imagem.CrossFadeAlpha(0, 1, false);
                Invoke("Desativar", 1f);
                GameObject.Find("Player").GetComponent<Movimentacao>().Standby = false;
                nota = null;
            }
        }
    }
   
    public void Pegarnota (Notas note)
    {    
        nota = note;
       
        Notatexto.gameObject.SetActive(true);
        Escuro.SetActive(true);
        Paginas.gameObject.SetActive(true);
        GameObject.Find("Player").GetComponent<Movimentacao>().Standby=true;
        Notatexto.CrossFadeAlpha(0, 0, false);
        Paginas.CrossFadeAlpha(0, 0, false);
        Escuro.GetComponent<Image>().CrossFadeAlpha(0, 0, false);
        Notatexto.CrossFadeAlpha(1, 1, false);
        Paginas.CrossFadeAlpha(1, 1, false);
        Escuro.GetComponent<Image>().CrossFadeAlpha(0.69f, 1, false);



        Num_pagina = 0;
      
    }   
    void Desativar()
    {
        Notatexto.gameObject.SetActive(false);
        Escuro.SetActive(false);
        Paginas.gameObject.SetActive(false);
        imagem.gameObject.SetActive(false);
    }
}
