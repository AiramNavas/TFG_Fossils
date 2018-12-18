using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

#pragma warning disable CS0618 // El tipo o el miembro están obsoletos
[RequireComponent(typeof (GUITexture))]
#pragma warning restore CS0618 // El tipo o el miembro están obsoletos
public class ForcedReset : MonoBehaviour
{
    private void Update()
    {
        // if we have forced a reset ...
        if (CrossPlatformInputManager.GetButtonDown("ResetObject"))
        {
            //... reload the scene
            SceneManager.LoadScene(SceneManager.GetSceneAt(0).name);
        }
    }
}
