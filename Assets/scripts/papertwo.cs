using UnityEngine;
using TMPro;
using UnityStandardAssets.Characters.FirstPerson;
using System.Collections;
public class papertwo : MonoBehaviour
{
    public GameObject ThePlayer;
    public TextMeshProUGUI TextBox; // Use TextMeshProUGUI for TextMeshPro
    public GameObject pickitButton;
    public GameObject fakepicture;
    public GameObject RealAxe;
    public ButtonManager gameManager; // Reference to GameManager



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
            pickitButton.SetActive(true);

        }
        
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Trigger exited");
            // Hide the "pickit" button
            pickitButton.SetActive(false);
        }
    }
    IEnumerator DisplayText()
    {
        isCoroutineRunning = true;

        TextBox.text = "Looks like a piece of paper on that board.";
        yield return new WaitForSeconds(2.5f);
        TextBox.text = "";

        isCoroutineRunning = false;
    }
    public void pickit()
    {
        fakepicture.SetActive(false);
        RealAxe.SetActive(true);
        pickitButton.SetActive(false);
        TextBox.text = "";
        gameManager.PaperCollected(); // Notify GameManager



    }
}
