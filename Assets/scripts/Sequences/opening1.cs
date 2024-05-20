using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
using UnityEngine.UI;
using TMPro;

public class opening1 : MonoBehaviour
{
   
    public GameObject ThePlayer;
    public GameObject FadeScreenIn;
    public TextMeshProUGUI TextBox;
    public GameObject levelImage;


    void Start()
    {
        ThePlayer.GetComponent<StarterAssets.FirstPersonController>().enabled = false;
        StartCoroutine(ScenePlayer());
       
    }

    IEnumerator ScenePlayer()
    {
        yield return new WaitForSeconds(1.5f);
        FadeScreenIn.SetActive(false);
        TextBox.text = "Oh My God, Where am I?";

        yield return new WaitForSeconds(2);
        TextBox.text = "";

        levelImage.SetActive(true);

        yield return new WaitForSeconds(2);
        TextBox.text = "";
        levelImage.SetActive(false);

        ThePlayer.GetComponent<StarterAssets.FirstPersonController>().enabled = true;
    }

}
