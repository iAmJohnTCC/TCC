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
        Tutorialtexto.text = "Filho está na hora de dormir.";
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
            Tutorialtexto.text = "Você também pode apertar F enquanto a lanterna está acesa para desliga-la, agora quero que você aperte espaço enquanto a lanterna está acesa";
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
            if (Player.Localizacao == "Quarto da criança")
            {
                Ensinamento = "Se esconder";
            }
        }
        if(Ensinamento=="Se esconder")
        {
            Tutorialtexto.text = "Agora, está vendo o armário?, isso é um esconderijo, quando você entra nele você é praticamente invisível para qualquer um , a não ser que, você foi visto logo antes de entrar, agora aperte E para entrar no armário";
            if(Player.escondido)
            {
                Ensinamento = "Lernota";
            }
        }
        if(Ensinamento=="Lernota")
        {
            Tutorialtexto.text = "Você realmente é o orgulho da mãe. para sair do armário é só apertar E novamente, antes de ir dormir, leia a nota que eu fiz caso você esquecer de algo, ela está na sua cama, aperte E para interagir enquanto a nota brilha";
            if(displaynotas.activeSelf == true)
            {
                Ensinamento = "já segurei sua mão demais";
            }
        }
        if(Ensinamento=="já segurei sua mão demais")
        {
            Tutorialtexto.text = "Ok filho pode ir dormir, é só apertar ESC";
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
