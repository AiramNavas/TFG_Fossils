using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectEdad : MonoBehaviour {
    
    private Image cuatSelected;
    private Image neoSelected;
    
    private bool edadTriger = false;
    private string edad;

    // Use this for initialization
    void Start () {
        cuatSelected = GameObject.Find("CuatSelected").GetComponent<Image>();
        neoSelected = GameObject.Find("NeoSelected").GetComponent<Image>();
        edad = StaticClass.Edad;
        BottonPressed();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("joystick button 0") || Input.GetKeyDown("1"))
        {
            BottonPressed();
        }
    }

    public void Cuaternario()
    {
        edad = "Cuaternario";
    }

    public void Neogeno()
    {
        edad = "Neogeno";
    }

    public void TriggerON() {
        edadTriger = true;
    }

    public void TriggerOFF()
    {
        edadTriger = false;
    }

    public void BottonPressed() {
        if (edad == "Cuaternario")
        {
            cuatSelected.gameObject.SetActive(true);
            neoSelected.gameObject.SetActive(false);
        }
        else
        {
            cuatSelected.gameObject.SetActive(false);
            neoSelected.gameObject.SetActive(true);
        }
        StaticClass.Edad = edad;
    }
}
