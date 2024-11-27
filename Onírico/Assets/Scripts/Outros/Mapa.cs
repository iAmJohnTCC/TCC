using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using TMPro;

public class Mapa : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera cam;
    [SerializeField] GameObject Playernomapa;
    GameObject player;
    [SerializeField]Animator anim;
    public TMP_Text objetivo;
    public TMP_Text objetivo2;
    public bool Minimapa = true;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        cam.m_Lens.OrthographicSize -= Input.mouseScrollDelta.y * Time.deltaTime * 50;
        cam.m_Lens.OrthographicSize=Mathf.Clamp(cam.m_Lens.OrthographicSize,1,29.5f);
        if (Minimapa)
        {
            cam.m_Follow = Playernomapa.transform;

            if(player.GetComponent<Movimentacao>().Localizacao!="Banheiro"&& player.GetComponent<Movimentacao>().Localizacao!= "Quarto da Mãe")
            {
                Playernomapa.transform.position = new Vector2(player.transform.position.x + 161.7406f, player.transform.position.y + 0.049935f);
                if (player.GetComponent <Movimentacao>().AndarAtual== "2° andar")
                {
                    anim.Play("Mapa_1andar");
                }
                else
                {
                    if (player.GetComponent<Movimentacao>().AndarAtual == "1° andar")
                    {
                        anim.Play("Mapa_2andar");
                    }
                    else
                    {
                        anim.Play("Mapa_porao");
                    }
                }
            }
            else
            {
                anim.Play("Mapa_interiores");
            }
           
        }
        else
        {
            cam.m_Follow = null;
            float Horizontalmovement, Verticalmovement;
           
            Horizontalmovement = transform.position.x + (Input.GetAxisRaw("Horizontal") * Time.deltaTime * 30);
            Verticalmovement = transform.position.y + (Input.GetAxisRaw("Vertical") * Time.deltaTime * 30);
            if (Input.GetKey(KeyCode.Mouse0))
            {
                Horizontalmovement = transform.position.x - (Input.GetAxisRaw("Mouse X") * Time.deltaTime * 100);
                Verticalmovement = transform.position.y - (Input.GetAxisRaw("Mouse Y") * Time.deltaTime * 100);

            }
            Horizontalmovement = Mathf.Clamp(Horizontalmovement, 118, 210);
            Verticalmovement = Mathf.Clamp(Verticalmovement, -42, 9.5f);
            transform.position = new Vector3(Horizontalmovement, Verticalmovement, transform.position.z);

        }
      
    }
}
