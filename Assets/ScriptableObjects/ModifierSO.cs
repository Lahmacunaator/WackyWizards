using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "WackyWizard/Modifier", order = 1)]
public class ModifierSO : ScriptableObject
{
    [field: SerializeField] public bool IsFloorSlippery { get; private set; }

    public void Apply()
    {
        if (IsFloorSlippery)
        {
            //apply the effect
        }
    }
}
