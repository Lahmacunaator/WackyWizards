using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Shop : MonoBehaviour
{
    [SerializeField] private List<ShopItem> shopButtons;

    // Start is called before the first frame update
    private void OnEnable()
    {
        GenerateShopMods();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenerateShopMods()
    {
        var mods = GameManager.Instance.AllModifiers;

        foreach (var shopItem in shopButtons)
        {
            shopItem.UpdateModifier(mods[Random.Range(0, mods.Count)]);
        }
    }
}
