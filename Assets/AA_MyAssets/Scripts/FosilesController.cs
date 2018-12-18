using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FosilesController : MonoBehaviour {

    public Image cooldownImage;
    public GameObject cooldownCanvas;

    MeshRenderer pointer;

    private float time = 0f;
    private bool startTime = false;
    private GameObject fosil;

    bool audioON = false;
    

	// Use this for initialization
	void Start () {

        pointer = GameObject.Find("GvrReticlePointer").GetComponent<MeshRenderer>();

        fosil = null;

        if (StaticClass.Escena != 0) {
            for (int i = 0; i < transform.childCount; i++)
            {
                if (StaticClass.FosilEnMano != "" && StaticClass.FosilEnMano == transform.GetChild(i).name)
                {
                    GameObject.Find(StaticClass.FosilEnMano).transform.position = GameObject.Find("Mano").transform.position;
                    GameObject.Find(StaticClass.FosilEnMano).transform.parent = GameObject.Find("Mano").transform;
                    GameObject.Find(StaticClass.FosilEnMano).transform.GetChild(0).GetComponent<Collider>().enabled = false;
                }
                else if (StaticClass.FosilesClasificados.Contains(transform.GetChild(i).name))
                {
                    GameObject.Find(transform.GetChild(i).name).transform.Translate(new Vector3(0, -1000, 0));
                }
                else if (StaticClass.Edad.CompareTo("Cuaternario") == 0)
                {
                    if (StaticClass.Fosiles[transform.GetChild(i).name].ToString().CompareTo("Neogeno") == 0)
                        GameObject.Find(transform.GetChild(i).name).transform.Translate(new Vector3(0, -1000, 0));
                }
                else if (StaticClass.Edad.CompareTo("Neogeno") == 0)
                {
                    if (StaticClass.Fosiles[transform.GetChild(i).name].ToString().CompareTo("Cuaternario") == 0)
                        GameObject.Find(transform.GetChild(i).name).transform.Translate(new Vector3(0, -1000, 0));
                }

            }
        }
        else if (StaticClass.Escena == 0) {
            for (int i = 0; i < transform.childCount; i++)
            {
                if (StaticClass.FosilEnMano != "" && StaticClass.FosilEnMano == transform.GetChild(i).name)
                {
                    GameObject.Find(StaticClass.FosilEnMano).transform.position = GameObject.Find("Mano").transform.position;
                    GameObject.Find(StaticClass.FosilEnMano).transform.parent = GameObject.Find("Mano").transform;
                }
                else if (StaticClass.FosilEnCaja.ContainsKey(transform.GetChild(i).name))
                {
                    transform.GetChild(i).transform.position =
                        GameObject.Find(StaticClass.Fosiles[transform.GetChild(i).name])
                                  .transform.GetChild(StaticClass.FosilEnCaja[transform.GetChild(i).name])
                                  .transform.position;
                }
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (startTime) {
            time += Time.deltaTime;
            if (cooldownCanvas.activeSelf)
                cooldownImage.fillAmount += 1.0f / 2 * Time.deltaTime;
        }

        if (Input.GetKey("joystick button 0") && fosil != null || Input.GetKey("1") && fosil != null)
        {
            if (StaticClass.FosilEnMano == "")
            {
                if (!startTime)
                {
                    cooldownCanvas.SetActive(true);
                    pointer.enabled = false;
                }

                startTime = true;

                if (!audioON)
                {
                    if(StaticClass.Zonacion[fosil.name].CompareTo("Arenosa") == 0)
                        DelegateHandler.delegateHandler.CallAudioExcavar();
                    else
                        DelegateHandler.delegateHandler.CallAudioPicar();
                    audioON = true;
                }

                if (time > 2)
                {
                    fosil.transform.position = GameObject.Find("Mano").transform.position;
                    fosil.transform.parent = GameObject.Find("Mano").transform;
                    fosil.transform.GetChild(0).GetComponent<Collider>().enabled = false;
                    StaticClass.FosilEnMano = fosil.name;
                    audioON = false;
                }
            }
        }
        else if (startTime)
        {
            time = 0f;
            cooldownImage.fillAmount = 0f;
            pointer.enabled = true;
            cooldownCanvas.SetActive(false);
            startTime = false;

            DelegateHandler.delegateHandler.CallCancelarAudio();
            audioON = false;
        }
    }

    public void timeToDestroyON(GameObject f) {
        fosil = f;
        cooldownCanvas.SetActive(true);
    }

    public void timeToDestroyOFF()
    {
        startTime = false;
        time = 0f;
        fosil = null;
        cooldownImage.fillAmount = 0f;
        cooldownCanvas.SetActive(false);
        pointer.enabled = true;
        DelegateHandler.delegateHandler.CallCancelarAudio();
        audioON = false;
    }
}
