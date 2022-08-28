using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Target : MonoBehaviour
{
    public Slider slider;

    public float health = 100f;

    public Gradient gradient;

    public Image fill;
   

    public void TakeDamage(float damage)
    {
        health -= damage;
        SetHealth (health);
        if (health < 0f)
        {
            Destroy (gameObject);
            Debug.Log("Helath is Now : " + health);
            // SetEnemyCountText(EnemyInstantiateController.insOfEnemyInstantiateContorller.i);

        }
    }

    void Start()
    {
        SetMaxHealth (health);

    }

    public void SetMaxHealth(float health)
    {
        slider.maxValue = health;
        slider.value = health;

        fill.color = gradient.Evaluate(1f);
    }

    public void SetHealth(float health)
    {
        slider.value = health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    public void SetEnemyCountText(int count){
        EnemyInstantiateController.insOfEnemyInstantiateContorller.enemiesCountText.text = "" + count;
    }

   
}
