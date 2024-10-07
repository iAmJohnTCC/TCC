using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Speedrun : MonoBehaviour
{
    [SerializeField]TMP_Text Tempo;
   
    void Start()
    {
        Tempo.text= PlayerPrefs.GetInt("Minutos").ToString("00")+":"+PlayerPrefs.GetInt("Segundos").ToString("00");
    }

   
}
