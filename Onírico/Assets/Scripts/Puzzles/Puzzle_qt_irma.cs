using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Puzzle_qt_irma : MonoBehaviour,Interagiveis
{
   [SerializeField]TMP_Text Senha ;
    int Caracteres;
    [SerializeField]GameObject Lanterna;
    [SerializeField]GameObject Gaveta;
    [SerializeField] GameObject UI;
    [SerializeField] GameObject Evento_qtirma;
    [SerializeField] Image tranca;
    [SerializeField] Sprite Desbloqueado;
    [SerializeField] GameObject Minhaluz;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && UI.activeSelf)
        {
            Interacao(GameObject.Find("Player").GetComponent<Movimentacao>());
        }
    }
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
            GameObject.Find("Sons_de_fundo").GetComponent<Fundo_sons>().Sons(0);
            tranca.sprite = Desbloqueado;
            Lanterna = Instantiate(Lanterna,Gaveta.transform.position,Quaternion.identity);
            Evento_qtirma = Instantiate(Evento_qtirma, new Vector2(38, 0f), Quaternion.identity);
            Evento_qtirma.GetComponent<Evento_qt_irma>().Lanterna = Lanterna;
            Destroy(Gaveta);
            Interacao(GameObject.Find("Player").GetComponent<Movimentacao>());
            GameObject.Find("Player").GetComponent<Movimentacao>().transform.position = new Vector2(44f, GameObject.Find("Player").GetComponent<Movimentacao>().transform.position.y);
            gameObject.GetComponent<BoxCollider2D>().enabled=false;

            Minhaluz.SetActive(false);
            Destroy(this.gameObject, 2f);
        }
        else
        {
            GameObject.Find("Player").GetComponent<Movimentacao>().Textoguia.text = "Talvez tenha algo no quarto que possa me ajudar a resolver isso";
            Interacao(GameObject.Find("Player").GetComponent<Movimentacao>());
            
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
    public void Interacao(Movimentacao player)
    {
        GameObject.Find("GameController").GetComponent<GameController>().Fadeout(1,true);
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
