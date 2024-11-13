using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Insetos : MonoBehaviour,Interagiveis
{
    [SerializeField] public GameObject[] Esconderijos = new GameObject [4];
    [SerializeField] Animator[] meusinsetos;
    [SerializeField] string[] Qualinseto;
    [SerializeField] string[] Localizacao;
    [SerializeField] GameObject vela;
    bool espantado = false;
    public float[] Horizontalmaxima, Horizontalminima, Verticalminima, Verticalmaxima;
    int B;
    Movimentacao Player;
    void Start()
    {
        gameObject.GetComponent<AudioSource>().enabled = true;
        for (int i = 0; i < meusinsetos.Length; i++) 
        {
            meusinsetos[i].gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }
        B = 0;
          Esconderijos[B].GetComponent<BoxCollider2D>().enabled = false;
                transform.position = Esconderijos[B].transform.position;
                for (int i = 0; i < meusinsetos.Length; i++)
                {
                    meusinsetos[i].Play(Qualinseto[Random.Range(0, Qualinseto.Length)]);
                    meusinsetos[i].GetComponent<Anim_Insetos>().Limites(Horizontalmaxima[B], Horizontalminima[B], Verticalminima[B],Verticalmaxima[B]);
                    meusinsetos[i].GetComponent<Anim_Insetos>().Novoobjetivo();
                    meusinsetos[i].transform.position = transform.position;
                }
        Player = GameObject.Find("Player").GetComponent<Movimentacao>();
        Invoke(nameof(Trocaresconderijo),Random.Range(10f,30f));
    }

    

    void Trocaresconderijo()
    {
        if (Localizacao[B] != Player.Localizacao||espantado)
        {
            Esconderijos[B].GetComponent<BoxCollider2D>().enabled=true;
            B = Random.Range(0, Esconderijos.Length);
            if (Localizacao[B] != Player.Localizacao)
            {
                Esconderijos[B].GetComponent<BoxCollider2D>().enabled = false;
                transform.position = Esconderijos[B].transform.position;
                for (int i = 0; i < meusinsetos.Length; i++)
                {
                    meusinsetos[i].Play(Qualinseto[Random.Range(0, Qualinseto.Length)]);
                    meusinsetos[i].GetComponent<Anim_Insetos>().Limites(Horizontalmaxima[B], Horizontalminima[B], Verticalminima[B],Verticalmaxima[B]);
                    meusinsetos[i].GetComponent<Anim_Insetos>().Novoobjetivo();
                    meusinsetos[i].transform.position = transform.position;
                }
                if(espantado)
                {
                    espantado = false;
                    Player.Standby = false;
                    
                }
                Invoke(nameof(Trocaresconderijo), Random.Range(10f, 30f));
            }
            else
            {
                Invoke(nameof(Trocaresconderijo), Random.Range(3f, 8f));
            }
        }
        else
        {
            Invoke(nameof(Trocaresconderijo), Random.Range(3f, 8f));
        }
    }
    public void Interacao (Movimentacao player)
    {
        if (player.Inventario[player.Numeroitem].name == "Vela Acesa")
        {
            espantado = true;
            Player.Inventario[Player.Numeroitem] = vela;
            CancelInvoke(nameof(Trocaresconderijo));
            Invoke(nameof(Trocaresconderijo), 1.1f);
            GameObject.Find("GameController").GetComponent<GameController>().Fadeout(1f,false);
        }
        else
        {
            player.Textoguia.text = "Credo, eu não vou me esconder aqui.";
        }
    }
}
