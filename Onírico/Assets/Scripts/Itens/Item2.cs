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
        Player.AdicionarItem(Meu_Item.Iten);
        Destroy(this.gameObject);

    }



}
