using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Camera cam;
    RaycastHit raycastHit2;
   void Update(){
      if(Physics.Raycast(cam.transform.position, cam.transform.forward,out raycastHit2, 100f)){
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
    if(Physics.Raycast(cam.transform.position, cam.transform.forward,out raycastHit, 20f)){
        Debug.Log("Hit : "+raycastHit.transform.name);
 Target target = raycastHit.transform.GetComponent<Target>();
       if(target != null){
        target.TakeDamage(20);

       }else{
        Debug.Log("Target is null");
       }
    }
   }
}
