using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destaque_interagiveis : MonoBehaviour
{
    Animator anim;
    [SerializeField] float altura=-1.5f;
    [SerializeField] LayerMask player;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D ray= Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y +altura), new Vector2(-GameObject.Find("Player").transform.localScale.x, 0f), 1.5f,player);
       
        if(ray.transform!=null)
        {
            anim.Play("Handholding_Destaque");
            if(GameObject.Find("Sinal_interagir").GetComponent<Sinal_interagir>().Objeto_me_utilizando==null)
            {
                GameObject.Find("Sinal_interagir").GetComponent<Sinal_interagir>().Objeto_me_utilizando =this.gameObject;
                GameObject.Find("Sinal_interagir").transform.position = new Vector2(transform.position.x, transform.position.y -1.5f);
            }
        }
        else
        {
            if (GameObject.Find("Sinal_interagir").GetComponent<Sinal_interagir>().Objeto_me_utilizando == this.gameObject)
            {
                GameObject.Find("Sinal_interagir").GetComponent<Sinal_interagir>().Objeto_me_utilizando = null;
            }
                anim.Play("Handholding_Desdestacar");
        }
    }
    private void OnDisable()
    {
        if (GameObject.Find("Sinal_interagir").GetComponent<Sinal_interagir>().Objeto_me_utilizando == this.gameObject)
        {
            GameObject.Find("Sinal_interagir").GetComponent<Sinal_interagir>().Objeto_me_utilizando = null;
        }
    }
}
