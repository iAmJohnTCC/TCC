using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.U2D;
public class GameController : MonoBehaviour
{
   [SerializeField] Image image;
    GameObject luz;
    void Start()
    {
        image.CrossFadeAlpha(0, 0, false);

      GameObject[]Roupas=GameObject.FindGameObjectsWithTag("Roupas");
        for(int i = 0; i < Roupas.Length; i++)
        {
            Roupas[i].GetComponent<scr_roupas>().Voltaraorigem();
        }

    }

    // Update is called once per frame
    void Update()
    {
      
    }
    
    public void Fadeout(float time)
    {
        GameObject.Find("Player").GetComponent<Movimentacao>().Standby = true;
        image.CrossFadeAlpha(0, 0, false);
        image.CrossFadeAlpha(time, 1, false);
        Invoke(nameof(Fadein), time+0.2f);
    }
    void Fadein()
    {
        
        image.CrossFadeAlpha(1, 0, false);
        image.CrossFadeAlpha(0, 0.5f, false);
       
    }
    public void Ligarluz(GameObject luzes)
    {
        luzes.GetComponent<Light2DBase>().enabled = true;
        luzes.GetComponent<PolygonCollider2D>().enabled = true;
        luz = luzes;
        Invoke(nameof(Desligarluz),0.6f);
    }
    void Desligarluz()
    {
        luz.GetComponent<Light2DBase>().enabled = false;
        luz.GetComponent<PolygonCollider2D>().enabled = false;
    }
}
