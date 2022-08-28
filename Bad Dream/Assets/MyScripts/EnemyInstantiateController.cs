using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyInstantiateController : MonoBehaviour
{
     int i=1;
     public int enemies = 2;
//    public bool nextEnemy = false;
    public TMP_Text enemiesCountText;

   public GameObject enemy;
   public GameObject instantiatingPosition;
    public static EnemyInstantiateController insOfEnemyInstantiateContorller;

    void Awake(){
        insOfEnemyInstantiateContorller = this;
    }
    void Start(){

    }
    void Update(){
            StartCoroutine(InstantiateEnemy());
      
    }



IEnumerator InstantiateEnemy(){
    while (i <enemies)
    {
    Instantiate(enemy, instantiatingPosition.transform.position, Quaternion.identity);
    i+=1;
    yield return new WaitForSeconds(.1f);
    
    }
  
        
    }


}
