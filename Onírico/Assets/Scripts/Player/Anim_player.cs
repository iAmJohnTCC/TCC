using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anim_player : MonoBehaviour
{
    Animator anim;
    Movimentacao player;
    bool naorepetir=false;
    string mudouotexto="";
    // Start is called before the first frame update
    void Start()
    {
     anim=GetComponent<Animator>();
        player=GetComponent<Movimentacao>();
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetAxisRaw("Horizontal") != 0 && !player.Standby&&player.Velocidade>0)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                anim.speed = 1.5f;

            }
            else
            {
                anim.speed = 1f;
            }
            if (gameObject.GetComponent<Lanterna>().enabled == true)
            {
                anim.Play("Andando_comlanterna");

            }
            else
            {
                anim.Play("Andando_semlanterna");
            }
        }
        else
        {
            if (player.porta != null && (player.porta.gameObject.CompareTag("Porta_naolaterais")|| player.porta.gameObject.CompareTag("Escada")))
            {
                anim.Play("Player_costas");
            }
            else
            {
                if (player.Morte)
                {
                    anim.Play("Player_Morte");
                }
                else
                {
                    anim.speed = 1f;
                    if (gameObject.GetComponent<Lanterna>().enabled == true)
                    {
                        anim.Play("idle_comLanterna");

                    }
                    else
                    {
                        anim.Play("idle_semLanterna");
                    }

                }
            }
            if (player.Textoguia.text != mudouotexto)
            {
                CancelInvoke(nameof(PodeRepetir));
                player.Textoguia.GetComponent<Animator>().Play("Guia_textoanim", -1, 0);
                mudouotexto = player.Textoguia.text;
                naorepetir = true;
                Invoke(nameof(PodeRepetir), 6.1f);
            }
        }
        
    }
    void PodeRepetir()
    {
        player.Textoguia.text = "";
        mudouotexto = "";
    }
}
