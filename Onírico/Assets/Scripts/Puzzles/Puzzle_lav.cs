using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle_lav : MonoBehaviour
{
    public GameObject[] roupas=new GameObject[3];
    [SerializeField]GameObject Rouparosa;
    public GameObject[] roupassujas = new GameObject[3];
     public void Combinar()
    {
        scr_roupas[] cores= new scr_roupas[3];
        if (roupas[0] != null)
        {
            cores[0] = roupas[0].GetComponent<scr_roupas>();
        }
        else
        {
            cores[0] = null;
        }
        if (roupas[1] != null)
        {
            cores[1] = roupas[1].GetComponent<scr_roupas>();
        }
        else
        {
            cores[1] = null;
        }
        if (roupas[2] != null)
        {
            cores[2] = roupas[2].GetComponent<scr_roupas>();
        }
        else
        {
            cores[2] = null;
        }
        if (cores!=null)
        {
            if (cores[2] != null)
            {
                if (cores[0].tipocor == "Prim�ria" && cores[1].tipocor == "Prim�ria" && cores[2].tipocor == "Prim�ria")
                {
                    cores[0].R = 1; cores[0].G = 1; cores[0].B = 1;
                    cores[0].tipocor = "Branco";
                }
                else
                {
                    cores[0].R = 0; cores[0].G = 0; cores[0].B = 0;
                    cores[0].tipocor = "Preto";
                }


            }
            else
            {
                if (cores[1] != null)
                {
                    if (cores[0].tipocor == "Prim�ria" && cores[1].tipocor=="Prim�ria")
                    {
                        cores[0].R += cores[1].R; cores[0].G += cores[1].G; cores[0].B += cores[1].B;

                        cores[0].tipocor = "Secund�ria";
                    }
                    else
                    {
                        if (cores[0].tipocor == "Secund�ria" && cores[1].tipocor=="Secund�ria")
                        {
                            cores[0].R += cores[1].R-1; cores[0].G += cores[1].G-1; cores[0].B += cores[1].B-1;
                            cores[0].tipocor = "Prim�ria";
                        }
                        else
                        {
                            if (cores[0].tipocor == "Prim�ria" && cores[1].tipocor == "Secund�ria" ||
                                cores[0].tipocor == "Secund�ria" && cores[1].tipocor == "Prim�ria")
                            {
                                cores[0].R -= cores[1].B; cores[0].G += cores[1].R; cores[0].B -= cores[1].G;
                                cores[0].tipocor = "Prim�ria";
                            }
                            else
                            {

                                if (cores[1].tipocor == "Branco")
                                {
                                    cores[0].R += 0.5f; cores[0].G += 0.5f; cores[0].B += 0.5f;
                                    cores[0].tipocor = "Secund�ria";
                                }
                                else
                                {
                                    if (cores[0].tipocor == "Branco")
                                    {
                                        cores[0].R = 0.5f+cores[1].R; cores[0].G = 0.5f + cores[1].G; ; cores[0].B = 0.5f + cores[1].B; ;
                                    }
                                    else
                                    {
                                        cores[0].R = 0; cores[0].G = 0; cores[0].B = 0;
                                        cores[0].tipocor = "Preto";
                                        GameObject.Find("Player").GetComponent<Movimentacao>().Textoguia.text = "Acho que n�o era para a roupa ficar preta, � melhor eu fazer a roupa voltar a cor original";
                                    }
                                }
                            }
                        }
                    }

                }
               
            }
            cores[0].R=Mathf.Clamp(cores[0].R,0,1);
            cores[0].G=Mathf.Clamp(cores[0].G,0,1);
             cores[0].B=Mathf.Clamp(cores[0].B,0,1);
            if (roupas[0]!=null)
            {
                roupas[0].GetComponent<scr_roupas>().tipocor = cores[0].tipocor;
                roupas[0].GetComponent<scr_roupas>().Mudarcor(cores[0].R, cores[0].G, cores[0].B);
                roupas[0].GetComponent<BoxCollider2D>().enabled = true;
                if (cores[0].R == 1 && cores[0].G == 0.5 && cores[0].B == 0.5)
                {
                    Instantiate(Rouparosa, new Vector3(-36, -11.5f, 0), Quaternion.identity);
                    GameObject.Find("Player").GetComponent<Movimentacao>().Textoguia.text = "Uma roupa rosa ? Acho que eu vi algo com uma roupa da mesma cor no por�o";
                   GameObject.Find("Sons_de_fundo").GetComponent<Fundo_sons>().Sons(0);
                }
                else
                {
                    Instantiate(roupas[0], new Vector3(-36, -11.5f, 0), Quaternion.identity);
                }
                Destroy(roupas[0]);
            }
            if (roupas[1] != null)
            {
                roupas[1].GetComponent<BoxCollider2D>().enabled = true;
                Instantiate(roupas[1], new Vector3(-38, -11.5f, 0), Quaternion.identity);
                Destroy(roupas[1]);
            }
            if (roupas[2] != null)
            {
                roupas[2].GetComponent<BoxCollider2D>().enabled = true;
                Instantiate(roupas[2], new Vector3(-42, -11.5f, 0), Quaternion.identity);
                Destroy(roupas[2]);
            }
            roupas = new GameObject[3];

        }
        
    }
    public void Limpar ()
    {
        for (int i = 0; i < roupassujas.Length; i++)
        {
            if (roupassujas[i] != null)
            {
                roupassujas[i].GetComponent<scr_roupas>().Voltaraorigem();
            }
           
           
        }
        if (roupassujas[0] != null)
        {
            roupassujas[0].GetComponent<BoxCollider2D>().enabled = true;
            Instantiate(roupassujas[0], new Vector3(-36, -11.5f, 0), Quaternion.identity);
            Destroy(roupassujas[0]);
        }
        if (roupassujas[1] != null)
        {
            roupassujas[1].GetComponent<BoxCollider2D>().enabled = true;
            Instantiate(roupassujas[1], new Vector3(-38, -11.5f, 0), Quaternion.identity);
            Destroy(roupassujas[1]);
        }
        if (roupassujas[2] != null)
        {
            roupassujas[2].GetComponent<BoxCollider2D>().enabled = true;
            Instantiate(roupassujas[2], new Vector3(-42, -11.5f, 0), Quaternion.identity);
            Destroy(roupassujas[2]);
        }
        roupassujas = new GameObject[3];

    }
   
    
       
    
    


}
