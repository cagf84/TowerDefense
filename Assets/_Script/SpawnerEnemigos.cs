using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnemigos : MonoBehaviour
{
    public List<GameObject> prefabsEnemigos;
    public int oleada;
    public List<int> enemigosPorOleada;

    private int enemigosDuranteEstaOleada;

    public bool LaOleadaHaIniciado;
    public List<GameObject> EnemigosGenerados;

    public delegate void EstadoOleada();
    public event EstadoOleada EnOleadaTerminada;
    public event EstadoOleada EnOleadaIniciada;
    public event EstadoOleada EnOleadaGandada;

    // Start is called before the first frame update
    void Start()
    {
        oleada = 0;
    }

    public void FixedUpdate()
    {
        if (LaOleadaHaIniciado && EnemigosGenerados.Count == 0)
        {
            GanarOla();
        }
    }

    public void EmpezarOleada()
    {
        LaOleadaHaIniciado = true;
        if (EnOleadaIniciada != null)
        {
            EnOleadaIniciada();
        }
        ConfigurarCantidadDeEnemigos();
        InstanciarEnemigo();
    }

    private void GanarOla()
    {
        if (LaOleadaHaIniciado && EnOleadaGandada != null)
        {
            EnOleadaGandada();
            LaOleadaHaIniciado = false;
        }
    }

    public void TerminarOla()
    {
        if (EnOleadaTerminada != null)
        {
            EnOleadaTerminada();
        }
    }

    public void ConfigurarCantidadDeEnemigos()
    {
        enemigosDuranteEstaOleada = enemigosPorOleada[oleada];
    }

    public void InstanciarEnemigo()
    {
        int indiceAleatorio = Random.Range(0, prefabsEnemigos.Count);
        var enemigosTemporal = Instantiate<GameObject>(prefabsEnemigos[indiceAleatorio], transform.position, Quaternion.identity);
        EnemigosGenerados.Add(enemigosTemporal);

        enemigosDuranteEstaOleada--;
        if (enemigosDuranteEstaOleada < 0)
        {
            oleada++;
            ConfigurarCantidadDeEnemigos();
            TerminarOla();
            return;
        }
        Invoke("InstanciarEnemigo", 2);
    }
}
