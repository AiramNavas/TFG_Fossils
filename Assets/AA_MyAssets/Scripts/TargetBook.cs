using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBook : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Move()
    {
        transform.Translate(new Vector3(0, 0, 1));
    }
}
