using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(StatusManager))]
public class Health : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    [SerializeField] private float currentHealth;
    [SerializeField] private StatusManager statusManager ;
    private float tempMaxHealth;
    private float healthBeforeBoost;
    private float maxHealthBeforeBoost;
    private float tempAmmount;
    public void TakeDamage(float damage)
    {
        if (!statusManager.iFrameEnabled)
        {
            if (currentHealth - damage > maxHealth)
            {
                currentHealth = maxHealth;
            }
            else
            {
                currentHealth -= damage;
            }

            if (currentHealth <= 0)
            {
                Die();
            }
        }
    }

    private void Die()
    {
        GetComponentInParent<PlayerStats>().UpdateDeathStatus(true);
        GetComponentInParent<PlayerInitalize>().HandleDeathTimer();


        this.gameObject.SetActive(false);
    }

    public void SetMaxHealth(float ammount)
    {
        if (maxHealth != ammount)
        {
            maxHealth = ammount;
            currentHealth = maxHealth;
        }
    }

    public void GainTempHealth(float ammount, float duration)
    {
        tempAmmount = ammount;
        maxHealthBeforeBoost = maxHealth;
        tempMaxHealth = maxHealth + tempAmmount;
        healthBeforeBoost = currentHealth;
        currentHealth += tempAmmount;

        Invoke("LoseTempHealth", duration);
    }

    private void LoseTempHealth()
    {
        maxHealth = maxHealthBeforeBoost;

        if(currentHealth > healthBeforeBoost)
        {
            currentHealth = healthBeforeBoost;
        }

    }
}
