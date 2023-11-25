using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level", menuName = "WackyWizard/New Level", order = 2)]
public class LevelSO : ScriptableObject
{
    public List<ModifierSO> Modifiers { get; }

    //call this at level start for each level
    public void ApplyModifiers()
    {
        foreach (var modifier in Modifiers)
        {
            //apply the modifiers
        }   
    }
}
