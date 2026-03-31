using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Монета подбралась!"); // для отладки
            GameManager.instance.AddCoin(); // добавляем монету
            Destroy(gameObject); // уничтожаем объект
        }
    }
}
