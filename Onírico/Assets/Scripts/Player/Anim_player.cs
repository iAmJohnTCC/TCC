using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anim_player : MonoBehaviour
{
    Animator anim;
    Movimentacao player;
    // Start is called before the first frame update
    void Start()
    {
     anim=GetComponent<Animator>();
        player=GetComponent<Movimentacao>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!player.Standby)
        {
            if (Input.GetAxisRaw("Horizontal") != 0)
            {
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
                if (gameObject.GetComponent<Lanterna>().enabled == true)
                {
                    anim.Play("idle_comLanterna");

                }
                else
                {
                    anim.Play("idle_semLanterna");
                }

            }
            if (player.Standby)
            {
                anim.speed = 0;
            }
            else
            {
                anim.speed = 1;
            }
        }
    }
}
