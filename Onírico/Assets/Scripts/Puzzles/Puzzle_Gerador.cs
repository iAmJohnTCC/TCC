using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Puzzle_Gerador : MonoBehaviour, Interagiveis 
{
    [SerializeField] GameObject Anterior;
    [SerializeField] GameObject Fuzivel;
    [SerializeField] float Operacao;   
    [SerializeField] public float qtd;
   [SerializeField] bool JaTenho = true;
    public void Interacao(Movimentacao player)
    {
        if (player.Item_Atual!=null&&player.Item_Atual.CompareTag("F") && Fuzivel == null)
        {

            Fuzivel = Instantiate(player.Item_Atual, transform.position, Quaternion.identity);
            Fuzivel.GetComponent<BoxCollider2D>().enabled = false;
            player.Inventario[player.Numeroitem] = null;
            operacao();
            JaTenho = true;
        }
        else
        {
            if ( player.Espaco_Livre!=5 && Fuzivel != null)
            {
                player.AdicionarItem(Fuzivel.GetComponent<Item2>().Meu_Item.Iten);
                qtd = 0;
                JaTenho = false;
               Destroy(Fuzivel);
                Fuzivel = null;
                
            }
            else
            {
             if ( player.Espaco_Livre==5)
               {
                  player.Textoguia.text = "É muito pesado, preciso soltar algo.";
               }
           }
        }
    }
    void Start()
    {
        Fuzivel = Instantiate(Fuzivel, transform.position, Quaternion.identity);
        Fuzivel.GetComponent<BoxCollider2D>().enabled = false;
        qtd = Operacao * Fuzivel.GetComponent<Item2>().Meu_Item.Valor;
    }
    void Update()
    {
        if(!JaTenho)
        {
            qtd = 0;
        }
    }

    public void operacao()
    {   
       qtd = Operacao * Fuzivel.GetComponent<Item2>().Meu_Item.Valor;
       
    }
}
