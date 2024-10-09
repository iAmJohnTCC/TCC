using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Palhaco_anim : MonoBehaviour
{
    Palhaco movimento;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        movimento = GetComponent<Palhaco>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (movimento.Stunned)
        {
            animator.Play("Palhaco_atordoado");
        }
        else
        {
            if (movimento.parar || movimento.Normalspeed == 0)
            {
                animator.Play("Palhaco_idle");
            }
            else
            {
                animator.Play("Palhaco_andando");
            }
        }
    }
}
