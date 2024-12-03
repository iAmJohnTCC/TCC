using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] AudioSource som;
    public void Fadeout()
    {
        som.Play();
        gameObject.GetComponent<Animator>().Play("Menu2");
        Invoke(nameof(Trocarnivel), 3f);
    }
    public void Creditos()
    {
        som.Play();
        gameObject.GetComponent<Animator>().Play("Menu3");
    }
    public void Voltar()
    {
        som.Play();
        gameObject.GetComponent<Animator>().Play("Menu4");
    }
    public void Trocarnivel()
    {
        
        SceneManager.LoadScene(1);
    }
    public void Sair()
    {
        som.Play();
        Application.Quit();
    }
}
