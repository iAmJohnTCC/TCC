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
    [SerializeField] public float Valor;
   
}
