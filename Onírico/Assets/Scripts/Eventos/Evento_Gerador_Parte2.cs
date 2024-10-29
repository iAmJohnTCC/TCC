using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Evento_Gerador_Parte2 : MonoBehaviour
{
    [SerializeField] TMP_Text calcs;
    [SerializeField] float Soma;
    [SerializeField] Puzzle_Gerador [] Todos = new Puzzle_Gerador [4];
    public bool PodeLigar;

    void Start()
    {
        
    }


    void Update()
    {
        Soma = Todos[0].qtd + Todos[1].qtd + Todos[2].qtd + Todos[3].qtd;
        calcs.text = Soma.ToString("00.00") + "%";

        if (Soma == 100)
        {
            PodeLigar = true;
        }
    }
}
