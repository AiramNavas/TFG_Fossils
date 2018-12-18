using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookArea : MonoBehaviour {

    private bool playerInArea = false;

	// Use this for initialization
	void Start () {
        DelegateHandler.delegateHandler.dentroDelAreaDelLibro += checkIfPlayerIn;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public bool checkIfPlayerIn() {
        return playerInArea;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) {
            playerInArea = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInArea = false;
        }
    }

    private void OnDisable()
    {
        DelegateHandler.delegateHandler.dentroDelAreaDelLibro -= checkIfPlayerIn;
    }
}
