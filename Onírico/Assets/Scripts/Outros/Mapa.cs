using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Mapa : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera cam;
    [SerializeField] GameObject Playernomapa;
    GameObject player;
    Animator anim;
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
        if (Minimapa)
        {
            cam.m_Follow = Playernomapa.transform;

            if(player.GetComponent<Movimentacao>().Localizacao!="Banheiro"&& player.GetComponent<Movimentacao>().Localizacao!= "Quarto da Mãe")

            Playernomapa.transform.position = new Vector2(player.transform.position.x + 161.7406f, player.transform.position.y + 0.049935f);
        }
        else
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                transform.position = new Vector3(transform.position.x - (Input.GetAxisRaw("Mouse X") * Time.deltaTime * 50), transform.position.y - (Input.GetAxisRaw("Mouse Y") * Time.deltaTime * 50), transform.position.z);
            }
            transform.position = new Vector3(transform.position.x - (Input.GetAxisRaw("Horizontal") * Time.deltaTime * 5), transform.position.y - (Input.GetAxisRaw("Vertical") * Time.deltaTime * 5), transform.position.z);
        }
      
    }
}
