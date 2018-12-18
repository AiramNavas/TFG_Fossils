using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class ChangeFootStepSoundController : MonoBehaviour {

    FirstPersonController FPC;

	// Use this for initialization
	void Start () {
        FPC = GameObject.Find("Player2").GetComponent<FirstPersonController>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (!StaticClass.JugadorEnElAgua)
        {
            FPC.m_FootstepSounds[0] = StaticClass.AudiosDelJuego["PisarPiedra1"];
            FPC.m_FootstepSounds[1] = StaticClass.AudiosDelJuego["PisarPiedra2"];
        }
        else {
            DelegateHandler.delegateHandler.CallCambiarAudiosGuardados(StaticClass.AudiosDelJuego["PisarPiedra1"], StaticClass.AudiosDelJuego["PisarPiedra2"]);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!StaticClass.JugadorEnElAgua)
        {
            FPC.m_FootstepSounds[0] = StaticClass.AudiosDelJuego["PisarArena1"];
            FPC.m_FootstepSounds[1] = StaticClass.AudiosDelJuego["PisarArena2"];
        }
        else {
            DelegateHandler.delegateHandler.CallCambiarAudiosGuardados(StaticClass.AudiosDelJuego["PisarArena1"], StaticClass.AudiosDelJuego["PisarArena2"]);
        }
    }
}
