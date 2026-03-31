using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;
    private LosePanel losePanel;
    public float invincibleTime = 2f;
    private bool isInvincible = false;

    public GameObject[] hearts;

    void Start()
    {
        losePanel = FindObjectOfType<LosePanel>();
        currentHealth = maxHealth;
        UpdateHearts();
    }

    public void TakeDamage(int damage)
    {
        if (isInvincible) return;

        currentHealth -= damage;

        if (currentHealth < 0)
            currentHealth = 0;

        UpdateHearts();

        if (currentHealth <= 0)
        {
            Die();
        }
        else
        {
            StartCoroutine(Invincibility());
        }
    }

    void UpdateHearts()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].SetActive(i < currentHealth);
        }
    }

    IEnumerator Invincibility()
    {
        isInvincible = true;
        yield return new WaitForSeconds(invincibleTime);

        isInvincible = false;
    }

    void Die()
    {
        Debug.Log("Игрок умер");

        if (losePanel != null)
        {
            losePanel.Show();
        }

        gameObject.SetActive(false);
    }
}