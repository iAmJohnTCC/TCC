using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_sons : MonoBehaviour
{
    [SerializeField]AudioClip[] sons_player;
    AudioSource Fonte_som;
    [SerializeField]Movimentacao player;
    // Start is called before the first frame update
    private void Start()
    {
        Fonte_som = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(player.Morte)
        {
            if(Fonte_som.clip != sons_player[3])
            {
           Fonte_som.clip= sons_player[3];
                Fonte_som.loop = false;
                Fonte_som.Play();
            }
         }
        else
         {
        if(player.escondido )
            {
           if(Fonte_som.clip != sons_player[2])
            {
             Fonte_som.clip= sons_player[2];
                Fonte_som.loop = true;
                Fonte_som.Play();
             }
           }
           else
            {
            if(Input.GetAxisRaw("Horizontal")!=0&&Input.GetKey(KeyCode.LeftShift) && Fonte_som.clip != sons_player[1]&&!player.Standby)
            {
                Fonte_som.clip= sons_player[1];
                Fonte_som.loop = true;
                Fonte_som.Play();
            }
            else
            {
                if (Input.GetAxisRaw("Horizontal") != 0 && Fonte_som.clip != sons_player[0]&&!Input.GetKey(KeyCode.LeftShift) && !player.Standby)
                {
                    
                    Fonte_som.clip = sons_player[0];
                    Fonte_som.loop = true;
                    Fonte_som.Play();
                }
                else
            {
                if(Input.GetAxisRaw("Horizontal") == 0 || player.Standby)
                {
                    Fonte_som.clip = null;
                }
            }
               
            }
         }
       }
        
    }
}
