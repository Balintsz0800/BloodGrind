using System;
using UnityEngine;
using UnityEngine.UI;

public class XpBar : MonoBehaviour
{
    private Slider slider;
    private int currentXp, xpToNextLevel;
    public Character character;

    private void Awake()
    {
        slider = GetComponent<Slider>();
    }
    private void Update()
    {
        float fillValue = (float)character.currentXp / character.xpToNextLevel;
        slider.value = fillValue;
    }
}