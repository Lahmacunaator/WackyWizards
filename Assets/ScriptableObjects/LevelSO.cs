using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level", menuName = "WackyWizard/New Level", order = 2)]
public class LevelSO : ScriptableObject
{
    public List<ModifierSO> Modifiers;

    //call this at level start for each level
    public void ApplyModifiers()
    {
        foreach (var modifier in Modifiers)
        {
            //apply the modifiers
        }   
    }

    public void AddModifier(ModifierSO modifier)
    {
        Modifiers.Add(modifier);
    }
}
