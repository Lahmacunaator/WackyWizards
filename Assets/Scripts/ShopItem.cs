using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopItem : MonoBehaviour
{
    [HideInInspector]
    public ModifierSO modifier;
    [SerializeField] private TMP_Text buttonText;

    public void UpdateModifier(ModifierSO modifierData)
    {
        modifier = modifierData;
        buttonText.text = modifierData.name;
    }
    
    public void SelectModifier()
    {
        GameManager.Instance.AddModifier(modifier);
        AudioManager.Instance.PlaySound("PowerUpSelect");
    }
    
}
