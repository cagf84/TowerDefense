using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class AdministradorUI : MonoBehaviour
{
    public GameObject canvasPrincipal;
    public GameObject menuGameOver;
    public GameObject menuOlaGanada;
    public GameObject MensajeFinOla;
    public SpawnerEnemigos referenciaSpawner;
    public Objetivo referenciaObjetivo;
    public AdminJuego referenciaAdminJuego;
    public TMP_Text textoRecursos;
    public TMP_Text textoOleadas;
    public TMP_Text textoEnemigos;
    public TMP_Text textoJefes;



    private void OnEnable()
    {
        referenciaObjetivo.EnObjetivoDestruido += MostrarMenuGameOver;
        referenciaSpawner.EnOleadaIniciada += ActualizarOla;
        referenciaSpawner.EnOleadaTerminada += MostrarMensajeUltimoEnemigo;
        referenciaSpawner.EnOleadaGanada += MostrarMenuOlaGanada;
        referenciaAdminJuego.EnRecursosModificados += ActualizarRecursos;
    }

    private void OnDisable()
    {
        referenciaObjetivo.EnObjetivoDestruido -= MostrarMenuGameOver;
        referenciaSpawner.EnOleadaIniciada -= ActualizarOla;
        referenciaSpawner.EnOleadaTerminada -= MostrarMensajeUltimoEnemigo;
        referenciaSpawner.EnOleadaGanada -= MostrarMenuOlaGanada;
        referenciaAdminJuego.EnRecursosModificados -= ActualizarRecursos;
    }

    public void ActualizarRecursos()
    {
        textoRecursos.text = $"Recursos: {referenciaAdminJuego.recursos}";
    }

    public void MostrarMensajeUltimoEnemigo()
    {
        MensajeFinOla.SetActive(true);
        Invoke("OcultarMensajeUltimoEnemigo", 2);
    }

    public void OcultarMensajeUltimoEnemigo()
    {
        MensajeFinOla.SetActive(false);
    }
    public void MostrarMenuOlaGanada()
    {
        textoEnemigos.text = $"ENEMIGOS: \t {referenciaAdminJuego.enemigosBaseDerrotados}";
        textoJefes.text = $"JEFES: \t\t  {referenciaAdminJuego.enemigosJefeDerrotados}";
        menuOlaGanada.SetActive(true);
    }

    public void OcultarMenuOlaGanada()
    {
        menuOlaGanada.SetActive(false);
    }

    public void ActualizarOla()
    {
        textoOleadas.text = $"Ola: {referenciaSpawner.oleada}";
        OcultarMenuOlaGanada();
    }

    public void MostrarMenuGameOver()
    {
        menuGameOver.SetActive(true);
    }

    public void OcultarMenuGameOver()
    {
        menuGameOver.SetActive(false);
    }

    public void FinalizarJuego()
    {  
        Application.Quit();
    }

    public void CargarMenuPrincipal()
    {
        SceneManager.LoadScene(0);
    }

    public void ReintentarNivel()
    {
        int escenaActual = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(escenaActual);
    }
}
