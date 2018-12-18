using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

public class ChangeWaterCam : MonoBehaviour {

    public PostProcessingProfile normal, fx;
    private PostProcessingBehaviour camImageFx;

    public GameObject gafasDeBuzo;

    // Use this for initialization
    void Start () {
        camImageFx = FindObjectOfType<PostProcessingBehaviour>();
    }

    private void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) {
            if (!StaticClass.TieneTrajeDeBuzo)
            {
                camImageFx.profile = fx;
            }
            else {
                gafasDeBuzo.SetActive(true);
            }
            DelegateHandler.delegateHandler.CallCambiarAudioBajoElMar();
            DelegateHandler.delegateHandler.CallCambiarAudioMar();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            camImageFx.profile = normal;
            gafasDeBuzo.SetActive(false);
            DelegateHandler.delegateHandler.CallCambiarAudioBajoElMar();
            DelegateHandler.delegateHandler.CallCambiarAudioMar();
        }
    }
}
