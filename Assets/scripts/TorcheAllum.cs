using UnityEngine;
using UnityEngine.UI;

public class TorcheAllum : MonoBehaviour
{
    public Light torche;
    public GameObject SpotLightt;

    void Start()
    {
        SpotLightt = GameObject.Find("SpotLight");
    }

    public void Torche()
    {
        if (!SpotLightt.activeSelf)
        {
            SpotLightt.SetActive(true);
        }
        else
        {
            SpotLightt.SetActive(false);
        }
    }
}