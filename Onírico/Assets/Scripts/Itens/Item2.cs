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

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == GameObject.Find("Player") )
        {
            collision.gameObject.GetComponent<Movimentacao>().AdicionarItem(Meu_Item.Iten);
            Destroy(this.gameObject);
        }
    }



}
