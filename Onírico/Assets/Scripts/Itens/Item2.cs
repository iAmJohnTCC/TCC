using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Item2 : MonoBehaviour,Interagiveis
{
    [SerializeField] Item Meu_Item;
    [SerializeField] SpriteRenderer Renderer;
    void Start()
    {
      
        Renderer.sprite = Meu_Item.Sprite_No_Cenario;
       
    }

    
    public void Interacao(Movimentacao Player)
    {
        if (Player.Espaco_Livre != 5)
        {
           GameObject.Find("Sons_de_fundo").GetComponent<Fundo_sons>().Sons(2);
            if (Meu_Item.Iten.GetComponent<scr_roupas>() != null)
            {
                Meu_Item.Iten.GetComponent<scr_roupas>().R = this.gameObject.GetComponent<scr_roupas>().R;
                Meu_Item.Iten.GetComponent<scr_roupas>().G = this.gameObject.GetComponent<scr_roupas>().G;
                Meu_Item.Iten.GetComponent<scr_roupas>().B = this.gameObject.GetComponent<scr_roupas>().B;
                Meu_Item.Iten.GetComponent<scr_roupas>().tipocor = this.gameObject.GetComponent<scr_roupas>().tipocor;
                Meu_Item.Iten.GetComponent<SpriteRenderer>().color = this.gameObject.GetComponent<SpriteRenderer>().color;


            }
            if(gameObject.name!="Roupa Rosa"||gameObject.name!= "Pilha feliz")
                    {
                Player.Textoguia.text = "Eu peguei " + Meu_Item.Item_nome + " (Aperte Tab para abrir o inventário, aperte o número que aparece em cima do item para seleciona-lo)";
            }
            Player.AdicionarItem(Meu_Item.Iten);
            Destroy(gameObject);
        }
       else
        {
            Player.Textoguia.text = "Não consigo carregar mais nada, tenho que descartar algo (Você pode descartar itens Apertando X)";
        }
        
    }



}
