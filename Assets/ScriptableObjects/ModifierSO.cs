using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "WackyWizard/Modifier", order = 1)]
public class ModifierSO : ScriptableObject
{
    public bool IsFloorSlippery;
    public float ProjectileSpeed = 1;

    public void Apply()
    {
        if (IsFloorSlippery)
        {
            //apply the effect
        }

        if (ProjectileSpeed != 1)
        {
            
        }
    }
}
