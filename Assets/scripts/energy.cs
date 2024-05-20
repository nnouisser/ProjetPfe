using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Energy : MonoBehaviour
{
    public Slider slider; // r�f�rence vers le slider dans l'�diteur Unity
    private float timeElapsed = 0f; // temps �coul� depuis la derni�re diminution

    void Start()
    {
               // Assurez-vous que le slider commence avec une valeur pleine (100)
        slider.maxValue = 100; // D�finir la valeur maximale du slider � 100
        slider.value = slider.maxValue; // D�finir la valeur actuelle du slider � sa valeur maximale
    }

    void Update()
    {
        // Incr�mente le temps �coul�
        timeElapsed += Time.deltaTime;

        // V�rifie si 5 secondes se sont �coul�es
        if (timeElapsed >= 120f)
        {
            DecreaseSlider(); // Diminue le slider
            timeElapsed = 0f; // R�initialise le temps �coul�
        }
    }

    // M�thode pour diminuer le slider de 5
    void DecreaseSlider()
    {
        slider.value -= 5f;

        // Assurez-vous que la valeur ne descend pas en dessous de z�ro
        if (slider.value < 0)
        {
            slider.value = 0;
        }
        if (slider.value == 0)
        { SceneManager.LoadScene("GameOver"); }

    }
    void OnTriggerEnter(Collider other)
    {
        // Check if the collider is tagged as "Player"
        if (other.CompareTag("Player"))
        {
            // Increase energy when the player eats the apple
            slider.value += 5f;

            // Destroy the apple GameObject
            Destroy(gameObject);
        }
    }
}
