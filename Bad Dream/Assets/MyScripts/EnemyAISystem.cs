using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAISystem : MonoBehaviour
{
   public UnityEngine.AI.NavMeshAgent navMeshAgent;
   public Transform player;
    public LayerMask whatIsGround, whatIsPlayer;
    public Animator enemyAnimator;

    //Patrolling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attacking 
    public float timeBetweenAttacks;
    bool alreadyAttacked;

    //States
    public float sightRange,attackRange;
    public bool isPlayerInSightRange,isPlayerInAttackRange;

    void Awake(){
        player = GameObject.Find("FPSController").transform;
        navMeshAgent = GetComponent<NavMeshAgent>();

    }
    void Start(){
        enemyAnimator.SetBool("isAttack",false);
    }
    void Update(){
        //check for sight and attack range
        isPlayerInSightRange = Physics.CheckSphere(transform.position,sightRange,whatIsPlayer);
        isPlayerInAttackRange = Physics.CheckSphere(transform.position,attackRange,whatIsPlayer);

        if(!isPlayerInSightRange && !isPlayerInAttackRange) Patrolling();
        if(isPlayerInSightRange && !isPlayerInAttackRange) ChasePlayer();
        if(isPlayerInSightRange && isPlayerInAttackRange) AttackPlayer();



    }
    
    
    private void ChasePlayer(){
navMeshAgent.SetDestination(player.position);

    }
private void AttackPlayer(){
        //Make sure enemy doesn't move
        navMeshAgent.SetDestination(transform.position);
        transform.LookAt(player);
        
        if(!alreadyAttacked){

            ///Attack code here
enemyAnimator.SetBool("isAttack",true);
            ///
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack),timeBetweenAttacks);

        }
    }
    private void ResetAttack(){
        alreadyAttacked = false;
        enemyAnimator.SetBool("isAttack", false);

    }
    private void Patrolling(){
        if(!walkPointSet) SearchWalkPoint();
        if(walkPointSet) navMeshAgent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint  = transform.position - walkPoint;

        //Walkpoint Reached
        if(distanceToWalkPoint.magnitude<1f){
            walkPointSet = false;

        }
    }
    private void SearchWalkPoint(){
        //Calculate random point in Range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if(Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround)){
            walkPointSet = true;
        }
    }
    void OnDrawGizmosSelected(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,attackRange);
         Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position,sightRange);
    }
}
