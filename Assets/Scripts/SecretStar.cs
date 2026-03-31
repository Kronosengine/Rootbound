using UnityEngine;

public class SecretStar : MonoBehaviour
{
    public static bool collected = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            collected = true;
            Destroy(gameObject);
        }
    }
}