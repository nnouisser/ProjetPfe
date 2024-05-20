using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;
using System;
using System.Collections.Generic;

public class Pause : MonoBehaviour
{
    private bool isPaused = false;
    public GameObject pausePanel;
    public Slider energySlider;
    public Slider healthSlider;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                ResumeGame();
            else
                PauseGame();
        }
    }

    public void SavePlayerData()
    {
        Vector3 playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
        float healthValue = healthSlider.value;
        float energyValue = energySlider.value;

        UpdateUserDataRequest request = new UpdateUserDataRequest
        {
            Data = new Dictionary<string, string>
            {
                {"PlayerPosition_X", playerPosition.x.ToString()},
                {"PlayerPosition_Y", playerPosition.y.ToString()},
                {"PlayerPosition_Z", playerPosition.z.ToString()},
                {"Health", healthValue.ToString()},
                {"Energy", energyValue.ToString()}
            }
        };

        PlayFabClientAPI.UpdateUserData(request, OnSaveDataSuccess, OnSaveDataFailure);
    }

    private void OnSaveDataSuccess(UpdateUserDataResult result)
    {
        Debug.Log("Player data saved successfully.");
    }

    private void OnSaveDataFailure(PlayFabError error)
    {
        Debug.LogError("Failed to save player data: " + error.GenerateErrorReport());
    }

    public void LoadPlayerData()
    {
        GetUserDataRequest request = new GetUserDataRequest();

        PlayFabClientAPI.GetUserData(request, OnLoadDataSuccess, OnLoadDataFailure);
    }

    private void OnLoadDataSuccess(GetUserDataResult result)
    {
        // Retrieve and set player position
        if (result.Data.TryGetValue("PlayerPosition_X", out var xRecord) && float.TryParse(xRecord.Value, out var x) &&
            result.Data.TryGetValue("PlayerPosition_Y", out var yRecord) && float.TryParse(yRecord.Value, out var y) &&
            result.Data.TryGetValue("PlayerPosition_Z", out var zRecord) && float.TryParse(zRecord.Value, out var z))
        {
            Vector3 playerPosition = new Vector3(x, y, z);
            GameObject.FindGameObjectWithTag("Player").transform.position = playerPosition;
        }

        // Retrieve and set health value
        if (result.Data.TryGetValue("Health", out var healthRecord) && float.TryParse(healthRecord.Value, out var health))
            healthSlider.value = health;

        // Retrieve and set energy value
        if (result.Data.TryGetValue("Energy", out var energyRecord) && float.TryParse(energyRecord.Value, out var energy))
            energySlider.value = energy;

        Debug.Log("Player data loaded successfully.");
    }


    private void OnLoadDataFailure(PlayFabError error)
    {
        Debug.LogError("Failed to load player data: " + error.GenerateErrorReport());
    }

    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f;
        pausePanel.SetActive(true);
        SavePlayerData();
    }

    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
        LoadPlayerData();
    }
}
