using UnityEngine;

public class EnemyProjectile : EnemyDamage // Inherited EnemyDamage
{
    [SerializeField] private float speed;
    [SerializeField] private float resetTime;
    private float lifetime;

    public void ActivateProjectile()
    {
        lifetime = 0;
        gameObject.SetActive(true);
    }

    private void Update()
    {
        float movementSpeed = speed * Time.deltaTime; // Arrow's speed is framerate independent
        transform.Translate(movementSpeed, 0, 0); // Move it on the x-axis

        lifetime += Time.deltaTime;
        if (lifetime > resetTime)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision); // Run this method of the same name from parent (EnemyDamage) first
        gameObject.SetActive(false); // Deactivate when arrow hits another collider
    }
}
