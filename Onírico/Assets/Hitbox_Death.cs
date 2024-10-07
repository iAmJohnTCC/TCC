using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox_Death : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<Movimentacao>()!=null)
        {
            collision.gameObject.GetComponent<Movimentacao>().Morte = true;
        }
    }
}
