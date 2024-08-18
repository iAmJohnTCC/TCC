using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class GameController : MonoBehaviour
{
   [SerializeField] Image image;
   
    void Start()
    {
        image.CrossFadeAlpha(0, 0, false);
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    
    public void Fadeout()
    {
        GameObject.Find("Player").GetComponent<Movimentacao>().Standby = true;
        image.CrossFadeAlpha(0, 0, false);
        image.CrossFadeAlpha(1.5f, 1, false);
        Invoke("Fadein",1.5f);
    }
    void Fadein()
    {
        image.CrossFadeAlpha(1, 0, false);
        image.CrossFadeAlpha(0, 0.5f, false);
        GameObject.Find("Player").GetComponent<Movimentacao>().Standby = false;
    }
}
