using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public static AnimationController instanceOfAnimationController;
    public Animator animator;
    
    public bool isShooting;
    void Awake(){
        instanceOfAnimationController = this;
    }

    void Update(){
        if(isShooting){
        animator.SetBool("isShoot",true);}else{
             animator.SetBool("isShoot",false);
        }
    }

}
