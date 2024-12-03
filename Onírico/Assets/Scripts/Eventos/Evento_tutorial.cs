using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Evento_tutorial : MonoBehaviour
{
    [SerializeField] string Ensinamento;
    [SerializeField] TMP_Text Tutorialtexto;
    [SerializeField] Movimentacao Player;
    string Textoantigo;
    bool justonce=true;
    [SerializeField] GameObject Bateria;
    [SerializeField] GameObject Lanterna;
    [SerializeField] GameObject displaynotas;
    [SerializeField]Porta door;
    bool correupraesquerda, correupradireita;
    bool andoupraesquerda, andoupradireita;
    void Start()
    {
        Tutorialtexto.text = "Filho está na hora de dormir.";
        Invoke(nameof(troca1),8f);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)&&justonce)
        {
            justonce=false;
            GameObject.Find("GameController").GetComponent<GameController>().Fadeout(2f,false);
            Invoke(nameof(Impaciente), 2.1f);
        }
        if (Ensinamento == "Andar")
        {
            Tutorialtexto.text = "Aperte A/D ou <-/->.";
            if (Input.GetAxisRaw("Horizontal")>0)
            {
                andoupradireita = true;
            }
            if (Input.GetAxisRaw("Horizontal") < 0 )
            {
                andoupraesquerda = true;
            }
            if(andoupradireita&&andoupraesquerda)
            {
                Ensinamento = "Correr";
            }

        }
        if(Ensinamento=="Correr")
        {
            Tutorialtexto.text = "'Segure o shift para correr'";
            if (Input.GetAxisRaw("Horizontal") > 0&&Input.GetKey(KeyCode.LeftShift))
            {
                correupradireita = true;
            }
            if (Input.GetAxisRaw("Horizontal") < 0 && Input.GetKey(KeyCode.LeftShift))
            {
                correupraesquerda = true;
            }
            if (correupradireita && correupraesquerda)
            {
                Ensinamento = "Abrir mapa";
            }
        }
        if (Ensinamento == "Abrir mapa")
        {
            Tutorialtexto.text = "'Aperte M para abrir o mapa'";
            if(Player.Mapa.activeSelf)
            {
                andoupradireita = false;
                andoupraesquerda = false;
                Ensinamento = "Mover mapa";
            }

        }
        if (Ensinamento == "Mover mapa")
        {
            Tutorialtexto.text = "Aperte A/D ou <-/-> para mexer o mapa.";
            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                andoupradireita = true;
            }
            if (Input.GetAxisRaw("Horizontal") < 0)
            {
                andoupraesquerda = true;
            }
            if (andoupradireita && andoupraesquerda)
            {
                Ensinamento = "Zoom";
            }

        }
        if (Ensinamento == "Zoom")
        {
            Tutorialtexto.text = "'Utilize o scroll do mouse para aumentar ou diminuir o zoom .'";
         if(Player.Mapa.GetComponent<Camera>().orthographicSize!=8)
            {
                Ensinamento = "Sair mapa";
            }

        }
        if (Ensinamento == "Sair mapa")
        {
            Tutorialtexto.text = "'Aperte M para fechar o mapa'";
            if (!Player.Mapa.activeSelf)
            {
                Ensinamento = "Pegar itens";
            }

        }


        if (Ensinamento=="Pegar itens")
        {
            Tutorialtexto.text = "Mas antes, pegue aquela pilha que está no chão.";
            if(Bateria==null)
            {
                Player.AdicionarItem(Lanterna);
                Ensinamento = "Trocar itens";
            }
        }
        if(Ensinamento=="Trocar itens")
        {
            Tutorialtexto.text = "Aperte TAB para mostrar o inventário. Para trocar de item clique no número em cima dele.";
            if (Player.Inventario[Player.Numeroitem].name=="Lanterna")
            {
               
                    Ensinamento = "Ligar a lanterna";
                
            }
        }
        if(Ensinamento=="Ligar a lanterna")
        {
            Tutorialtexto.text = "'Aperte F para ligar a lanterna.'";
            if (Player.gameObject.GetComponent<Lanterna>().Luz.activeSelf)
            {
                Ensinamento = "Desligar a lanterna";
            }
            
           
        }
        if (Ensinamento == "Desligar a lanterna")
        {
            Tutorialtexto.text = "'Aperte F para desligar a lanterna.'";
            if (!Player.gameObject.GetComponent<Lanterna>().Luz.activeSelf)
            {
                Ensinamento = "Recarregar Lanterna";
            }


        }
       
        if(Ensinamento=="Recarregar Lanterna")
        {
            Tutorialtexto.text = "'Aperte R para recarregar a lanterna.'";
            
            if (Player.Inventario[0]==null||Player.Inventario[1]==null)
            {
                Ensinamento = "Dropar itens";
               
            }
        }
        if(Ensinamento=="Dropar itens")
        {
            Tutorialtexto.text ="'Aperte X pra largar o item atual' ";
            if (Player.Inventario[1] == null)
            {
                Ensinamento = "Abrir porta";
                gameObject.GetComponent<BoxCollider2D>().isTrigger=true;
            }
        }
        if(Ensinamento=="Abrir porta")
        {
            Tutorialtexto.text = "Muito bem, vamos para o quarto, docinho.";
             if(transform.position.x>-14.37f)
            {
            gameObject.GetComponent<Animator>().Play("Mae_andando");
            transform.position=Vector2.MoveTowards(transform.position, new Vector2(-14.37f, transform.position.y), 2f*Time.deltaTime);
            
            }
            else
            {
               gameObject.GetComponent<Animator>().Play("Mae_idle");
            }
            if (Player.Localizacao == "Quarto da criança")
            {
                Impaciente();
            }
        }

        if(Textoantigo!=Ensinamento)
        {
            Tutorialtexto.gameObject.GetComponent<Animator>().Play("Texto_tutorial", 0, 0);
            Textoantigo = Ensinamento;
        }
    }
    void troca1()
    {
        Ensinamento = "Andar";
    }
    void Impaciente()
    {
        SceneManager.LoadScene(2);
    }
}
