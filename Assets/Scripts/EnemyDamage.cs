using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public int damage = 1;

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth player = collision.gameObject.GetComponent<PlayerHealth>();

            if (player != null)
            {
                player.TakeDamage(damage);
            }
            //копайлотом тут не пахнет. Здесь замешан DeepSeek
        }
    }
}