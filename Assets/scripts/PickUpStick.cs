using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PickUpStick : MonoBehaviour
{
    public AudioSource MagicSound;
    public GameObject PickButton;
    public TextMeshProUGUI Pick;
    public GameObject FakePistol;
    public GameObject RealPistol;
    public GameObject GuideArrow;
    public Transform Player;
    public Transform Stick;
    private float TheDistance;
    public GameObject RealAxe;
    


    void Update()
    {
        TheDistance = Vector3.Distance(Player.position, Stick.position);
        CheckDistance();
    }

    void CheckDistance()
    {
        if (TheDistance <= 2)
        {
            Pick.text = "Pick Up Stick";
            Pick.gameObject.SetActive(true); // Correction ici
            PickButton.SetActive(true);
        }
        else
        {
            Pick.gameObject.SetActive(false); // Correction ici
            PickButton.SetActive(false);
        }
    }

    public void PickIt()
    {
        if (TheDistance <= 2)
        {
            this.GetComponent<BoxCollider>().enabled = false;
            Pick.gameObject.SetActive(false); // Correction ici
            MagicSound.Play();

            FakePistol.SetActive(false);
            RealAxe.SetActive(true);
            GuideArrow.SetActive(false);
        }
    }
}
