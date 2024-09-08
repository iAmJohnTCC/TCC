using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Puzzle_qt_irma : MonoBehaviour
{
   [SerializeField]TMP_Text Senha ;
    int Caracteres;
    [SerializeField]GameObject Lanterna;
    [SerializeField]GameObject Gaveta;
    [SerializeField] GameObject UI;
    [SerializeField] GameObject Evento_qtirma;
    [SerializeField] Image tranca;
    [SerializeField] Sprite Desbloqueado;

    
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
            tranca.sprite = Desbloqueado;
            Lanterna = Instantiate(Lanterna,new Vector2(35,0f),Quaternion.identity);
            Evento_qtirma = Instantiate(Evento_qtirma, new Vector2(38, 0f), Quaternion.identity);
            Evento_qtirma.GetComponent<Evento_qt_irma>().Lanterna = Lanterna;
            Destroy(Gaveta);
            Iniciar();
            Destroy(this.gameObject, 2f);
        }
        else
        {
            Iniciar();
            
        }
    }
    public void Delete ()
    {
        if (Caracteres > 0)
        {
            Senha.text=Senha.text.Remove(Caracteres-1);
            Caracteres--;
        }
    }
    public void Iniciar()
    {
        GameObject.Find("GameController").GetComponent<GameController>().Fadeout(1);
        Invoke(nameof(Ui), 1.1f);
       
    }
    void Ui()
    {
        if(UI.activeSelf)
        {
            UI.SetActive(false);
            GameObject.Find("Player").GetComponent<Movimentacao>().Standby = false;
        }
        else
        {
            UI.SetActive(true);
            Senha.text = "";
            Caracteres = 0;
        }
    }
    

}
