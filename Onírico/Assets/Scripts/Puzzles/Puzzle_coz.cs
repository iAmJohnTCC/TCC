using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puzzle_coz : MonoBehaviour
{
    [SerializeField]int[]Gas=new int[3];
    [SerializeField]Image [] Img_gas=new Image[3];
    [SerializeField] GameObject ui;
    string Status="";
    [SerializeField] GameObject VelaAcesa;
    Movimentacao player;
    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<Movimentacao>();
    }
    private void Update()
    {
        if(player.Hit.transform!=null&&player.Hit.transform.gameObject==this.gameObject&&Input.GetKeyDown(KeyCode.E))
        {
            if(Status=="")
            {
                Ativar();
            }
            else
            {
                if(Status=="Gasativo"&&player.Item_Atual.name=="Acendedor")
                {
                    Status="Acendeu";
                }
                else
                {
                    if (Status=="Acendeu"&& player.Item_Atual.name=="Vela")
                    {
                        player.Inventario[0] = null;
                        player.Inventario[0] = VelaAcesa;
                    }
                }
            }
        }
        if (Gas[0]/12.5 != Img_gas[0].transform.localScale.y)
        {
            Animacao1();
        }

        if (Img_gas[1].transform.localScale.y != Gas[1] / 12.5)
        { 
         Animacao2();
        }
        if (Img_gas[2].transform.localScale.y != Gas[2] / 12.5)
        {
            Animacao3();
        }
        if (Img_gas[0].transform.localScale.y==4&& Img_gas[1].transform.localScale.y == 4 && Img_gas[2].transform.localScale.y == 4
            && Status=="")
        {
            Status = "Gasativo";
            Ui();
            
        }
        if(Input.GetKeyDown(KeyCode.Escape)&&ui.activeSelf)
        {
            Ativar();
        }
    }
    public void Ativar()
    {
        Gas[0] = 0;
        Gas[1] = 0;
        Gas[2] = 0;
        GameObject.Find("GameController").GetComponent<GameController>().Fadeout(1);
        Invoke(nameof(Ui), 1.1f);
      
    }
    void Ui()
    {
        if(ui.activeSelf==false)
        {
            ui.SetActive(true);
        }
        else
        {
            player.Standby = false;
            ui.SetActive(false);

        }
    }
    void Animacao1()
    {
        if (Img_gas[0].transform.localScale.y < (Gas[0] / 12.5) + 0.01 && Img_gas[0].transform.localScale.y > (Gas[0] / 12.5) - 0.01)
        {
            Img_gas[0].transform.localScale =
                new Vector3(Img_gas[0].transform.localScale.x, (Gas[0] / 12.5f), Img_gas[0].transform.localScale.z);
        }
        else
        {
            float i;
            if (Img_gas[0].transform.localScale.y > Gas[0]/12.5f)
            {
                i = -1;

            }
            else
            {


                i = 1;
            }
            Img_gas[0].transform.localScale += new Vector3(0, i * Time.deltaTime, 0);
        }



    }

    void Animacao2()
    {
        if (Img_gas[1].transform.localScale.y < (Gas[1] / 12.5) + 0.01 && Img_gas[1].transform.localScale.y > (Gas[1] / 12.5) - 0.01)
        {
            Img_gas[1].transform.localScale =
                new Vector3(Img_gas[1].transform.localScale.x, (Gas[1] / 12.5f), Img_gas[1].transform.localScale.z);
        }
        else
        {
            float i;
            if (Img_gas[1].transform.localScale.y > Gas[1]/12.5f)
            {
                i = -1;

            }
            else
            {


                i = 1;
            }
            Img_gas[1].transform.localScale += new Vector3(0, i * Time.deltaTime, 0);
        }


    }
    void Animacao3() 
    {
        if (Img_gas[2].transform.localScale.y < (Gas[2] / 12.5) + 0.01 && Img_gas[2].transform.localScale.y > (Gas[2] / 12.5) - 0.01)
        {
            Img_gas[2].transform.localScale =
                new Vector3(Img_gas[2].transform.localScale.x, (Gas[2] / 12.5f), Img_gas[2].transform.localScale.z);
        }
        else
        {
            float i;
            if (Img_gas[2].transform.localScale.y > Gas[2]/12.5f)
            {
                i = -1;

            }
            else
            {


                i = 1;
            }
            Img_gas[2].transform.localScale += new Vector3(0, i * Time.deltaTime, 0);
        }



    }
    public void Mudargas1()
    {
        Gas[0] += 50;
        Gas[1] += 25;
        Gas[2] -= 25;

        Gas[0] = Mathf.Clamp(Gas[0], 0, 100);
        Gas[1] = Mathf.Clamp(Gas[1], 0, 100);
        Gas[2] = Mathf.Clamp(Gas[2], 0, 100);
        
    }
    public void Mudargas2()
    {
        Gas[0] -= 25;
        Gas[1] += 50;
        Gas[2] -= 25;

        Gas[0] = Mathf.Clamp(Gas[0], 0, 100);
        Gas[1] = Mathf.Clamp(Gas[1], 0, 100);
        Gas[2] = Mathf.Clamp(Gas[2], 0, 100);

    }
    public void Mudargas3()
    {
        Gas[0] -= 25;
        Gas[1] -= 25;
        Gas[2] += 25 ;

        Gas[0] = Mathf.Clamp(Gas[0], 0, 100);
        Gas[1] = Mathf.Clamp(Gas[1], 0, 100);
        Gas[2] = Mathf.Clamp(Gas[2], 0, 100);

    }

}
