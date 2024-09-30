using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_posicoes : MonoBehaviour
{
    
    [SerializeField] GameObject[] Posicoes;
    [SerializeField] string[] Nome_salas;
    public string Salaatual;
   
  

    // Update is called once per frame
    
    public void Trocarcamera(string localizacao)
    {
        Salaatual = localizacao;
        for (int i = 0; i < Nome_salas.Length; i++)
        {
            if (Salaatual == Nome_salas[i])
            {
                Posicoes[i].SetActive(true);
                
            }
            else
            {
                Posicoes[i].SetActive(false);
            }
        }
    }
}
