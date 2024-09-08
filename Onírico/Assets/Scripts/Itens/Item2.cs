using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Item2 : MonoBehaviour
{
    [SerializeField] Item Meu_Item;
    [SerializeField] SpriteRenderer Renderer;
    void Start()
    {
      
        Renderer.sprite = Meu_Item.Sprite_No_Cenario;
       
    }

    
    public void Adicionarinventario(Movimentacao Player)
    {
       
        if(Meu_Item.Iten.GetComponent<scr_roupas>()!=null)
        {
            Meu_Item.Iten.GetComponent<scr_roupas>().R=this.gameObject.GetComponent<scr_roupas>().R;
            Meu_Item.Iten.GetComponent<scr_roupas>().G = this.gameObject.GetComponent<scr_roupas>().G;
            Meu_Item.Iten.GetComponent<scr_roupas>().B = this.gameObject.GetComponent<scr_roupas>().B;
            Meu_Item.Iten.GetComponent<scr_roupas>().tipocor = this.gameObject.GetComponent<scr_roupas>().tipocor;
        }
        Player.AdicionarItem(Meu_Item.Iten);
        Destroy(gameObject);
        
    }



}
