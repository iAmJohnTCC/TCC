using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD_INVENTARIO : MonoBehaviour
{
    [SerializeField] Movimentacao SCR_Player;
    [SerializeField] GameObject[] Inventario_Pra_HUD;
    [SerializeField] Image[] Imagens;
 
    void Start()
    {
        SCR_Player = GameObject.Find("Player").GetComponent<Movimentacao>();
    }

    void Update()
    {
        Inventario_Pra_HUD = SCR_Player.Inventario;

        for (int i = 0; i < Inventario_Pra_HUD.Length; i++)
        {
            if (SCR_Player.Inventario[i] != null)
            {
             Imagens[i].sprite = Inventario_Pra_HUD[i].GetComponent<SpriteRenderer>().sprite;
            }
        }
        
        //for (int i = 0; i < Imagens.Length; i++)
        //{
        //    Imagens[i].sprite = 
        //}

    }
}
