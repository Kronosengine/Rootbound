using UnityEngine;

public class SpikeDamage : MonoBehaviour
{
    public int damage = 1;

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth player = other.GetComponent<PlayerHealth>();

            if (player != null)
            {
                player.TakeDamage(damage);
            }
        }
    }
}