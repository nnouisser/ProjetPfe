using UnityEngine;
using UnityEngine.UI;

public class AmbientVolumeController : MonoBehaviour
{
    public Slider volumeSlider;
    public AudioSource ambientAudio;

    private void Start()
    {
        // Set the slider value to the current volume
        volumeSlider.value = ambientAudio.volume;

        // Add a listener to the slider's value change event
        volumeSlider.onValueChanged.AddListener(delegate { OnVolumeChanged(); });
    }

    // Called when the slider value changes
    private void OnVolumeChanged()
    {
        // Set the volume of the ambient audio source to the slider value
        ambientAudio.volume = volumeSlider.value;
    }
}
