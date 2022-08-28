using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Camera cam;
    public float gunRange = 30f;
    public float enemyDamage = 20f;
    RaycastHit raycastHit2;
   void Update(){
      if(Physics.Raycast(cam.transform.position, cam.transform.forward,out raycastHit2, gunRange)){
        Debug.DrawRay(cam.transform.position,cam.transform.forward * raycastHit2.distance,Color.red);
      }
    if(Input.GetButtonDown("Fire1")){
        AnimationController.instanceOfAnimationController.isShooting = true;
    shoot();


    }
    if(Input.GetButtonDown("Fire2")){
        AnimationController.instanceOfAnimationController.isShooting = false;

    }

   }

   public void shoot(){
    RaycastHit raycastHit;

    if(Physics.Raycast(cam.transform.position, cam.transform.forward,out raycastHit, gunRange)){
        Debug.Log("Hit : "+raycastHit.transform.name);
 Target target = raycastHit.transform.GetComponent<Target>();
       if(target != null){
        
        target.TakeDamage(enemyDamage);
       
        Debug.Log("Doozy Killing : " );


       }else{
        Debug.Log("Target is null");
       }
    }
   }

   

   
}
