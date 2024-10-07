using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anim_Insetos : MonoBehaviour
{
    public Vector2 Objetivo;
    public float Horizontalmaxima, Horizontalminima,Verticalminima,Verticalmaxima;
    // Start is called before the first frame update
    void Start()
    {
        Novoobjetivo();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, Objetivo, 0.01f);
        if ((Vector2)transform.position==Objetivo&& gameObject.GetComponent<Animator>().speed != 0)
        {
            gameObject.GetComponent<Animator>().speed = 0;
            Invoke(nameof(Novoobjetivo), Random.Range(2, 7));
        }
    }
    public void Novoobjetivo()
    {
        gameObject.GetComponent<Animator>().speed = 1;
        Objetivo = new Vector2(transform.parent.position.x+Random.Range(Horizontalminima, Horizontalmaxima),
            transform.parent.position.y+Random.Range(Verticalminima, Verticalmaxima));
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, (Mathf.Atan2(Objetivo.y - transform.position.y, Objetivo.x - transform.position.x) * Mathf.Rad2Deg) - 105));


    }

    public void Limites( float horizontalmaxima,float horizontalminima,float verticalminima, float verticalmaxima)
    {
        Horizontalmaxima=horizontalmaxima;
        Horizontalminima=horizontalminima;
        Verticalminima=verticalminima;
        Verticalmaxima=verticalmaxima;
    }
}
