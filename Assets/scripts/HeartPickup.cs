// HeartPickup.cs
using UnityEngine;
using UnityEngine.UI;

public class HeartPickup : MonoBehaviour
{
    public int healthToAdd = 10;
    private LookFollow lookFollow;
    public Slider healthSlider;

    void Start()
    {
        lookFollow = FindObjectOfType<LookFollow>(); // Find LookFollow script in the scene
        if (lookFollow == null)
        {
            Debug.LogError("LookFollow script not found in the scene.");
            return;
        }

        healthSlider.value = lookFollow.health; // Set health slider value to the initial health from LookFollow
    }

    void Update()
    {
        // Update health if necessary
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            lookFollow.health += healthToAdd; // Update health in LookFollow
            lookFollow.health = Mathf.Min(lookFollow.health, 100);
            healthSlider.value = lookFollow.health;
            Destroy(gameObject);
        }
    }
}
