using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Enemigo : EnemigoBase
{
    private void Awake()
    {
        vida = 100;
        _dano = 20;
    }
    public override void OnDestroy()
    {
        base.OnDestroy();
        referenciaAdminJuego.enemigosBaseDerrotados++;
    }
}
