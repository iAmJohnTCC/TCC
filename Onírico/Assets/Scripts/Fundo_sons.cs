using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fundo_sons : MonoBehaviour
{
    [SerializeField] AudioClip[] sons;
    [SerializeField] AudioClip[] sonsesporadicos;
    [SerializeField] AudioSource Playersom;
    private void Start()
    {
        Invoke(nameof(Sonsesporadicos), Random.Range(60, 181));
    }
    public void Sons(int i)
    {
        Playersom.clip=sons[i];
        Playersom.Play();
    }
    public void Sonsesporadicos()
    {
        int i=Random.Range(0,sonsesporadicos.Length);

        Playersom.clip = sonsesporadicos[i];
        Playersom.Play();
        Invoke(nameof(Sonsesporadicos), Random.Range(60, 181));
    }
}
