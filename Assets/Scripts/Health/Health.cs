using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; } // Var can be grabbed from outside, but can only be set inside this script
    private bool dead;
    
    private Animator anim;

    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>(); // Get Animator to play hurt and death animation
    }

    public void TakeDamage(float _damage)
    {
        // Health can't go below 0 or above max health
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth > 0) // Player hurt
        {
            anim.SetTrigger("hurt"); // Play hurt animation
        }
        else // Player dead
        {
            if (!dead)
            {
                anim.SetTrigger("die"); // Play death animation
                GetComponent<PlayerMovement>().enabled = false;
                dead = true;
            }

        }
    }

    public void AddHealth(float _value)
    {
        // Health can't go below 0 or above max health
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    }
}
