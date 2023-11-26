using System.Collections;
using System.Collections.Generic;
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
    }

    public void TakeDamage()
    {
        if (damageCdTimer < damageCooldown) return;
        health--;
        damageCdTimer = 0f;
        AudioManager.Instance.PlaySound("TakeDamageSound");
    }
}
