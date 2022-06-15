using System.Collections;
using UnityEngine;

public class FireTrap : MonoBehaviour
{
    [SerializeField] private float damage;

    [Header("Firetrap Timers")]
    [SerializeField] private float activationDelay;
    [SerializeField] private float activeTime;

    private bool triggered; // When trap is triggered
    private bool active; // When trap is firing and can hurt player

    private Animator anim;
    private SpriteRenderer spriteRend;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (!triggered)
            {
                StartCoroutine(ActivateFiretrap());
            }
            if (active)
            {
                collision.GetComponent<Health>().TakeDamage(damage);
            }
        }
    }

    private IEnumerator ActivateFiretrap()
    {
        // Trap is triggered
        triggered = true;
        spriteRend.color = Color.red; // Red visual cue that the trap is triggered
        yield return new WaitForSeconds(activationDelay);

        // Trap is activated
        active = true;
        spriteRend.color = Color.white;
        anim.SetBool("activated", true);
        yield return new WaitForSeconds(activeTime);

        // Reset
        triggered = false;
        active = false;
        anim.SetBool("activated", false);
    }
}
