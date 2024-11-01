using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Cutscene_fim : MonoBehaviour
{
[SerializeField] int cena;
[SerializeField] float tempocutscene;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("mudarcena",tempocutscene);
    }

    
    void Update()
    {
     if(Input.GetKeyDown(KeyCode.Escape))
     {
      mudarcena();
     }
    }
    void mudarcena()
    {
      SceneManager.LoadScene(cena);
    }
}
