using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Slider slider;
    public int health = 100;
    public int maxHealth = 100;
    private Level2 level2Script;

    void Start()
    {
        slider.value = health;
        slider.maxValue = maxHealth;

        // Get the Level2 script component
        level2Script = FindObjectOfType<Level2>();
    }

    void Update()
    {
        slider.value = health;

        if (health <= 0)
        {
            gameObject.SetActive(false); // Disable the enemy GameObject when health reaches 0
            level2Script.EnemyKilled(); // Call EnemyKilled function from Level2 script
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("magic") && health > 0)
        {
            health -= 20;
            if (health < 0)
                health = 0;
        }
    }
}
