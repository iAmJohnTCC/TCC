using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destaque_interagiveis : MonoBehaviour
{
    Animator anim;
    [SerializeField] float rangeL=1.5f;
    [SerializeField] float rangeR = 1.5f;
    [SerializeField] LayerMask player;

    private void Start()
    {
        anim = GetComponent<Animator>();
        if(rangeL==-1.5f)
        {
            rangeL = 1.5f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float range;
        if(GameObject.Find("Player").transform.localScale.x==1)
        {
            range= rangeL;
        }
        else
        {
            range= rangeR;
        }
        RaycastHit2D ray= Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y +1f), new Vector2(-GameObject.Find("Player").transform.localScale.x, 0f), range,player);
        RaycastHit2D ray2= Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), new Vector2(-GameObject.Find("Player").transform.localScale.x, 0f), range,player);
        RaycastHit2D ray3= Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y -3f), new Vector2(-GameObject.Find("Player").transform.localScale.x, 0f), range,player);
        if(ray.transform!=null||ray2.transform!=null||ray3.transform!=null)
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
        if (GameObject.Find("Sinal_interagir").GetComponent<Sinal_interagir>().Objeto_me_utilizando!=null&&GameObject.Find("Sinal_interagir").GetComponent<Sinal_interagir>().Objeto_me_utilizando == this.gameObject)
        {
            GameObject.Find("Sinal_interagir").GetComponent<Sinal_interagir>().Objeto_me_utilizando = null;
        }
    }
    
}
