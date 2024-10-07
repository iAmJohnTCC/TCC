using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maquinas_de_lavar : MonoBehaviour,Interagiveis
{
    [SerializeField]GameObject ativador;
    public GameObject[] Roupas_adquiridas=new GameObject[3]; 
    Movimentacao player;
    public int i = 0;

    private void Start()
    {
        player=GameObject.Find("Player").GetComponent<Movimentacao>();
    }
    // Update is called once per frame
    void Update()
    {
        if (player.Hit.transform != null && Input.GetKeyDown(KeyCode.E))
        {



            if (player.Hit.transform.gameObject == ativador && Roupas_adquiridas[0]!=null )
                {
                   
                    if (gameObject.name=="Mqndelavar_limpar")
                    {
                        GameObject.Find("Puzzle_lav").GetComponent<Puzzle_lav>().roupassujas = Roupas_adquiridas;
                        GameObject.Find("Puzzle_lav").GetComponent<Puzzle_lav>().Limpar();
                        Roupas_adquiridas = null;
                        i = 0;
                    Roupas_adquiridas = new GameObject[3];
                }
                    else
                    {
                        GameObject.Find("Puzzle_lav").GetComponent<Puzzle_lav>().roupas = Roupas_adquiridas;
                        GameObject.Find("Puzzle_lav").GetComponent<Puzzle_lav>().Combinar();
                        Roupas_adquiridas = null;
                        i = 0;
                    Roupas_adquiridas = new GameObject[3];
                    }
                    
                }
            
        }
    }
    public void Interacao(Movimentacao player)
    {
        if (player.Inventario[0] != null && player.Inventario[0].GetComponent<scr_roupas>() != null)
        {
            Roupas_adquiridas[i] = Instantiate(GameObject.Find("Player").GetComponent<Movimentacao>().Inventario[0], transform.position, Quaternion.identity);
            player.Inventario[0] = null;
            Roupas_adquiridas[i].GetComponent<BoxCollider2D>().enabled = false;
            i++;
        }
        else
        {

            player.Textoguia.text = "Eu posso colocar as roupas na máquina de lavar se eu interagir enquanto uma delas é meu item atual, depois para lavar é só apertar o botão cinza";
            
        }
    }
    
}
