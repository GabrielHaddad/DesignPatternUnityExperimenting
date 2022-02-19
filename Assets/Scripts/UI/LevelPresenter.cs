using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class LevelPresenter : MonoBehaviour
{
    [SerializeField] Level level;
    [SerializeField] TextMeshProUGUI levelText;
    [SerializeField] TextMeshProUGUI experienceText;
    [SerializeField] Button increaseXPButton;

    void Start() 
    {
        increaseXPButton.onClick.AddListener(() => GainExperience());
        level.onExperienceChange += UpdateUI;
        UpdateUI();
    }

    private void GainExperience()
    {
        level.GainExperience(10);
    }

    private void UpdateUI()
    {
        levelText.text = $"Level: {level.GetLevel()}";
        experienceText.text = $"Level: {level.GetExperience()}";
    }
}
