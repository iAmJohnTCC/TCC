using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class Notas : MonoBehaviour,Interagiveis
{
    [SerializeField] public string [] Paginas;
    [SerializeField] public Sprite imagem;

  public void Interacao(Movimentacao player)
    {
        GameObject.Find("Display_notas").GetComponent<Display_notas>().Pegarnota(this);
        GameObject.Find("Sons_de_fundo").GetComponent<Fundo_sons>().Sons(3);
    }
}
