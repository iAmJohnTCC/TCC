using System.Collections;
using System.Collections.Generic;
using System.IO.Enumeration;
using UnityEngine;

[CreateAssetMenuAttribute(menuName = "Novo Item", fileName = "Item")]
public class Item : ScriptableObject
{
    [SerializeField] public string Item_nome;
    [SerializeField] public Sprite Item_Sprite;
    [SerializeField] public GameObject Iten;
    [SerializeField] public float Item_ID;
    [SerializeField] public string Descricao_Item;
    [SerializeField] public Sprite Sprite_No_Cenario;

    void Start()
    {

    }
    //void Update()
    //{

    //}
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if( collision.gameObject == GameObject.Find("Player")&&Item_nome!="Acendedor_de_fogão"&& Item_nome != "Lanterna")
    //    {
    //        collision.gameObject.GetComponent<Movimentacao>().ItemAtual[0] = Item_nome;
    //        Destroy(gameObject);
    //    }
    //   else
    //    {
    //        if (Item_nome == "Lanterna")
    //        {
    //            collision.gameObject.GetComponent<Movimentacao>().lanterna = true;
    //            Destroy(gameObject);
    //        }
    //        else
    //        {
    //            collision.gameObject.GetComponent<Movimentacao>().ItemAtual[1] = Item_nome;
    //            Destroy(gameObject);
    //        }
    //    }
    //}
}
