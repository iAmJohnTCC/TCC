using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evento_qt_irma : MonoBehaviour
{
    [SerializeField] GameObject Palhaco_intro;
    [SerializeField] GameObject Palhaco;
    public GameObject Lanterna;
    bool semRepetir=false;

    private void Start()
    {
        Palhaco = GameObject.Find("Teste");
    }
    void Update()
    {
        if(Lanterna==null&&!semRepetir)
        {
            Intro();
            semRepetir = true;
        }
        
    }
    void Intro()
    {
        GameObject.Find("Player").GetComponent<Movimentacao>().Standby=true;
        Palhaco_intro=Instantiate(Palhaco_intro, transform.position, Quaternion.identity);
        Invoke(nameof(Funbegins),3f);
    }
    void Funbegins()
    {
        Destroy(Palhaco_intro);
        Palhaco.transform.position=transform.position;
        Palhaco.GetComponent<Palhaco>().To_Vendo_Player = true;
        GameObject.Find("Player").GetComponent<Movimentacao>().Standby = false;
    }
}
