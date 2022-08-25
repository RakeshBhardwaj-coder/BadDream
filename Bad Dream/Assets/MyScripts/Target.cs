using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public int health = 50;
    

    public void TakeDamage(int damage){
        health -= damage;
             if(health<0){
            Destroy(gameObject);
            Debug.Log("Helath is Now : "+health);
        }
        
    }
    void Update(){
       
    }
}
