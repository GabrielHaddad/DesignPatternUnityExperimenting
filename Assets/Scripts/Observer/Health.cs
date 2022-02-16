using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float fullHealth = 100f;
    [SerializeField] float drainPerSecond = 2f;
    float currentHealth = 0;

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

    public float GetHealth()
    {
        return currentHealth;
    }

    void ResetHealth()
    {
        currentHealth = fullHealth;
    }

    private IEnumerator HealthDrain()
    {
        while (currentHealth > 0)
        {
            currentHealth -= drainPerSecond;
            yield return new WaitForSeconds(1);
        }
    }
}
