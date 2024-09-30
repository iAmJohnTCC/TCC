using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Evento_qt_mae : MonoBehaviour
{
    [SerializeField] GameObject Pilha_felicidade;
    [SerializeField] GameObject Fim_cutscene;
    bool Semrepeticoes=false;
    // Start is called before the first frame update
  

    // Update is called once per frame
    void Update()
    {
        if(Pilha_felicidade == null&&!Semrepeticoes)
        {
            GameObject.Find("Player").GetComponent<Movimentacao>().Standby=true;
            GameObject.Find("Player").GetComponent<SpriteRenderer>().enabled = false;
            Instantiate(Fim_cutscene);
            Semrepeticoes=true;
           
        }
    }
  
}
