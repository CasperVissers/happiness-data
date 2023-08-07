using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Happiness Style", menuName = "ScriptableObjects/UI/Styles/Happiness")]
public class SO_HappinessStyle : ScriptableObjectSingleton<SO_HappinessStyle> 
{
    [Header("Bar Styles")]
    [SerializeField]
    public Gradient barGradient;
}
