using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ZombieAI : MonoBehaviour
{
    private Animator animator;
    private Transform target;
    public float attackDistance = 2f;
    private bool isRunning = false;
    public int health = 100;
    public Slider healthSlider;
    public AudioSource[] hurtSounds;
    private int hurtGen;

    private void Start()
    {
        healthSlider.value = health;
        healthSlider.maxValue = health;
        animator = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (target != null)
        {
            float distanceToTarget = Vector3.Distance(target.position, transform.position);
            if (distanceToTarget <= attackDistance)
            {
                isRunning = false;
                Attack();
            }
            else
            {
                isRunning = true;
            }
        }
        else
        {
            // If the target is null, try to find the player again
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }

        animator.SetBool("attack", isRunning);
    }

    private void Attack()
    {
        // Decrease player's health when the enemy successfully attacks
        if (health > 0)
        {
            health -= 10; // Decrease player's health by 10
            PlayHurtSound();
            if (health <= 0)
            {
                SceneManager.LoadScene("GameOver");
            }

            healthSlider.value = health;
        }
    }

    private void PlayHurtSound()
    {
        if (hurtSounds.Length > 0)
        {
            int randomIndex = Random.Range(0, hurtSounds.Length);
            hurtSounds[randomIndex].Play();
        }
    }
}
