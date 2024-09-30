using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scr_roupas : MonoBehaviour
{
   public float R, G, B;
    [SerializeField]float OGr, OGg, OGb;
     SpriteRenderer meusprite;
    public string OGtipo;
    public string tipocor;

    private void Start()
    {
        meusprite = GetComponent<SpriteRenderer>();
      
    }
    
    

    // Update is called once per frame
    void Update()
    {
      
      meusprite.color=new Color(R, G, B);

    }
    public void Mudarcor(float r,float g, float b)
    {
        R = r; G=g; B=b;
    }
    public void Voltaraorigem()
    {
        R = OGr; G = OGg; B = OGb;
        tipocor = OGtipo;
    }
}
