using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class SoundEvents : MonoBehaviour {

    private FirstPersonController FPC;
    private AudioSource aud;

    private AudioClip guardarPaso1;
    private AudioClip guardarPaso2;

    // Use this for initialization
    void Start () {
        aud = GetComponent<AudioSource>();
        FPC = GameObject.Find("Player2").GetComponent<FirstPersonController>();
        DelegateHandler.delegateHandler.audioAbrirLibro += AbrirLibro;
        DelegateHandler.delegateHandler.audioCerrarLibro += CerrarLibro;
        DelegateHandler.delegateHandler.audioExcavar += Excavar;
        DelegateHandler.delegateHandler.audioPicar += Picar;
        DelegateHandler.delegateHandler.cancelarAudio += CancelarAudio;
        DelegateHandler.delegateHandler.audioMisionCompletada += MisionCompletada;
        DelegateHandler.delegateHandler.mutearPiesBajoAgua += CambiarSonidoPies;
        DelegateHandler.delegateHandler.cambiarAudiosGuardados += CambiarSonidosGuardados;
    }

    void AbrirLibro() {
        aud.PlayOneShot(StaticClass.AudiosDelJuego["AbrirLibro"]);
    }

    void CerrarLibro()
    {
        aud.PlayOneShot(StaticClass.AudiosDelJuego["CerrarLibro"]);
    }

    void Excavar()
    {
        aud.PlayOneShot(StaticClass.AudiosDelJuego["Excavar"]);
    }

    void Picar()
    {
        aud.PlayOneShot(StaticClass.AudiosDelJuego["Picar"]);
    }

    void CancelarAudio() {
        if(aud.isPlaying)
            aud.Stop();
    }

    void MisionCompletada() {
        aud.PlayOneShot(StaticClass.AudiosDelJuego["MisionCompletada"]);
    }

    void CambiarSonidoPies(bool m) {
        if (!m)
        {
            guardarPaso1 = FPC.m_FootstepSounds[0];
            guardarPaso2 = FPC.m_FootstepSounds[1];
            FPC.m_FootstepSounds[1] = null;
            FPC.m_FootstepSounds[0] = null;
        }
        else {
            FPC.m_FootstepSounds[1] = guardarPaso1;
            FPC.m_FootstepSounds[0] = guardarPaso2;
        }
    }

    void CambiarSonidosGuardados(AudioClip p1, AudioClip p2) {
        guardarPaso1 = p1;
        guardarPaso2 = p2;
    }

    private void OnDisable()
    {
        DelegateHandler.delegateHandler.audioAbrirLibro -= AbrirLibro;
        DelegateHandler.delegateHandler.audioCerrarLibro -= CerrarLibro;
        DelegateHandler.delegateHandler.audioExcavar -= Excavar;
        DelegateHandler.delegateHandler.audioPicar -= Picar;
        DelegateHandler.delegateHandler.cancelarAudio -= CancelarAudio;
        DelegateHandler.delegateHandler.audioMisionCompletada -= MisionCompletada;
        DelegateHandler.delegateHandler.mutearPiesBajoAgua -= CambiarSonidoPies;
        DelegateHandler.delegateHandler.cambiarAudiosGuardados -= CambiarSonidosGuardados;
    }
}
