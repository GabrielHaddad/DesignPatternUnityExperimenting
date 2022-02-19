using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthPresenter : MonoBehaviour
{
    [SerializeField] Health health;
    [SerializeField] Image healthBar;

    void Start() 
    {
        health.onHealthChange += UpdateUI;
        UpdateUI();
    }

    private void UpdateUI()
    {
        healthBar.fillAmount = health.GetCurrentHealth() / health.GetFullHealth();
    }
}
