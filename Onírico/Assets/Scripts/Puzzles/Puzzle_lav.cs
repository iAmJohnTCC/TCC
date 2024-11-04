using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle_lav : MonoBehaviour
{
    public GameObject[] roupas=new GameObject[3];
    [SerializeField]GameObject Rouparosa;
    public bool puzzleresolvido;
    [SerializeField]Vector2[] posicoes=new Vector2[3]; 
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
                if (cores[0].tipocor == "Primária" && cores[1].tipocor == "Primária" && cores[2].tipocor == "Primária")
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
                    if (cores[0].tipocor == "Primária" && cores[1].tipocor=="Primária")
                    {
                        cores[0].R += cores[1].R; cores[0].G += cores[1].G; cores[0].B += cores[1].B;

                        cores[0].tipocor = "Secundária";
                    }
                    else
                    {
                        if (cores[0].tipocor == "Secundária" && cores[1].tipocor=="Secundária")
                        {
                            cores[0].R += cores[1].R-1; cores[0].G += cores[1].G-1; cores[0].B += cores[1].B-1;
                            cores[0].tipocor = "Primária";
                        }
                        else
                        {
                            if (cores[0].tipocor == "Primária" && cores[1].tipocor == "Secundária" ||
                                cores[0].tipocor == "Secundária" && cores[1].tipocor == "Primária")
                            {
                                cores[0].R -= cores[1].B; cores[0].G += cores[1].R; cores[0].B -= cores[1].G;
                                cores[0].tipocor = "Primária";
                            }
                            else
                            {

                                if (cores[1].tipocor == "Branco")
                                {
                                    cores[0].R += 0.5f; cores[0].G += 0.5f; cores[0].B += 0.5f;
                                    cores[0].tipocor = "Secundária";
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
                                        GameObject.Find("Player").GetComponent<Movimentacao>().Textoguia.text = "Acho que não era para a roupa ficar preta, é melhor eu fazer a roupa voltar a cor original";
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
                   
                    puzzleresolvido = true;
                    GameObject.Find("Player").GetComponent<Movimentacao>().Textoguia.text = "Roupa rosa? Onde eu vi isso antes?";
                   GameObject.Find("Sons_de_fundo").GetComponent<Fundo_sons>().Sons(0);
                    Instantiate(Rouparosa, new Vector3(-36, -17f, 0), Quaternion.identity);
                    Destroy(roupas[0]);
                    roupas[0] = null;
                }
              
                
            }
            if (roupas[1] != null)
            {
                roupas[1].GetComponent<BoxCollider2D>().enabled = true;
               
                
            }
            if (roupas[2] != null)
            {
                roupas[2].GetComponent<BoxCollider2D>().enabled = true;
               
                
            }
            GameObject[]Roupasposicoes=GameObject.FindGameObjectsWithTag("Roupas"); 
            bool[] Estaposicaoeminha=new bool[3];
            Estaposicaoeminha[0] = false;
            Estaposicaoeminha[1] = false;
            Estaposicaoeminha[2] = false;
            for(int i = 0; i < roupas.Length;i++)
            {
               
                if(roupas[i]!=null)
                {
                   
                for (int h = 0; h < posicoes.Length;h++)
                {
                    bool Mesmaposicao = false;
                        if (!Estaposicaoeminha[h])
                        {


                            for (int j = 0; j < Roupasposicoes.Length; j++)
                            {

                                if (posicoes[h] == (Vector2)Roupasposicoes[j].transform.position)
                                {
                                    Mesmaposicao = true;
                                    break;
                                }

                            }
                            if (!Mesmaposicao)
                            {
                                Instantiate(roupas[i], posicoes[h], Quaternion.identity);
                                Estaposicaoeminha[h] = true;
                                break;
                            }
                        }
                }
                }
                
            }
            Destroy(roupas[0]);
            Destroy(roupas[1]);
            Destroy(roupas[2]);
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
            
           
        }
        if (roupassujas[1] != null)
        {
            roupassujas[1].GetComponent<BoxCollider2D>().enabled = true;
            
           
        }
        if (roupassujas[2] != null)
        {
            roupassujas[2].GetComponent<BoxCollider2D>().enabled = true;
           
           
        }
       
        GameObject[]Roupasposicoes=GameObject.FindGameObjectsWithTag("Roupas");
        bool[] Estaposicaoeminha = new bool[3];
        Estaposicaoeminha[0] = false;
        Estaposicaoeminha[1] = false;
        Estaposicaoeminha[2] = false;
        for (int i = 0; i < roupassujas.Length; i++)
        {

            if (roupassujas[i] != null)
            {

                for (int h = 0; h < posicoes.Length; h++)
                {
                    bool Mesmaposicao = false;
                    if (!Estaposicaoeminha[h])
                    {


                        for (int j = 0; j < Roupasposicoes.Length; j++)
                        {

                            if (posicoes[h] == (Vector2)Roupasposicoes[j].transform.position)
                            {
                                Mesmaposicao = true;
                                break;
                            }

                        }
                        if (!Mesmaposicao)
                        {
                            Instantiate(roupassujas[i], posicoes[h], Quaternion.identity);
                            Estaposicaoeminha[h] = true;
                            break;
                        }
                    }
                }
            }

        }
        Destroy(roupassujas[0]);
        Destroy(roupassujas[1]);
        Destroy(roupassujas[2]);
        roupassujas = new GameObject[3];

    }
   
    
       
    
    


}
