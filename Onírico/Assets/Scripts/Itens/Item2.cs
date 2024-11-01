using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Item2 : MonoBehaviour,Interagiveis
{
    [SerializeField] public Item Meu_Item;
    [SerializeField] SpriteRenderer Renderer;
    [SerializeField] public float Item_Positiondrop;
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
            if(Meu_Item.name=="Pilhas")
            {
                Player.Textoguia.text = "Pilhas... elas serão úteis.";
            }
            if (Meu_Item.name == "Vela Apagada")
            {
                Player.Textoguia.text = "Olha, achei a vela!";
            }
            if (Meu_Item.name == "Acendedor")
            {
                Player.Textoguia.text = "Achei o acendedor do fogão!";
            }
            if (Meu_Item.name == "Chave Lavanderia")
            {
                Player.Textoguia.text = "A chave da lavanderia!";
            }
            if (Meu_Item.name == "Roupa Rosa")
            {
                Player.Textoguia.text = "Consegui a roupa rosa! Eu lembro de ter visto ela antes.";
            }
            if (Meu_Item.name == "Roupa(Amarelo)")
            {
                Player.Textoguia.text = "Essa é a roupa amarela.";
            }
            if (Meu_Item.name == "Roupa(Azul)")
            {
                Player.Textoguia.text = "Essa é a roupa azul.";
            }
            if (Meu_Item.name == "Roupa(Violeta)")
            {
                Player.Textoguia.text = "Essa é a roupa violeta.";
            }
            if (Meu_Item.name == "Chave Mae")
            {
                Player.Textoguia.text = "Peguei a chave!";
            }

            Player.AdicionarItem(Meu_Item.Iten);
            Destroy(gameObject);
        }
       else
        {
            Player.Textoguia.text = "É muito pesado, preciso soltar algo.";
        }
        
    }



}
