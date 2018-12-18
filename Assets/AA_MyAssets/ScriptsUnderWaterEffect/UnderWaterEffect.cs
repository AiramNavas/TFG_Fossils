using UnityEngine;
using System.Collections;

public class UnderWaterEffect : MonoBehaviour {

	//This script enables underwater effects. Attach to main camera.

	//Define variable
    public Color underWaterColor;

    private new AudioSource audio;

    //The scene's default fog settings
    private bool defaultFog;
	private Color defaultFogColor;
	private float defaultFogDensity;
	private Material defaultSkybox;
	//private Material noSkybox;
    private float defaultFar;

	void Start () {
        DelegateHandler.delegateHandler.dentroDelAguaD += dentroDelAguaM;
        DelegateHandler.delegateHandler.fueraDelAguaD += fueraDelAguaM;
        DelegateHandler.delegateHandler.cambiarAudioBajoElMar += CambiarSonidoBajoElAgua;
        //Set the background color
        //Camera.main.backgroundColor = new Color(0.22f, 0.64f, 0.77f, 0.6f);
        defaultFog = RenderSettings.fog;
        defaultFogColor = RenderSettings.fogColor;
        defaultFogDensity = RenderSettings.fogDensity;
        defaultSkybox = RenderSettings.skybox;

        Camera proj = GetComponent<Camera>();
        defaultFar = proj.farClipPlane;

        audio = GetComponent<AudioSource>();
        audio.Stop();
    }

    public void dentroDelAguaM() {
        RenderSettings.fog = true;
        RenderSettings.fogColor = underWaterColor;
        RenderSettings.fogDensity = 0.02f;
        RenderSettings.skybox = null;
        Camera proj = GetComponent<Camera>();
        proj.farClipPlane = 200f;
    }

    public void fueraDelAguaM() {
        RenderSettings.fog = defaultFog;
        RenderSettings.fogColor = defaultFogColor;
        RenderSettings.fogDensity = defaultFogDensity;
        RenderSettings.skybox = defaultSkybox;
        Camera proj = GetComponent<Camera>();
        proj.farClipPlane = defaultFar;
    }

	void Update () {
		
	}

    void CambiarSonidoBajoElAgua() {
        if (audio.isPlaying)
            audio.Stop();
        else
            audio.Play();
    }

    private void OnDisable()
    {
        DelegateHandler.delegateHandler.dentroDelAguaD -= dentroDelAguaM;
        DelegateHandler.delegateHandler.fueraDelAguaD -= fueraDelAguaM;
        DelegateHandler.delegateHandler.cambiarAudioBajoElMar -= CambiarSonidoBajoElAgua;
    }
}