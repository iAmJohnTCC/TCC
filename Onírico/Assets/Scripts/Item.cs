using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public string Item_nome;
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if( collision.gameObject == GameObject.Find("Player")&&Item_nome!="Acendedor_de_fogão"&& Item_nome != "Lanterna")
        {
            collision.gameObject.GetComponent<Movimentacao>().ItemAtual[0] = Item_nome;
            Destroy(gameObject);
        }
       else
        {
            if (Item_nome == "Lanterna")
            {
                collision.gameObject.GetComponent<Movimentacao>().lanterna = true;
                Destroy(gameObject);
            }
            else
            {
                collision.gameObject.GetComponent<Movimentacao>().ItemAtual[1] = Item_nome;
                Destroy(gameObject);
            }
        }
    }
}
