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
    void Start()
    {
        
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
            Tutorialtexto.text = "Filho tá quase na hora de dormir,mas antes de ir deitar, deixa eu te relembrar de algumas coisas, você se move pra esquerda ou pra direita apertando respectivamente A e D(< e > fazem a mesma coisa), segurando o Shift esquerdo e apertando A ou D você corre. Agora corra para esquerda e para direita para me mostrar que entendeu";
            if(Input.GetAxisRaw("Horizontal")>0&&Input.GetKey(KeyCode.LeftShift))
            {
                correupradireita = true;
            }
            if (Input.GetAxisRaw("Horizontal") < 0 && Input.GetKey(KeyCode.LeftShift))
            {
                correupraesquerda = true;
            }
            if(correupradireita&&correupraesquerda)
            {
                Ensinamento = "Pegar itens";
            }

        }
        if (Ensinamento=="Pegar itens")
        {
            Tutorialtexto.text = "Muito bom, agora, está vendo aquela Pilha ? ande até ela e aperte E enquanto estiver brilhando";
            if(Bateria==null)
            {
                Player.AdicionarItem(Lanterna);
                Ensinamento = "Trocar itens";
            }
        }
        if(Ensinamento=="Trocar itens")
        {
            Tutorialtexto.text = "Continue assim! Agora abra o seu inventário apertando TAB, eu quero que você tenha a lanterna como item principal, para trocar de item aperte o número do teclado correspondente ao número do item";
            if (Player.Inventario[0].name=="Lanterna")
            {
               
                    Ensinamento = "Ligar a lanterna";
                
            }
        }
        if(Ensinamento=="Ligar a lanterna")
        {
            Tutorialtexto.text = "Melhor se acostumar a trocar de itens, acredite você vai precisar, agora quero que você ligue a lanterna( Aperte F para ligar a lanterna)";
            if (Player.gameObject.GetComponent<Lanterna>().Luz.activeSelf)
            {
                Ensinamento = "Stun";
            }
            
           
        }
        if(Ensinamento=="Stun")
        {
            Tutorialtexto.text = "Você também pode apertar F enquanto a lanterna está acesa para desliga-la, agora quero que você aperte espaço enquanto a lanterna está acesa";
            Player.gameObject.GetComponent<Lanterna>().Energia = 100;
            if(Player.gameObject.GetComponent<Lanterna>().Stunning)
            {
                Ensinamento = "Recarregar Lanterna";
            }
        }
        if(Ensinamento=="Recarregar Lanterna")
        {
            Tutorialtexto.text = "Você acabou de amplificar a luz da lanterna, como pode perceber isso gasta muito energia, mas qualquer coisa que for pega por isso ficará no mínimo cega por alguns segundos,exceto talvez insetos, agora quero que você troque de pilha, aperte R para trocar de pilha";
            Player.gameObject.GetComponent<Lanterna>().Energia = 0;
            if(Player.Inventario[1]==null)
            {
                Ensinamento = "Dropar itens";
                Player.gameObject.GetComponent<Lanterna>().Energia = 100;
            }
        }
        if(Ensinamento=="Dropar itens")
        {
            Tutorialtexto.text = "Se você abrir o inventário agora vai perceber que a pilha sumiu, esse é o pequeno sacrifício que deve ser feito toda vez que você troca de pilha, mais uma coisa você só pode recarregar quando a energia chegar a 0%. Agora eu quero que você largue a lanterna, aperte X pra largar o item atual ";
            if (Player.Inventario[0] == null)
            {
                Ensinamento = "Abrir porta";
              
            }
        }
        if(Ensinamento=="Abrir porta")
        {
            Tutorialtexto.text = "Agora vá para a esquerda o máximo que puder, está vendo essa porta?, entre nela. Lembre-se qualquer objeto que começa a brilhar quando você chega perto pode ser interagido com E";
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
    void Impaciente()
    {
        SceneManager.LoadScene(2);
    }
}
