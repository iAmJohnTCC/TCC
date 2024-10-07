using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evento_Manequim : MonoBehaviour, Interagiveis
{
    [SerializeField] GameObject Chave;
    [SerializeField] Sprite SpriteManequim;
    SpriteRenderer Sprite;
    
    private void Start()
    {
        Sprite = gameObject.GetComponent<SpriteRenderer>();
    }
    
    public void Interacao (Movimentacao prayer)
    {
        if (prayer.Item_Atual!=null&&prayer.Item_Atual.name == "Roupa Rosa")
        {
            
            GameObject.Find("GameController").GetComponent<GameController>().Fadeout(1.4f);
            Invoke(nameof(Droparitem),1.5f);
            prayer.Inventario[0] = null;
        }
        else
        {
            prayer.Textoguia.text = "Parece ter algo na boca do manequin, uma chave talvez?";
        }
    }


    public void Droparitem()
    {
       
            Sprite.sprite = SpriteManequim;
            Instantiate(Chave, new Vector2(-27f, -22), Quaternion.identity);
        GameObject.Find("Player").GetComponent<Movimentacao>().Standby = false;
       GameObject.Find("Player").GetComponent<Movimentacao>().Textoguia.text = "O manequin derrubou uma chave, talvez tenha alguma porta trancada onde eu posso usa-la?";
       
    }
}
