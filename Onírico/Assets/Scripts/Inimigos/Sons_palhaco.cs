using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sons_palhaco : MonoBehaviour
{
    [SerializeField] AudioClip[] musicapalhaco;
    [SerializeField] AudioClip[] sonspalhaco;
    [SerializeField] AudioSource Fonte_musica;
    [SerializeField] AudioSource Fonte_sons;
    Palhaco palhaco;
    // Start is called before the first frame update
    void Start()
    {
        Fonte_musica=GetComponent<AudioSource>();
        palhaco=GetComponent<Palhaco>();
    }

    // Update is called once per frame
    void Update()
    {
        if (palhaco.Localizacao == GameObject.Find("Player").GetComponent<Movimentacao>().AndarAtual && palhaco.PararDeVer==0 
            && Fonte_musica.clip != musicapalhaco[0])
        {
            Fonte_musica.clip= musicapalhaco[0];
            Fonte_musica.Play();
        }
        else
        {
            if(palhaco.PararDeVer> 0F&&Fonte_musica.clip != musicapalhaco[1])
            {
                Fonte_musica.clip = musicapalhaco[1];
                Fonte_musica.Play();
            }
           
        }
        if(palhaco.Localizacao != GameObject.Find("Player").GetComponent<Movimentacao>().AndarAtual && palhaco.PararDeVer == 0)
        {
            Fonte_musica.clip = null;
        }
    }
}
