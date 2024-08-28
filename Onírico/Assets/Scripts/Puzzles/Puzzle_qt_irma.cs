using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Puzzle_qt_irma : MonoBehaviour
{
   [SerializeField]TMP_Text Senha ;
    int Caracteres;
    [SerializeField]GameObject Lanterna;
    [SerializeField]GameObject Gaveta;
    [SerializeField] GameObject UI;
    [SerializeField] GameObject Evento_qtirma;

    
    public void Adicionarnumero(int valor)
    {
        if (Caracteres < 4)
        {
            Senha.text = Senha.text + valor.ToString();
            Caracteres++;
        }   
    }

    public void Enter()
    {
        if (Senha.text == "1984")
        {
            Lanterna = Instantiate(Lanterna,new Vector2(35,0f),Quaternion.identity);
            Evento_qtirma = Instantiate(Evento_qtirma, new Vector2(38, 0f), Quaternion.identity);
            Evento_qtirma.GetComponent<Evento_qt_irma>().Lanterna = Lanterna;
            Destroy(Gaveta);
            Desativar();
            Destroy(this.gameObject, 1f);
        }
        else
        {
            Desativar();
            
        }
    }
    public void Iniciar()
    {
        GameObject.Find("GameController").GetComponent<GameController>().Fadeout(1);
        Invoke(nameof(Ui), 1.1f);
        Senha.text = "";
    }
    void Ui()
    {
        if(UI.activeSelf)
        {
            UI.SetActive(false);
        }
        else
        {
            UI.SetActive(true);
        }
    }
    private void Desativar()
    {
        GameObject.Find("GameController").GetComponent<GameController>().Fadeout(1);
        Invoke(nameof(Ui), 1.1f);
       
    }

}
