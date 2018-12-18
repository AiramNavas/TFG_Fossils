using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelegateHandler : MonoBehaviour {

    public static DelegateHandler delegateHandler; // Handler de eventos.

    public delegate void DentroDelAgua();
    public event DentroDelAgua dentroDelAguaD;

    public delegate void FueraDelAgua();
    public event FueraDelAgua fueraDelAguaD;

    public delegate bool DentroDelAreaDelLibro();
    public event DentroDelAreaDelLibro dentroDelAreaDelLibro;

    public delegate bool FosilBienClasificadoYDeMision(string fosil);
    public event FosilBienClasificadoYDeMision fosilBienClasificadoYDeMision;

    public delegate void AudioAbrirLibro();
    public event AudioAbrirLibro audioAbrirLibro;

    public delegate void AudioCerrarLibro();
    public event AudioCerrarLibro audioCerrarLibro;

    public delegate void AudioExcavar();
    public event AudioExcavar audioExcavar;

    public delegate void AudioPicar();
    public event AudioPicar audioPicar;

    public delegate void AudioMisionCompletada();
    public event AudioMisionCompletada audioMisionCompletada;

    public delegate void CancelarAudio();
    public event CancelarAudio cancelarAudio;

    public delegate void CambiarAudioMar();
    public event CambiarAudioMar cambiarAudioMar;

    public delegate void CambiarAudioBajoElMar();
    public event CambiarAudioBajoElMar cambiarAudioBajoElMar;

    public delegate void JugadorEntraAlAgua();
    public event JugadorEntraAlAgua jugadorEntraAlAgua;

    public delegate void JugadorSaleDelAgua();
    public event JugadorSaleDelAgua jugadorSaleDelAgua;

    public delegate void MutearPiesBajoAgua(bool m);
    public event MutearPiesBajoAgua mutearPiesBajoAgua;

    public delegate void CambiarAudiosGuardados(AudioClip p1, AudioClip p2);
    public event CambiarAudiosGuardados cambiarAudiosGuardados;

    public delegate void ZapatillasConseguidas();
    public event ZapatillasConseguidas zapatillasConseguidas;


    /*
     * Inicializa el handler
     */
    public void Awake()
    {

        if (delegateHandler == null)
        {

            delegateHandler = this;
            DontDestroyOnLoad(this);

        }
        else if (delegateHandler != this)
        {

            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void CallDentroDelAgua() {
        dentroDelAguaD();
    }

    public void CallFueraDelAgua() {
        fueraDelAguaD();
    }

    public bool CallDentroDelAreaDelLibro() {
        return dentroDelAreaDelLibro();
    }

    public bool CallFosilBienClasificadoYDeMision(string fosil) {
        return fosilBienClasificadoYDeMision(fosil);
    }

    public void CallAudioAbrirLibro() {
        audioAbrirLibro();
    }

    public void CallAudioCerrarLibro()
    {
        audioCerrarLibro();
    }

    public void CallAudioExcavar()
    {
        audioExcavar();
    }

    public void CallAudioPicar()
    {
        audioPicar();
    }

    public void CallAudioMisionCompletada() {
        audioMisionCompletada();
    }

    public void CallCancelarAudio() {
        cancelarAudio();
    }

    public void CallCambiarAudioMar()
    {
        cambiarAudioMar();
    }

    public void CallCambiarAudioBajoElMar()
    {
        cambiarAudioBajoElMar();
    }

    public void CallJugadorEntraAlAgua()
    {
        jugadorEntraAlAgua();
    }

    public void CallJugadorSaleDelAgua()
    {
        jugadorSaleDelAgua();
    }

    public void CallMutearPiesBajoAgua(bool m)
    {
        mutearPiesBajoAgua(m);
    }

    public void CallCambiarAudiosGuardados(AudioClip p1, AudioClip p2)
    {
        cambiarAudiosGuardados(p1, p2);
    }

    public void CallZapatillasConseguidas()
    {
        zapatillasConseguidas();
    }
}
