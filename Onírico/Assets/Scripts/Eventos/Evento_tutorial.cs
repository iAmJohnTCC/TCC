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
            Tutorialtexto.text = "Filho t� quase na hora de dormir,mas antes de ir deitar, deixa eu te relembrar de algumas coisas, voc� se move pra esquerda ou pra direita apertando respectivamente A e D(< e > fazem a mesma coisa), segurando o Shift esquerdo e apertando A ou D voc� corre. Agora corra para esquerda e para direita para me mostrar que entendeu";
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
            Tutorialtexto.text = "Muito bom, agora, est� vendo aquela Pilha ? ande at� ela e aperte E enquanto estiver brilhando";
            if(Bateria==null)
            {
                Player.AdicionarItem(Lanterna);
                Ensinamento = "Trocar itens";
            }
        }
        if(Ensinamento=="Trocar itens")
        {
            Tutorialtexto.text = "Continue assim! Agora abra o seu invent�rio apertando TAB, eu quero que voc� tenha a lanterna como item principal, para trocar de item aperte o n�mero do teclado correspondente ao n�mero do item";
            if (Player.Inventario[0].name=="Lanterna")
            {
               
                    Ensinamento = "Ligar a lanterna";
                
            }
        }
        if(Ensinamento=="Ligar a lanterna")
        {
            Tutorialtexto.text = "Melhor se acostumar a trocar de itens, acredite voc� vai precisar, agora quero que voc� ligue a lanterna( Aperte F para ligar a lanterna)";
            if (Player.gameObject.GetComponent<Lanterna>().Luz.activeSelf)
            {
                Ensinamento = "Stun";
            }
            
           
        }
        if(Ensinamento=="Stun")
        {
            Tutorialtexto.text = "Voc� tamb�m pode apertar F enquanto a lanterna est� acesa para desliga-la, agora quero que voc� aperte espa�o enquanto a lanterna est� acesa";
            Player.gameObject.GetComponent<Lanterna>().Energia = 100;
            if(Player.gameObject.GetComponent<Lanterna>().Stunning)
            {
                Ensinamento = "Recarregar Lanterna";
            }
        }
        if(Ensinamento=="Recarregar Lanterna")
        {
            Tutorialtexto.text = "Voc� acabou de amplificar a luz da lanterna, como pode perceber isso gasta muito energia, mas qualquer coisa que for pega por isso ficar� no m�nimo cega por alguns segundos,exceto talvez insetos, agora quero que voc� troque de pilha, aperte R para trocar de pilha";
            Player.gameObject.GetComponent<Lanterna>().Energia = 0;
            if(Player.Inventario[1]==null)
            {
                Ensinamento = "Dropar itens";
                Player.gameObject.GetComponent<Lanterna>().Energia = 100;
            }
        }
        if(Ensinamento=="Dropar itens")
        {
            Tutorialtexto.text = "Se voc� abrir o invent�rio agora vai perceber que a pilha sumiu, esse � o pequeno sacrif�cio que deve ser feito toda vez que voc� troca de pilha, mais uma coisa voc� s� pode recarregar quando a energia chegar a 0%. Agora eu quero que voc� largue a lanterna, aperte X pra largar o item atual ";
            if (Player.Inventario[0] == null)
            {
                Ensinamento = "Abrir porta";
              
            }
        }
        if(Ensinamento=="Abrir porta")
        {
            Tutorialtexto.text = "Agora v� para a esquerda o m�ximo que puder, est� vendo essa porta?, entre nela. Lembre-se qualquer objeto que come�a a brilhar quando voc� chega perto pode ser interagido com E";
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
    void Impaciente()
    {
        SceneManager.LoadScene(2);
    }
}
