using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LookFollow : MonoBehaviour
{
    public Transform target;
    public float attackDistance = 2f;
  
    private NavMeshAgent agent;
    private Animation anim;
    private bool attacked = false;
    public int health ;
    public Slider healthSlider;
    public AudioSource hurtSound1;
    public AudioSource hurtSound2;
    public AudioSource hurtSound3;
    public int hurtGen;

    void Start()
    {
        if (healthSlider == null)
        {
            Debug.LogError("HealthSlider is not assigned in the Unity Editor.");
            return;
        }

        healthSlider.value = health;

        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animation>();

        
    }

    void Update()
    {
        if (target == null)
            return;

        // Set the target position with the desired height offset
        Vector3 targetPosition = target.position;

        agent.SetDestination(targetPosition);

        if (Vector3.Distance(targetPosition, transform.position) <= attackDistance)
        {
            if (!attacked) // Check if the attack animation is not already playing
            {
                anim.Play("attack");
                attacked = true;

                // Decrease player's health when the enemy successfully attacks
                PlayerHealth();
            }
        }
        else
        {
            if (!anim.IsPlaying("walk")) // Check if the walk animation is not already playing
            {
                anim.Play("walk");
                attacked = false;
            }
        }
    }

    void PlayerHealth()
    {
        if (health > 0) // Check if player's health is greater than 0
        {
            health -= 10; // Decrease player's health by 20
            hurtGen = Random.Range(1, 4);
            if (hurtGen == 1)
            {
                hurtSound1.Play();
            }
            else if (hurtGen == 2)
            {
                hurtSound2.Play();
            }
            else
            {
                hurtSound3.Play();
            }

            if (health <= 0)
            {
                SceneManager.LoadScene("GameOver");
            }

            healthSlider.value = health;
        }
    }
}
    