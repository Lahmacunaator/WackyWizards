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
    }
}
