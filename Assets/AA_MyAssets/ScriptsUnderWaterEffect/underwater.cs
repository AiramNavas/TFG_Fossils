using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class underwater : MonoBehaviour
{

    public GameObject alturaActual;
    public GameObject waterlevel;

    private bool isUnderWater = true;
    private Color normalColor;
    public Color underWaterColor;
    public Camera camara;
    public Camera underWaterCamera;
    public GameObject gvrN;
    public GameObject gvrUW;
    public GameObject drN;
    public GameObject drUW;
    public GameObject cnv1;
    public GameObject cnv2;

    public UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController fps;
    public Selector select;
    void Start()
    {

        normalColor = new Color(0.5f, 0.5f, 0.5f, 0.5f);
    }

    void Update()
    {



        if ((alturaActual.transform.position.y < waterlevel.transform.position.y - 9) && !isUnderWater)
        {
            SetUnderWater();
            isUnderWater = true;

        }
        else if((alturaActual.transform.position.y > waterlevel.transform.position.y - 9) && isUnderWater)
        {
            SetNormal();
            isUnderWater = false;
        }

    }

    void SetNormal()
    {

        underWaterCamera.GetComponent<Camera>().enabled = false;

        camara.GetComponent<Camera>().enabled = true;


        camara.transform.position = underWaterCamera.transform.position;
        camara.transform.rotation = underWaterCamera.transform.rotation;

        gvrN.SetActive(true);
        gvrUW.SetActive(false);

        drN.SetActive(true);
        drUW.SetActive(false);

        cnv1.SetActive(true);
        cnv2.SetActive(false);


        select.direccion = drN;
        select.pointer = gvrN;
        select.botones = cnv1;

        fps.cam = camara;

        RenderSettings.fogColor = normalColor;
        RenderSettings.fogDensity = 0.002f;

    }
    void SetUnderWater()
    {
        camara.GetComponent<Camera>().enabled = false;

        underWaterCamera.GetComponent<Camera>().enabled = true;

        underWaterCamera.transform.position = camara.transform.position;
        underWaterCamera.transform.rotation = camara.transform.rotation;

        drN.SetActive(false);
        drUW.SetActive(true);


        gvrN.SetActive(false);
        gvrUW.SetActive(true);

        cnv2.SetActive(true);
        cnv1.SetActive(false);


        select.direccion = drUW;
        select.pointer = gvrUW;
        select.botones = cnv2;

        fps.cam = underWaterCamera;

       

        //camara.clearFlags = CameraClearFlags.SolidColor;
        RenderSettings.fogColor = underWaterColor;
        RenderSettings.fogDensity = 0.02f;
    }
}
