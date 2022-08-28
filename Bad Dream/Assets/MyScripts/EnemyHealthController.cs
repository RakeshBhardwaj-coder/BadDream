using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthController : MonoBehaviour
{
    public int health = 50;
    public Slider healthSlider;
    public static EnemyHealthController instanceOfEnemyHealthControllerController;
    public void TakeDamage(int damage){
        health -= damage;
             if(health<0){
            Destroy(gameObject);
            Debug.Log("Helath is Now : "+health);
        }
        
    }
}
