using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Add this using directive for TextMeshPro
using UnityEngine.SceneManagement;

public class IntroSequencing : MonoBehaviour
{
    public GameObject textBox;
    public GameObject dateDisplay;
    public GameObject placeDisplay;
    public AudioSource line01;
    public AudioSource line02;
    public AudioSource line03;
    public AudioSource line04;
    public AudioSource line05;
    public AudioSource thudSound;
    public GameObject allBlack;
    public GameObject loadText;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        yield return new WaitForSeconds(3);
        placeDisplay.SetActive(true);
        yield return new WaitForSeconds(1);
        dateDisplay.SetActive(true);
        yield return new WaitForSeconds(4);
        placeDisplay.SetActive(false);
        dateDisplay.SetActive(false);
        yield return new WaitForSeconds(10);
        SetText("The night of October 29th 2008 changed me forever.");
        line01.Play();
        yield return new WaitForSeconds(4.5f);
        ClearText();
        yield return new WaitForSeconds(3);
        SetText("I headed out to investigate the haunting sounds in the woods.");
        line02.Play();
        yield return new WaitForSeconds(5);
        ClearText();
        yield return new WaitForSeconds(7);
        SetText("I stumbled upon a clearing with a cabin in the distance.");
        line03.Play();
        yield return new WaitForSeconds(5);
        ClearText();
        yield return new WaitForSeconds(5);
        SetText("I could hear those sounds again coming from there.");
        line04.Play();
        yield return new WaitForSeconds(4);
        ClearText();
        yield return new WaitForSeconds(6);
        SetText("Little did I know that this was only the beginning.");
        line05.Play();
        yield return new WaitForSeconds(4);
        ClearText();
        yield return new WaitForSeconds(17);
        allBlack.SetActive(true);
        thudSound.Play();
        yield return new WaitForSeconds(1);
        loadText.SetActive(true);
        SceneManager.LoadScene(1);
    }

    // Function to set text using TextMeshPro
    void SetText(string text)
    {
        textBox.GetComponent<TextMeshProUGUI>().text = text;
    }

    // Function to clear text
    void ClearText()
    {
        textBox.GetComponent<TextMeshProUGUI>().text = "";
    }
    public void skip()
    {
        SceneManager.LoadScene(1);
    } public void Back()
    {
        SceneManager.LoadScene(3);
    }
}
