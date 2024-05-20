using UnityEngine;
using System.Collections;

public class DoorLock : MonoBehaviour
{
    public GameObject Open;
    private Animator Anim;
    public AudioSource CreakSound;
    public GameObject ActionDisplay;
    public GameObject ActionText;
    public GameObject WalkZombie;

    private bool doorInteractionInProgress = false;

    void Start()
    {
        Anim = GameObject.Find("DoorHinge").GetComponent<Animator>();
        doorInteractionInProgress = false; // Add this line
    }

    void Update()
    {
        // Remove the touch input check, as the button click will be handled separately
    }

    // Remove the CheckTouchPosition() function

    // Rest of your script remains the same

    // Add a new public function to be called by the button click event
    public void ButtonClick()
    {
        if (!doorInteractionInProgress)
        {
            ToggleDoor();
        }
    }

    void ToggleDoor()
    {
        doorInteractionInProgress = true;

        if (Anim.GetBool("Open"))
        {

            ActionDisplay.SetActive(false);
            ActionText.SetActive(false);
            Open.gameObject.SetActive(false);

            Anim.SetBool("Open", false);
            CreakSound.Play();
        }
        else
        {
            ActionDisplay.SetActive(true);
            ActionText.SetActive(true);
            Open.gameObject.SetActive(true);

            Anim.SetBool("Open", true);
            CreakSound.Play();
            WalkZombie.SetActive(true);

        }

        StartCoroutine(ResetDoorInteraction());
    }

    IEnumerator ResetDoorInteraction()
    {
        yield return new WaitForSeconds(1f);
        doorInteractionInProgress = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ActionText.gameObject.SetActive(true);  // L'erreur se produit ici (ligne 77)
            ActionDisplay.SetActive(true);
            Open.SetActive(true);

            // Comment or remove the lines below
            // Anim.SetBool("Open", true);
            // CreakSound.Play();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ActionDisplay.SetActive(false);
            ActionText.SetActive(false);
            Open.gameObject.SetActive(false);

            // Comment or remove the lines below
            // Anim.SetBool("Open", false);
            // CreakSound.Play();
        }
    }

}
