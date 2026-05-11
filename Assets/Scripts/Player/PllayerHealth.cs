using UnityEngine;
using UnityEngine.UI; // Обязательно добавь это для работы с Image
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;

    private LosePanel losePanel;
    public float invincibleTime = 2f;
    private bool isInvincible = false;

    [Header("UI Settings")]
    public Image[] heartImages;    // Массив компонентов Image
    public Sprite fullHeart;       // Спрайт полного сердца
    public Sprite emptyHeart;      // Спрайт пустого сердца

    private Animator anim;         // Для анимации смерти

    void Start()
    {
        anim = GetComponent<Animator>();
        losePanel = FindObjectOfType<LosePanel>();
        currentHealth = maxHealth;
        UpdateHearts();
    }

    public void TakeDamage(int damage)
    {
        if (isInvincible || currentHealth <= 0) return;

        currentHealth -= damage;

        // Ограничиваем здоровье, чтобы не ушло в минус
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        UpdateHearts();

        if (currentHealth <= 0)
        {
            Die();
        }
        else
        {
            // Запускаем анимацию получения урона, если она есть в контроллере
            if (anim != null) anim.SetTrigger("Hurt");
            StartCoroutine(Invincibility());
        }
    }

    void UpdateHearts()
    {
        for (int i = 0; i < heartImages.Length; i++)
        {
            // Если индекс сердца меньше текущего здоровья — рисуем полное, иначе пустое
            if (i < currentHealth)
            {
                heartImages[i].sprite = fullHeart;
            }
            else
            {
                heartImages[i].sprite = emptyHeart;
            }
        }
    }

    IEnumerator Invincibility()
    {
        isInvincible = true;
        // Здесь можно добавить мигание спрайта игрока для визуального эффекта
        yield return new WaitForSeconds(invincibleTime);
        isInvincible = false;
    }

    void Die()
    {
        Debug.Log("Игрок умер");

        if (anim != null)
        {
            anim.SetTrigger("isDead"); // Запускаем анимацию смерти
        }

        if (losePanel != null)
        {
            losePanel.Show();
        }

        // Вместо моментального SetActive(false), лучше отключить скрипт управления
        // Чтобы анимация смерти успела проиграться
        GetComponent<PlayerMovement>().enabled = false;

        // Если хочешь, чтобы игрок исчез спустя время:
        // Destroy(gameObject, 2f); 
    }
}