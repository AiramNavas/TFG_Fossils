using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingSelector : MonoBehaviour {
    public GameObject direccion;
    private RaycastHit hit;
    public float distance = 100;
    public GameObject pointer;
    public Camera camara;

    // Use this for initialization
    void Start()
    {
        //SceneManager.LoadScene("Playa1", LoadSceneMode.Additive);
    }

    // Update is called once per frame
    void Update()
    {

        pointer.transform.GetComponent<Renderer>().material.color = Color.blue;



        if (Physics.Raycast(camara.transform.position, (direccion.transform.position - camara.transform.position), out hit, distance))
        {
            if (hit.transform.tag == "Avanzar")
            {
                pointer.transform.GetComponent<Renderer>().material.color = Color.red;

                if (Input.GetKeyDown("joystick button 0"))
                {
                    SceneManager.LoadScene("Playa1");

                }
            }

        }



    }
}
