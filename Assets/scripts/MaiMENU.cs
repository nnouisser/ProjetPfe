using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using PlayFab.ClientModels;
using PlayFab;
using System;

public class MaiMENU : MonoBehaviour
{
    public GameObject reglerpanel;
    public Slider volumeSlider;
    public string scene01 = "scene001";
    public string introo = "intro";
    public GameObject loadText;
    public GameObject FadeOut;
    public AudioSource musicSource;
    public Slider musicVolumeSlider;

    private float playerPositionX;
    private float playerPositionY;
    private float playerPositionZ;
    private float healthval;
    private float energyval;

    void Start()
    {
        if (musicVolumeSlider != null)
        {
            musicVolumeSlider.value = 0.5f;
        }

        // Call method to retrieve player position and health/energy from PlayFab
        GetPlayerPositionFromPlayFab();
        GetEnergyAndHealthPlayFab();
    }

    public void StartGame()
    {
        StartCoroutine(NewGameStart());
    }

    public void LoadGame()
    {
        SaveValues();
        SceneManager.LoadScene(scene01);
    }

    IEnumerator NewGameStart()
    {
        FadeOut.SetActive(true);
        yield return new WaitForSeconds(3);
        loadText.SetActive(true);
        SceneManager.LoadScene(introo);
    }

    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }

    public void ToggleSettingsPanel()
    {
        reglerpanel.SetActive(true);
    }

    public void backtoparam()
    {
        reglerpanel.SetActive(false);
    }

    void Awake()
    {
        if (musicSource == null)
        {
            musicSource = GetComponent<AudioSource>();
        }

        if (musicVolumeSlider != null)
        {
            musicVolumeSlider.value = musicSource.volume;
            musicVolumeSlider.onValueChanged.AddListener(ChangeVolume);
        }
    }

    public void ChangeVolume(float newVolume)
    {
        musicSource.volume = newVolume;
    }

    // Method to get player position from PlayFab
    private void GetPlayerPositionFromPlayFab()
    {
        // Define the request
        GetUserDataRequest request = new GetUserDataRequest();

        // Call the PlayFab API to get user data
        PlayFabClientAPI.GetUserData(request, OnGetPlayerPositionSuccess, OnGetPlayerPositionFailure);
    }

    private void GetEnergyAndHealthPlayFab()
    {
        // Define the request
        GetUserDataRequest request = new GetUserDataRequest();

        // Call the PlayFab API to get user data
        PlayFabClientAPI.GetUserData(request, OnGetEnergyAndHealthSuccess, OnGetEnergyAndHealthFailure);
    }

    private void OnGetPlayerPositionSuccess(GetUserDataResult result)
    {
        // Retrieve player position
        if (result.Data.TryGetValue("PlayerPosition_X", out var xRecord) && float.TryParse(xRecord.Value, out var xFloat))
        {
            playerPositionX = xFloat;
        }

        if (result.Data.TryGetValue("PlayerPosition_Y", out var yRecord) && float.TryParse(yRecord.Value, out var yFloat))
        {
            playerPositionY = yFloat;
        }

        if (result.Data.TryGetValue("PlayerPosition_Z", out var zRecord) && float.TryParse(zRecord.Value, out var zFloat))
        {
            playerPositionZ = zFloat;
        }

        Debug.Log("Player position retrieved from PlayFab. X: " + playerPositionX + ", Y: " + playerPositionY + ", Z: " + playerPositionZ);

        // Call SetPosition method here if needed
    }

    private void OnGetEnergyAndHealthSuccess(GetUserDataResult result)
    {
        // Retrieve health value
        if (result.Data.TryGetValue("Health", out var healthRecord) && float.TryParse(healthRecord.Value, out var healthFloat))
        {
            healthval = healthFloat;
            Debug.Log("Health value retrieved from PlayFab: " + healthval);
        }

        // Retrieve energy value
        if (result.Data.TryGetValue("Energy", out var energyRecord) && float.TryParse(energyRecord.Value, out var energyFloat))
        {
            energyval = energyFloat;
            Debug.Log("Energy value retrieved from PlayFab: " + energyval);
        }

        Debug.Log("Health and energy values retrieved from PlayFab. Health: " + healthval + ", Energy: " + energyval);

        // Call appropriate methods here if needed
    }

    private void OnGetPlayerPositionFailure(PlayFabError error)
    {
        Debug.LogError("Failed to retrieve player position from PlayFab: " + error.GenerateErrorReport());
    }

    private void OnGetEnergyAndHealthFailure(PlayFabError error)
    {
        Debug.LogError("Failed to retrieve health and energy from PlayFab: " + error.GenerateErrorReport());
    }

    public void SaveValues()
    {
        PlayerPrefs.SetFloat("PlayerPosition_X", playerPositionX);
        PlayerPrefs.SetFloat("PlayerPosition_Y", playerPositionY);
        PlayerPrefs.SetFloat("PlayerPosition_Z", playerPositionZ);
        PlayerPrefs.SetFloat("Energy", energyval);
        PlayerPrefs.SetFloat("Health", healthval);
        PlayerPrefs.Save();
    }
}
