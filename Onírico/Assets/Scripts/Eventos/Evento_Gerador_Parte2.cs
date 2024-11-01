using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Evento_Gerador_Parte2 : MonoBehaviour
{
    [SerializeField] TMP_Text calcs;
    [SerializeField] float Soma;
    string nivelenergia;
    [SerializeField] Puzzle_Gerador [] Todos = new Puzzle_Gerador [4];
    public bool PodeLigar;

    void Start()
    {
        
    }


    void Update()
    {
        Soma = Todos[0].qtd + Todos[1].qtd + Todos[2].qtd + Todos[3].qtd;
        if(Soma>100)
        {
           calcs.color=new Color(1,0,0);
           nivelenergia=" Sobrecarregado";
        }
 if(Soma<100)
        {
           calcs.color=new Color(0,0,1);
           nivelenergia="energia baixa";
        }
if(Soma==100)
        {
           calcs.color=new Color(0,1,0);
           nivelenergia="nível de energia aceitavel";
        }
        calcs.text = Soma.ToString("00.00") + "% "+ nivelenergia;

        if (Soma == 100)
        {
            PodeLigar = true;
        }
    }
}
