using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoxesToClasificateController : MonoBehaviour {

    public Image cooldownImage;
    public GameObject cooldownCanvas;
    MeshRenderer pointer;

    string actualBox;
    float time = 0f;
    bool startTime = false;

	// Use this for initialization
	void Start () {
        actualBox = "";
        pointer = GameObject.Find("GvrReticlePointer").GetComponent<MeshRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
        if (startTime)
        {
            time += Time.deltaTime;
            if (cooldownCanvas.activeSelf)
                cooldownImage.fillAmount += 1.0f / 2 * Time.deltaTime;
        }

        if (actualBox != "" && Input.GetKey("joystick button 0") && StaticClass.FosilEnMano != "" || actualBox != "" && Input.GetKey("1") && StaticClass.FosilEnMano != "")
        {
            if (!startTime) {
                cooldownCanvas.SetActive(true);
                pointer.enabled = false;
            }

            startTime = true;

            if (time > 2)
            {
                if (StaticClass.Fosiles[GameObject.Find("Mano").transform.GetChild(0).name] == actualBox
                    && DelegateHandler.delegateHandler.CallFosilBienClasificadoYDeMision(GameObject.Find("Mano").transform.GetChild(0).name))
                {
                    StaticClass.FosilEnCaja.Add(GameObject.Find("Mano").transform.GetChild(0).name, StaticClass.PosicionCajaDisponible[actualBox]);
                    StaticClass.FosilesClasificados.Add(GameObject.Find("Mano").transform.GetChild(0).name);
                    GameObject.Find("Mano").transform.GetChild(0).transform.position = GameObject.Find(actualBox).transform.GetChild(StaticClass.PosicionCajaDisponible[actualBox]).transform.position;
                    GameObject.Find("Mano").transform.GetChild(0).transform.parent = GameObject.Find("Fosiles").transform;
                    StaticClass.PosicionCajaDisponible[actualBox] += 1;
                    StaticClass.FosilEnMano = "";
                }
                else
                {
                    GameObject.Find("Mano").transform.GetChild(0).transform.Translate(new Vector3(0, -1000, 0));
                    GameObject.Find(StaticClass.FosilEnMano).transform.parent = GameObject.Find("Fosiles").transform;
                    StaticClass.FosilEnMano = "";
                }
            }
        }
        else if(startTime)
        {
            time = 0f;
            cooldownImage.fillAmount = 0f;
            cooldownCanvas.SetActive(false);
            pointer.enabled = true;
            startTime = false;
        }
    }

    public void actualBoxON(GameObject b) {
        actualBox = b.name;
        cooldownCanvas.SetActive(true);
    }

    public void actualBoxOFF()
    {
        time = 0f;
        actualBox = "";
        startTime = false;
        cooldownCanvas.SetActive(false);
        cooldownImage.fillAmount = 0f;
        pointer.enabled = true;
    }
}
