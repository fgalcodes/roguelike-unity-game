using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private Image healthbarImage;

    public void UpdateHealthbar(float maxHealth, float health, float previousHealth)
    {
        float targetHealth = health / maxHealth;
        previousHealth = previousHealth / maxHealth;
        StartCoroutine(HealthbarAnimation(targetHealth, previousHealth));
    }

    IEnumerator HealthbarAnimation(float targetHealth, float previousHealth)
    {
        float transitionTime = 0.5f, elapsedTime = 0f;
        while (elapsedTime < transitionTime)
        {
            elapsedTime += Time.deltaTime;
            healthbarImage.fillAmount = Mathf.Lerp(previousHealth, targetHealth, elapsedTime);
            yield return null;
        }
        healthbarImage.fillAmount = targetHealth;
    }
}
