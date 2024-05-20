using System;
using UnityEngine;
using UnityEngine.UI; // Ajout de cette ligne pour utiliser UI.Image
using UnityStandardAssets.CrossPlatformInput;

[RequireComponent(typeof(Image))] // Mise à jour ici
public class ForcedReset : MonoBehaviour
{
    private void Update()
    {
        // if we have forced a reset ...
        if (CrossPlatformInputManager.GetButtonDown("ResetObject"))
        {
            //... reload the scene
            Application.LoadLevelAsync(Application.loadedLevelName);
        }
    }
}
