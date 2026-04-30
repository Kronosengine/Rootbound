using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    [Header("Limits")]
    public bool useMaxLimit = false;
    public float maxXPosition; // Точка, где камера должна встать (у твоего дерева)

    void LateUpdate()
    {
        if (player == null) return;

        // Вычисляем желаемую позицию
        Vector3 desiredPosition = player.position + offset;

        // ОГРАНИЧЕНИЕ: Если включен лимит, не даем X стать больше maxXPosition
        if (useMaxLimit)
        {
            desiredPosition.x = Mathf.Clamp(desiredPosition.x, float.MinValue, maxXPosition);
        }

        // Камера не должна двигаться по Z, оставляем её стандартной
        desiredPosition.z = transform.position.z;

        // Плавное перемещение
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
    }
}