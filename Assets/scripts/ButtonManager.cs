using UnityEngine;
using TMPro;
using System.Collections;

public class ButtonManager : MonoBehaviour
{
    public TextMeshProUGUI TextBox;
    public TextMeshProUGUI timerText;

    private int collectedPapers = 0;
    public GameObject RealAxe;

    public delegate void ButtonManagerFinished(); // Define a delegate
    public event ButtonManagerFinished OnButtonManagerFinished; // Declare an event

    void Start()
    {
       
    }

    public void PaperCollected()
    {
        collectedPapers++;

        if (collectedPapers >= 4)
        {
            if (RealAxe != null)
            {
                RealAxe.SetActive(true);
                StartCoroutine(HideRealAxe());
            }
            else
            {
                Debug.LogError("RealAxe reference is not set in ButtonManager script!");
            }

            // Notify subscribers (like Level2 script) that ButtonManager has finished its operation
            if (OnButtonManagerFinished != null)
            {
                OnButtonManagerFinished();
            }
        }
    }

    IEnumerator HideRealAxe()
    {
        yield return new WaitForSeconds(2.5f);
        if (RealAxe != null)
        {
            RealAxe.SetActive(false);
        }
    }
}
