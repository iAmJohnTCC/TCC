using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void Fadeout()
    {
        gameObject.GetComponent<Animator>().Play("Menu2");
        Invoke(nameof(Trocarnivel), 3f);
    }
    public void Trocarnivel()
    {
        
        SceneManager.LoadScene(1);
    }
    public void Sair()
    {
        Application.Quit();
    }
}
