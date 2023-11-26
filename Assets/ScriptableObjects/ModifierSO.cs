using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "WackyWizard/Modifier", order = 1)]
public class ModifierSO : ScriptableObject
{
    public ModifierType ModifierType;

    public void Apply()
    {
        switch (ModifierType)
        {
            case ModifierType.SLIPPERY:
                FindFirstObjectByType<PlayerMovement>().ActivateSlippery();
                break;
            case ModifierType.DASH:
                FindFirstObjectByType<PlayerMovement>().ActivateDash();
                break;
            case ModifierType.SHIELD:
                FindFirstObjectByType<Health>().UnlockShield();
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}

public enum ModifierType
{
    SLIPPERY,
    DASH,
    SHIELD
}
