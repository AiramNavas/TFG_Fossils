using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaSoundController : MonoBehaviour {

    new AudioSource audio;

	// Use this for initialization
	void Start () {
        DelegateHandler.delegateHandler.cambiarAudioMar += CambiarSonidoDelMar;

        audio = GetComponent<AudioSource>();
        audio.Play();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void CambiarSonidoDelMar() {
        if (audio.isPlaying)
            audio.Stop();
        else
            audio.Play();
    }

    private void OnDisable()
    {
        DelegateHandler.delegateHandler.cambiarAudioMar -= CambiarSonidoDelMar;
    }
}
