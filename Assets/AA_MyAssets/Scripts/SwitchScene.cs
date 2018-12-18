using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SwitchScene : MonoBehaviour {

    public int playa;
    public Image cooldownImage;
    public GameObject cooldownCanvas;

    private float time = 0f;
    private bool timeStarted = false;

    GameObject pointer;


	// Use this for initialization
	void Start () {
        pointer = GameObject.Find("GvrReticlePointer");
    }
	
	// Update is called once per frame
	void Update () {
        if (timeStarted)
        {
            time += Time.deltaTime;
            if (cooldownCanvas.activeSelf)
                cooldownImage.fillAmount += 1.0f / 2 * Time.deltaTime;
        }

        if (time > 2)
        {
            StaticClass.Escena = playa;
            SceneManager.LoadScene(playa);
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            cooldownCanvas.SetActive(true);
            timeStarted = true;
            pointer.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            timeStarted = false;
            time = 0f;
            cooldownImage.fillAmount = 0;
            cooldownCanvas.SetActive(false);
            pointer.SetActive(true);
        }
    }
}
