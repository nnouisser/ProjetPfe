using UnityEngine;
using TMPro;
using UnityStandardAssets.Characters.FirstPerson;
using System.Collections;

public class lastpieces : MonoBehaviour
{
    public GameObject ThePlayer;
    public TextMeshProUGUI TextBox; // Use TextMeshProUGUI for TextMeshPro

    private bool isCoroutineRunning = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Trigger entered");
            if (!isCoroutineRunning)
            {
                StartCoroutine(DisplayText());
            }
        }
    }

    IEnumerator DisplayText()
    {
        isCoroutineRunning = true;

        TextBox.text = "Looks like two pieces of paper in this floor.";
        yield return new WaitForSeconds(2.5f);
        TextBox.text = "";

        isCoroutineRunning = false;
    }
}
