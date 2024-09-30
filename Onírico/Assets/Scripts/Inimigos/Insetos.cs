using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Insetos : MonoBehaviour,Interagiveis
{
    public bool TemInsetos;
    [SerializeField] public GameObject[] Esconderijos = new GameObject [4];
    [SerializeField] Animator[] meusinsetos;
    [SerializeField] string[] Qualinseto;
    void Start()
    {
        Invoke(nameof(Trocaresconderijo),Random.Range(30f,80f));
    }

    

    void Trocaresconderijo()
    {
        int A= Random.Range(0,Qualinseto.Length);
        transform.position=Esconderijos[Random.Range(0,Esconderijos.Length)].transform.position;
        for(int i = 0; i<meusinsetos.Length;i++)
        {
            meusinsetos[i].Play(Qualinseto[A]);
        }
        Invoke(nameof(Trocaresconderijo),Random.Range(30f, 80f));
    }
    public void Interacao (Movimentacao player)
    {
        player.Textoguia.text = "Eu não vou me esconder aqui";
    }
}
