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
    [SerializeField]string Motivopranaoentrar;
    Movimentacao Player;
    public void Interacao(Movimentacao player)
    {
        Player = player;
        player.porta = this;

        if (player.porta.Aberto)
        {
            GameObject.Find("GameController").GetComponent<GameController>().Fadeout(1.4f);
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
            if (player.Item_Atual!=null&&player.porta.Iten_desbloqueio == player.Item_Atual.name)
            {
                if (player.porta.Bloqueio != null)
                {
                    Destroy(player.porta.Bloqueio.gameObject);
                    
                }
                player.porta.Aberto = true;
                player.Textoguia.text = "Agora posso entrar aqui";
                Destroy(player.Inventario[0]);
            }
            else
            {
                player.Textoguia.text = Motivopranaoentrar;
            }
        }
    }
    public void Teleporteplayer()
    {
        Player.Teleporte();
    }
}













































































//RiskOfRainÉumJogaçoRecomendo