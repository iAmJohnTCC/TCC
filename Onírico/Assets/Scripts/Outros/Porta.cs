using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Porta : MonoBehaviour,Interagiveis
{
    [SerializeField] public GameObject posicao;
    [SerializeField] public GameObject Bloqueio;
    public bool Aberto;
    public string Iten_desbloqueio;
    public string Localizacao;
    public string Andaratual;
    [SerializeField] GameObject trancado;
    [SerializeField]string Motivopranaoentrar;
    Movimentacao Player;
    public void Interacao(Movimentacao player)
    {
        Player = player;
        player.porta = this;

        if (player.porta.Aberto)
        {
            GameObject.Find("GameController").GetComponent<GameController>().Fadeout(1.4f,true);
            if (player.porta.gameObject.CompareTag("Escada"))
            {
                GameObject.Find("Sons_de_fundo").GetComponent<Fundo_sons>().Sons(4);
            }
            else
            {
                GameObject.Find("Sons_de_fundo").GetComponent<Fundo_sons>().Sons(1);
            }
            Invoke(nameof(Teleporteplayer),1.5f);
        }
        else
        {
            if (player.Item_Atual != null && player.porta.Iten_desbloqueio == player.Item_Atual.name)
            {
                if (player.porta.Bloqueio != null)
                {
                    GameObject.Find("GameController").GetComponent<GameController>().Fadeout(1f, false);
                    Invoke(nameof(desbloquear), 1.01f);
                    
                }
                player.porta.Aberto = true;
                trancado.SetActive(false);
                if (this.gameObject.name != "Escada_bloqueada")
                {
                   
                    player.Inventario[player.Numeroitem] = null;
                    GameObject.Find("Sons_de_fundo").GetComponent<Fundo_sons>().Sons(9);
                }
                else
                {
                    GameObject.Find("CM_Mapa").GetComponent<Mapa>().objetivo.text = "-Explorar o porão";
                    GameObject.Find("CM_Mapa").GetComponent<Mapa>().objetivo2.text = "";
                }
                
                player.porta = null;
            }
            else
            {
                if (this.gameObject.name == "Escada_bloqueada")
                {
                    GameObject.Find("CM_Mapa").GetComponent<Mapa>().objetivo2.text = "-Ganhar acesso ao porão.";
                }
               
                    player.Textoguia.text = Motivopranaoentrar;
                
                trancado.SetActive(true);
                player.porta = null;
            }
        }
    }
    void desbloquear()
    {
        Destroy(Bloqueio.gameObject);
        GameObject.Find("Player").GetComponent<Movimentacao>().Standby = false;
    }
    public void Teleporteplayer()
    {
        Player.Teleporte();
    }
}













































































//RiskOfRainÉumJogaçoRecomendo