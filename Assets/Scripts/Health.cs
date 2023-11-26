using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int health;
    public int NumberOfHearts;

    public Image[] Hearts;
    public Sprite FullHeart;
    public Sprite EmptyHeart;

    public float damageCooldown = 3f;
    private float damageCdTimer = 0f;
    private bool isShieldActive;
    
    private float shieldTimer;
    public float shieldCooldown;
    public float shieldActiveTime;
    public GameObject shield;
    private bool isShieldUnlocked;

    private void Update()
    {
        for (int i = 0; i < Hearts.Length; i++) 
        {
            if (i < health)
            {
                Hearts[i].sprite = FullHeart;

            }
            else
            {
                Hearts[i].sprite = EmptyHeart;
            }
        }

        damageCdTimer += Time.deltaTime;

        if (!isShieldUnlocked) return;
        
        shieldTimer += Time.deltaTime;
        
        if (shieldTimer >= shieldCooldown && !isShieldActive)
        {
            ActivateShield();
        }

        Debug.Log(shieldTimer);
        
        if (shieldTimer >= shieldActiveTime && isShieldActive)
        {
            shield.SetActive(false);
            isShieldActive = false;
            shieldTimer = 0;
        }
    }

    public void TakeDamage()
    {
        if (isShieldActive) return;
        if (damageCdTimer < damageCooldown) return;
        health--;
        damageCdTimer = 0f;
    }

    public void UnlockShield()
    {
        isShieldUnlocked = true;
        ActivateShield();
    }

    private void ActivateShield()
    {
        shield.SetActive(true);
        isShieldActive = true;
        shieldTimer = 0;
    }
}
