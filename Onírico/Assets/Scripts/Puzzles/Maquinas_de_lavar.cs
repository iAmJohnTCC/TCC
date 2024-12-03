using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maquinas_de_lavar : MonoBehaviour,Interagiveis
{
    [SerializeField]GameObject ativador;
    public GameObject[] Roupas_adquiridas=new GameObject[3]; 
    Movimentacao player;
    public int i = 0;
    [SerializeField] GameObject Minhaluz,luzbotao;
    private void Start()
    {
        player=GameObject.Find("Player").GetComponent<Movimentacao>();
    }
    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Puzzle_lav").GetComponent<Puzzle_lav>().puzzleresolvido)
            {
            Minhaluz.SetActive(false);
           
            }
        
    }
    public void Interacao(Movimentacao player)
    {
        if (player.Inventario[player.Numeroitem] != null && player.Inventario[player.Numeroitem].GetComponent<scr_roupas>() != null && !GameObject.Find("Puzzle_lav").GetComponent<Puzzle_lav>().puzzleresolvido)
        {
            Roupas_adquiridas[i] = Instantiate(GameObject.Find("Player").GetComponent<Movimentacao>().Inventario[player.Numeroitem], transform.position, Quaternion.identity);
            player.Inventario[player.Numeroitem] = null;
            Roupas_adquiridas[i].GetComponent<BoxCollider2D>().enabled = false;
            i++;
        }
        else
        {

            if (Roupas_adquiridas[0] == null)
            {
                player.Textoguia.text = "Eu posso colocar as roupas aqui se eu interagir enquanto seguro elas, se já houver uma roupa é só eu interagir novamente para combinar ou limpar ";
            }
            if ( Roupas_adquiridas[0] != null && !GameObject.Find("Puzzle_lav").GetComponent<Puzzle_lav>().puzzleresolvido)
            {
               
                if (gameObject.name == "Mqndelavar_limpar")
                {
                    GameObject.Find("Sons_de_fundo").GetComponent<Fundo_sons>().Sons(12);
                    GameObject.Find("Puzzle_lav").GetComponent<Puzzle_lav>().roupassujas = Roupas_adquiridas;
                    GameObject.Find("Puzzle_lav").GetComponent<Puzzle_lav>().Limpar();
                    Roupas_adquiridas = null;
                    i = 0;
                    Roupas_adquiridas = new GameObject[3];
                }
                else
                {
                    GameObject.Find("Sons_de_fundo").GetComponent<Fundo_sons>().Sons(13);
                    GameObject.Find("Puzzle_lav").GetComponent<Puzzle_lav>().roupas = Roupas_adquiridas;
                    GameObject.Find("Puzzle_lav").GetComponent<Puzzle_lav>().Combinar();
                    Roupas_adquiridas = null;
                    i = 0;
                    Roupas_adquiridas = new GameObject[3];
                }

            }
            else
            {
                if (GameObject.Find("Puzzle_lav").GetComponent<Puzzle_lav>().puzzleresolvido)
                {
                    player.Textoguia.text = "Agora que eu tenho a roupa rosa não preciso mais usar isso";
                }
            }
            

           
            
        }
    }
    
}
