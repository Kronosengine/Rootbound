using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject stonePrefab;
    public Transform throwPoint;
    public float throwForce = 10f;

    public float cooldown = 0.5f;
    private float timer;

    float direction = 1f;

    void Update()
    {
        timer -= Time.deltaTime;

        // определяем направление игрока
        float move = Input.GetAxisRaw("Horizontal");

        if (move > 0)
            direction = 1f;
        else if (move < 0)
            direction = -1f;

        if (Input.GetKeyDown(KeyCode.F) && timer <= 0)
        {
            ThrowStone();
            timer = cooldown;
        }
    }

    void ThrowStone()
    {
        GameObject stone = Instantiate(stonePrefab, throwPoint.position, Quaternion.identity);

        Rigidbody2D rb = stone.GetComponent<Rigidbody2D>();

        rb.velocity = new Vector2(direction * throwForce, 0);
    }
}