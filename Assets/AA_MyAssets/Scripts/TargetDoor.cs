using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetDoor : MonoBehaviour {

    public Renderer rend;

    // Use this for initialization
    void Start () {
        rend = GetComponent<Renderer>();
    }

	// Update is called once per frame
	void Update () {
		
	}

    public void OutlineOn()
    {
        float width = 1.03f;
        rend.material.SetFloat("_OutlineWidth", width);
    }

    public void OutlineOff()
    {
        float width = 1.0f;
        rend.material.SetFloat("_OutlineWidth", width);
    }
}
