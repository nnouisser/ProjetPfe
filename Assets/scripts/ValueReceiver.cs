using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ValueReceiver : MonoBehaviour
{
    private float receivedXValue;
    private float receivedYValue;
    private float receivedZValue;
    private float receivedHealthValue;
    private float receivedEnergyValue;
    public Slider health;
    public Slider energy;
    public GameObject playerCapsule;

    void Start()
    {
        // Load the values from PlayerPrefs
        receivedXValue = PlayerPrefs.GetFloat("PlayerPosition_X");
        receivedYValue = PlayerPrefs.GetFloat("PlayerPosition_Y");
        receivedZValue = PlayerPrefs.GetFloat("PlayerPosition_Z");
        receivedHealthValue = PlayerPrefs.GetFloat("Health");
        receivedEnergyValue = PlayerPrefs.GetFloat("Energy");

        // Set the position of the player capsule
        SetPosition(receivedXValue, receivedYValue, receivedZValue);

        // Set the health and energy values
        SetHealthValue(receivedHealthValue);
        SetEnergyValue(receivedEnergyValue);

        // Debug the imported values
        Debug.Log("Imported X Value: " + receivedXValue);
        Debug.Log("Imported Y Value: " + receivedYValue);
        Debug.Log("Imported Z Value: " + receivedZValue);
        Debug.Log("Imported Health Value: " + receivedHealthValue);
        Debug.Log("Imported Energy Value: " + receivedEnergyValue);
    }

    public void SetPosition(float x, float y, float z)
    {
        if (playerCapsule != null)
        {
            playerCapsule.transform.position = new Vector3(x, y, z);
            Debug.Log("Player position set successfully.");
        }
        else
        {
            Debug.LogError("Player capsule GameObject is not assigned.");
        }
    }

    public void SetHealthValue(float healthValue)
    {
        health.value = healthValue; // Set the health slider value
        Debug.Log("Health value set: " + healthValue);
    }


    public void SetEnergyValue(float energyValue)
    {
        if (energyValue == 0)
        {
            energyValue = 100; // Set energyValue to 100 if it's 0
        }
        energy.value = energyValue; // Set the energy slider value
    }
}
