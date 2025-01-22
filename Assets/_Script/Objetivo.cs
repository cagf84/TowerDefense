using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objetivo : MonoBehaviour
{

    public int vida = 100;

    public delegate void ObjetivoDestruido();
    public event ObjetivoDestruido EnObjetivoDestruido;

    // Update is called once per frame
    void Update()
    {
        if (vida <= 0)
        {
            if (EnObjetivoDestruido != null)
            {
                EnObjetivoDestruido();
            }
            Destroy(this.gameObject,0.2f);
        }
    }

    public void RecibirDano(int dano = 20)
    {
        vida -= dano;
    }
}
