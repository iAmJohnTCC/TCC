using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.U2D;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{
   [SerializeField] Image image;
    GameObject luz;
    int M, S;
    public bool Bosstime = false;
   [SerializeField] Evento_Gerador_Parte2 Bool;
    void Start()
    {
        image.CrossFadeAlpha(1, 0, false);
        image.CrossFadeAlpha(0, 2f, false);
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            InvokeRepeating(nameof(Tempo), 1, 1);
        }
        GameObject[]Roupas=GameObject.FindGameObjectsWithTag("Roupas");
        for(int i = 0; i < Roupas.Length; i++)
        {
            Roupas[i].GetComponent<scr_roupas>().Voltaraorigem();
        }

    }

   
    
    public void Fadeout(float time)
    {
        CancelInvoke(nameof(Fadein));
        GameObject.Find("Player").GetComponent<Movimentacao>().Standby = true;
        image.CrossFadeAlpha(0, 0, false);
        image.CrossFadeAlpha(time, 1, false);
        Invoke(nameof(Fadein), time+0.5f);
    }
    void Fadein()
    {
        
        image.CrossFadeAlpha(1, 0, false);
        image.CrossFadeAlpha(0, 0.5f, false);
      
    }
    public void Ligarluz(GameObject luzes)
    {
        
        luz = luzes;
        if (!luz.GetComponent<Light2DBase>().enabled && Bool.PodeLigar)
        {
            Bosstime = true;
            luz.GetComponent<Light2DBase>().enabled = true;
            luz.GetComponent<PolygonCollider2D>().enabled = true;

            Invoke(nameof(Desligarluz), 0.6f);
        }
    }
    void Desligarluz()
    {
        luz.GetComponent<Light2DBase>().enabled = false;
        luz.GetComponent<PolygonCollider2D>().enabled = false;
    }
    public void Mudarcena (int i)
    {
        SceneManager.LoadScene(i);
    }
    
    public void Morte()
    {
        Animator anim= GetComponent<Animator>();
        anim.Play("GameController_Death");
    }
    void Tempo()
    {
        S++;
        if(S==60)
        {
            M++;
            S = 0;
           

        }
    }
    public void Fim()
    {
        CancelInvoke(nameof(Morte));
       
      
            PlayerPrefs.SetInt("Minutos", M);
            PlayerPrefs.SetInt("Segundos", S);
            PlayerPrefs.Save();
              Mudarcena(4);
    }
    
}
