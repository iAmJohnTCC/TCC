using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_posicoes : MonoBehaviour
{
    
    [SerializeField] Vector2[] Posicoes;
    [SerializeField] string[] Nome_salas;
    Movimentacao player;
    public string Salaatual;
   
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Movimentacao>();

    }

    // Update is called once per frame
    void Update()
    {
        
        Salaatual = player.Localizacao.text;
        if (Salaatual != "Corredor" && Salaatual != "Sala" && Salaatual != "Sala do gerador" && Salaatual != "Cozinha")
        {
            Trocarcamera();
        }
        else
        {
            if (Salaatual == "Corredor" || Salaatual == "Sala" || Salaatual == "Sala do gerador" || Salaatual == "Cozinha")
            {
                transform.position = new Vector2(player.gameObject.transform.position.x, player.gameObject.transform.position.y + 2.48f);
            }
        }
    }
    void Trocarcamera()
    {
        for (int i = 0; i < Nome_salas.Length; i++)
        {
            if (Salaatual == Nome_salas[i])
            {
                transform.position = Posicoes[i];
                break;
            }
        }
    }
}
