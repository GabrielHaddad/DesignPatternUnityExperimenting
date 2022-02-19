using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float fullHealth = 100f;
    [SerializeField] float drainPerSecond = 2f;
    float currentHealth = 0;

    public event Action onHealthChange;

    void Awake() 
    {
        ResetHealth();
        StartCoroutine(HealthDrain());
    }

    void OnEnable()
    {
        GetComponent<Level>().onLevelUpAction += ResetHealth; //Add Listener;
    }

    void OnDisable()
    {
        GetComponent<Level>().onLevelUpAction -= ResetHealth; //Remove Listener;
    }

    public float GetCurrentHealth()
    {
        return currentHealth;
    }

    public float GetFullHealth()
    {
        return fullHealth;
    }

    void ResetHealth()
    {
        currentHealth = fullHealth;
        if (onHealthChange != null)
        {
            onHealthChange();
        }
    }

    private IEnumerator HealthDrain()
    {
        while (currentHealth > 0)
        {
            currentHealth -= drainPerSecond;

            if (onHealthChange != null)
            {
                onHealthChange();
            }

            yield return new WaitForSeconds(1);
        }
    }
}
