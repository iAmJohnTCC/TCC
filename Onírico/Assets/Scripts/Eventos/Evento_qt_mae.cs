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
           
            GameObject.Find("GameController").GetComponent<GameController>().Fadeout(0.2f,false);
            GameObject.Find("GameController").GetComponent<GameController>().Fim();
            
        }
    }
   
  
}
