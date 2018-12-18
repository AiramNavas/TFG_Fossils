using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Selector : MonoBehaviour
{

    public GameObject direccion;
    private RaycastHit hit;
    public float distance = 100;
    public GameObject botones;
    public GameObject panel;
    public GameObject pointer;
    public Camera camara;
    public Text titulo;
    public Text texto;
    public GameObject Glosario;

    // Use this for initialization
    void Start()
    {
        pointer.transform.GetComponent<Renderer>().material.color = Color.blue;

    }

    void setPanel(string nombreFosil)
    {
        TextAsset text = (TextAsset)Resources.Load(nombreFosil, typeof(TextAsset));

        string[] lineas = text.text.Split("\n"[0]);
        titulo.text = lineas[0];
        texto.text = "";
        for (int i = 1; i < lineas.Length; i++)
        {
            texto.text += ("\n" + lineas[i]);
        }

        panel.transform.position = new Vector3(hit.transform.position.x, transform.position.y + 10, hit.transform.position.z);
        panel.transform.LookAt(camara.transform);
        Glosario.SetActive(false);
        panel.SetActive(true);

    }
    // Update is called once per frame
    void Update()
    {

        pointer.transform.GetComponent<Renderer>().material.color = Color.blue;
        botones.SetActive(false);

        if (Physics.Raycast(camara.transform.position, (direccion.transform.position - camara.transform.position), out hit, distance))
        {
            if (hit.transform.tag == "Fosiles")
            {
                pointer.transform.GetComponent<Renderer>().material.color = Color.red;
                botones.SetActive(true);
                if (Input.GetKeyDown("joystick button 0"))
                {
                    setPanel(hit.transform.name);
                }
            }

        }

        if (Input.GetKeyDown("joystick button 1"))
        {
            panel.SetActive(false);
            Glosario.SetActive(false);
        }

        if (Input.GetKeyDown("joystick button 2"))
        {
            Debug.Log("X");
            panel.SetActive(false);

            Glosario.transform.position = new Vector3(direccion.transform.position.x, direccion.transform.position.y + 5, direccion.transform.position.z);

            Glosario.transform.LookAt(camara.transform);
            Glosario.SetActive(true);
        }
    }




}
