using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Inventario_hud : MonoBehaviour
{
    [SerializeField] Movimentacao SCR_Player;
    [SerializeField] GameObject[] Inventario_Pra_HUD;
    [SerializeField] Image[] Imagens;
    [SerializeField] Image Itemselecionado;
    [SerializeField] Sprite Semitem;
    
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

                Imagens[i].color= Inventario_Pra_HUD[i].GetComponent<SpriteRenderer>().color;
                
            }
            else
            {
                Imagens[i].sprite = null;
                Imagens[i].color =new Color(1,1,1,0);
            }
        }
        Itemselecionado.transform.position = Imagens[SCR_Player.Numeroitem].transform.position;
        
      


    }
    public void Trocaritem(int Valor)
    {
        SCR_Player.Numeroitem = Valor;
    }
}
