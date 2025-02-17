using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AdministradorUI : MonoBehaviour
{
    public GameObject CanvasPrincipal;
    public GameObject GameOverMenu;
    public GameObject MenuOlaGanada;
    public GameObject MensjaeFinOla;
    public SpawnerEnemigos referenciaSpawner;
    public Objetivo referenciaObjetivo;
    public AdminJuego referenciaAdminJuego;
    public TMPro.TMP_Text textoRecursos;
    public TMPro.TMP_Text textoOleada;
    public TMPro.TMP_Text textoEnemigos;
    public TMPro.TMP_Text textoJefes;

    private void OnEnable()
    {
        referenciaObjetivo.EnObjetivoDestruido += MostrarMenuGameOver;
        referenciaSpawner.EnOleadaIniciada += ActualizarOla;
        referenciaSpawner.EnOleadaTerminada += MostrarMensajeUltimoEnemigo;
        referenciaSpawner.EnOleadaGandada += MostrarMenuOlaGanada;
        referenciaAdminJuego.EnRecursosModificados += ActualizarRecursos;
    }



    private void OnDisable()
    {
        referenciaObjetivo.EnObjetivoDestruido -= MostrarMenuGameOver;
        referenciaSpawner.EnOleadaIniciada -= ActualizarOla;
        referenciaSpawner.EnOleadaTerminada -= MostrarMensajeUltimoEnemigo;
        referenciaSpawner.EnOleadaGandada -= MostrarMenuOlaGanada;
        referenciaAdminJuego.EnRecursosModificados -= ActualizarRecursos;
    }

    public void ActualizarRecursos()
    {
        textoRecursos.text = $"Recursos: {referenciaAdminJuego.recursos}";
    }

    public void MostrarMensajeUltimoEnemigo()
    {
        MensjaeFinOla.SetActive(true);
        Invoke("OcultarMensajeUltimoEnemigo", 3);
    }

    public void OcultarMensajeUltimoEnemigo()
    {
        MensjaeFinOla.SetActive(false);
    }

    public void MostrarMenuOlaGanada()
    {
        textoEnemigos.text = $"ENEMIGOS: \t {referenciaAdminJuego.enemigosBaseDerrotados}";
        textoJefes.text = $"JEFES \t\t {referenciaAdminJuego.enemigosJefeDerrotados}";
        MenuOlaGanada.SetActive(true);
    }
    public void ocultarMenuJuegoGanado()
    {
        MenuOlaGanada.SetActive(false);
    }
    public void ActualizarOla()
    {
        textoOleada.text = $"Ola: {referenciaSpawner.oleada}";
        ocultarMenuJuegoGanado();
    }



    public void MostrarMenuFinOleada()
    {

    }

    public void OcultarMenuFinOleada()
    {

    }

    public void MostrarMenuGameOver()
    {
        GameOverMenu.SetActive(true);
    }

    public void OcultarMenuGameOver()
    {
        GameOverMenu.SetActive(false);
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

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
