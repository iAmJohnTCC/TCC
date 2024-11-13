using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evento_Manequim : MonoBehaviour, Interagiveis
{
    [SerializeField] GameObject Chave;
    [SerializeField] Sprite SpriteManequim;
    SpriteRenderer Sprite;
    [SerializeField] GameObject Minhaluz;
    
    private void Start()
    {
        Sprite = gameObject.GetComponent<SpriteRenderer>();
    }
    
    public void Interacao (Movimentacao prayer)
    {
        if (prayer.Item_Atual!=null&&prayer.Item_Atual.name == "Roupa Rosa")
        {
            
            GameObject.Find("GameController").GetComponent<GameController>().Fadeout(1.4f,true);
            Invoke(nameof(Droparitem),1.5f);
            prayer.Inventario[prayer.Numeroitem] = null;
        }
        else
        {
            prayer.Textoguia.text = "Só um manequim";
        }
    }


    public void Droparitem()
    {
       
            Sprite.sprite = SpriteManequim;
            Instantiate(Chave, new Vector2(-34.88f, -33.4f), Quaternion.identity);
        GameObject.Find("Player").GetComponent<Movimentacao>().Standby = false;
       GameObject.Find("Player").GetComponent<Movimentacao>().Textoguia.text = "Esse manequim estava escondendo uma chave! Não lembro para que ela serve.";
        Minhaluz.SetActive(false);
    }
}
