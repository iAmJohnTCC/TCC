using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Evento_qt_mae : MonoBehaviour
{
    [SerializeField] GameObject Pilha_felicidade;
    

    // Start is called before the first frame update
  

    // Update is called once per frame
    void Update()
    {
        if(Pilha_felicidade == null)
        {
            GameObject.Find("Player").GetComponent<Movimentacao>().Standby=true;
            GameObject.Find("Player").GetComponent<Movimentacao>().Textoguia.text ="";
            GameObject.Find("Player").GetComponent<SpriteRenderer>().enabled = false;
            GameObject.Find("GameController").GetComponent<GameController>().Fim();
            
        }
    }
   
  
}
