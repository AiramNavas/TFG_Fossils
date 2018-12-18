using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Pointer : MonoBehaviour {

	public GameObject direccion;
	public GameObject punteroHelper1;
	public GameObject punteroHelper2;

	private RaycastHit hit;
	public float distance = 1000;
	public GameObject botones;
	public GameObject panel;
	public Text titulo;
	public Text texto;
	private bool showingPanel=false;
	public LineRenderer linea;
	public Material rojo;
	public Material azul;
	// Use this for initialization
	void Start () {
		linea.positionCount = 2;
	}

	void setPanel(string nombreFosil){

		//TextAsset level = Resources.Load("Resources/Textos/Persististrombus_latus.txt") as TextAsset; 

		Debug.Log (nombreFosil);
		TextAsset text = (TextAsset) Resources.Load( nombreFosil, typeof( TextAsset ) );


		Debug.Log (text.text);
		string [] lineas = text.text.Split("\n"[0]);
		titulo.text = lineas[0];
		texto.text = lineas[1];
		showingPanel = true;
	}
	// Update is called once per frame
	void Update () {
		linea.SetPosition (0, punteroHelper1.transform.position);
		linea.SetPosition (1, punteroHelper2.transform.position);

		if (Physics.Raycast (transform.position, (direccion.transform.position - transform.position), out hit, distance)) {
			if (hit.transform.tag == "Fosiles" && !showingPanel) {
				linea.material = rojo;
				botones.SetActive(true);
				if (Input.GetKeyDown("joystick button 0")) {
					setPanel (hit.transform.name);
					panel.SetActive(true);       
				}

			} else {
				botones.SetActive(false);
				linea.material = azul;

			}
		}

		if(Input.GetKeyDown("joystick button 1")){
			showingPanel = false;
			panel.SetActive(false);
		}
	}


}
