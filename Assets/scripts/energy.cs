using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Energy : MonoBehaviour
{
    public Slider slider; // référence vers le slider dans l'éditeur Unity
    private float timeElapsed = 0f; // temps écoulé depuis la dernière diminution

    void Start()
    {
               // Assurez-vous que le slider commence avec une valeur pleine (100)
        slider.maxValue = 100; // Définir la valeur maximale du slider à 100
        slider.value = slider.maxValue; // Définir la valeur actuelle du slider à sa valeur maximale
    }

    void Update()
    {
        // Incrémente le temps écoulé
        timeElapsed += Time.deltaTime;

        // Vérifie si 5 secondes se sont écoulées
        if (timeElapsed >= 120f)
        {
            DecreaseSlider(); // Diminue le slider
            timeElapsed = 0f; // Réinitialise le temps écoulé
        }
    }

    // Méthode pour diminuer le slider de 5
    void DecreaseSlider()
    {
        slider.value -= 5f;

        // Assurez-vous que la valeur ne descend pas en dessous de zéro
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
