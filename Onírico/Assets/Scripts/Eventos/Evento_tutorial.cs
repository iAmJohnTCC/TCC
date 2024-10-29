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
    [SerializeField] GameObject Bateria;
    [SerializeField] GameObject Lanterna;
    [SerializeField] GameObject displaynotas;
    bool correupraesquerda, correupradireita;
    bool andoupraesquerda, andoupradireita;
    void Start()
    {
        Tutorialtexto.text = "Filho est� na hora de dormir.";
        Invoke(nameof(troca1),8f);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)&&displaynotas.activeSelf==false)
        {
            GameObject.Find("GameController").GetComponent<GameController>().Fadeout(2f);
            Invoke(nameof(Impaciente), 2.1f);
        }
        if (Ensinamento == "Andar")
        {
            Tutorialtexto.text = "Aperte A/D ou <-/->";
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
            Tutorialtexto.text = "Segure o shift para correr";
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
                Ensinamento = "Pegar itens";
            }
        }
        if (Ensinamento=="Pegar itens")
        {
            Tutorialtexto.text = "Mas antes, pegue aquela pilha que est� no ch�o.";
            if(Bateria==null)
            {
                Player.AdicionarItem(Lanterna);
                Ensinamento = "Trocar itens";
            }
        }
        if(Ensinamento=="Trocar itens")
        {
            Tutorialtexto.text = "Aperte TAB para mostrar o invent�rio. Para trocar de item clique no n�mero em cima dele.";
            if (Player.Inventario[Player.Numeroitem].name=="Lanterna")
            {
               
                    Ensinamento = "Ligar a lanterna";
                
            }
        }
        if(Ensinamento=="Ligar a lanterna")
        {
            Tutorialtexto.text = "Aperte F para ligar a lanterna.";
            if (Player.gameObject.GetComponent<Lanterna>().Luz.activeSelf)
            {
                Ensinamento = "Desligar a lanterna";
            }
            
           
        }
        if (Ensinamento == "Desligar a lanterna")
        {
            Tutorialtexto.text = "Aperte F para desligar a lanterna.";
            if (!Player.gameObject.GetComponent<Lanterna>().Luz.activeSelf)
            {
                Ensinamento = "Recarregar Lanterna";
            }


        }
        if (Ensinamento=="Stun")
        {
            Tutorialtexto.text = "Voc� tamb�m pode apertar F enquanto a lanterna est� acesa para desliga-la, agora quero que voc� aperte espa�o enquanto a lanterna est� acesa";
            Player.gameObject.GetComponent<Lanterna>().Energia = 100;
            if(Player.gameObject.GetComponent<Lanterna>().Stunning)
            {
                Ensinamento = "Recarregar Lanterna";
                Player.gameObject.GetComponent<Lanterna>().Energia = 0;
            }
        }
        if(Ensinamento=="Recarregar Lanterna")
        {
            Tutorialtexto.text = "Aperte R para recarregar a lanterna.";
            
            if (Player.gameObject.GetComponent<Lanterna>().Energia == 100)
            {
                Ensinamento = "Dropar itens";
               
            }
        }
        if(Ensinamento=="Dropar itens")
        {
            Tutorialtexto.text ="Aperte X pra largar o item atual ";
            if (Player.Inventario[0] == null)
            {
                Ensinamento = "Abrir porta";
              
            }
        }
        if(Ensinamento=="Abrir porta")
        {
            Tutorialtexto.text = "Muito bem, vamos para o quarto, docinho.";
            if (Player.Localizacao == "Quarto da crian�a")
            {
                Ensinamento = "Se esconder";
            }
        }
        if(Ensinamento=="Se esconder")
        {
            Tutorialtexto.text = "Agora, est� vendo o arm�rio?, isso � um esconderijo, quando voc� entra nele voc� � praticamente invis�vel para qualquer um , a n�o ser que, voc� foi visto logo antes de entrar, agora aperte E para entrar no arm�rio";
            if(Player.escondido)
            {
                Ensinamento = "Lernota";
            }
        }
        if(Ensinamento=="Lernota")
        {
            Tutorialtexto.text = "Voc� realmente � o orgulho da m�e. para sair do arm�rio � s� apertar E novamente, antes de ir dormir, leia a nota que eu fiz caso voc� esquecer de algo, ela est� na sua cama, aperte E para interagir enquanto a nota brilha";
            if(displaynotas.activeSelf == true)
            {
                Ensinamento = "j� segurei sua m�o demais";
            }
        }
        if(Ensinamento=="j� segurei sua m�o demais")
        {
            Tutorialtexto.text = "Ok filho pode ir dormir, � s� apertar ESC";
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
