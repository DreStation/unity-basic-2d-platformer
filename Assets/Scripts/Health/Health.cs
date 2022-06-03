using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; } // Var can be grabbed from outside, but can only be set inside this script
    
    private Animator anim;

    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>(); // Get Animator to play hurt and death animation
    }

    private void TakeDamage(float _damage)
    {
        // Health can't go below 0 or above max health
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth > 0) // Player hurt
        {
            anim.SetTrigger("hurt");
        }
        else // Player dead
        {
            anim.SetTrigger("die");
        }
    }
}
