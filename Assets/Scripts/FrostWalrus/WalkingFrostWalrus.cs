using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingFrostWalrus : StateMachineBehaviour
{
    public int speed;
    public float defendingDelay;

    private float nextDefendingTime;

    private Transform foot;
    private Transform checker;
    private Transform target;
    private Rigidbody2D rigid;


    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (foot == null) foot = animator.GetComponent<FrostWalrus>().foot;
        if (checker == null) checker = animator.GetComponent<FrostWalrus>().dangerChecker;
        if (rigid == null) rigid = animator.GetComponent<Rigidbody2D>();
        if (target == null) target = animator.GetComponent<FrostWalrus>().target;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        var xDirection = animator.transform.position.x > target.position.x ? 1 : -1;
        animator.transform.right = new Vector3(xDirection, 0, 0);

        var newVelocity = rigid.velocity;
        newVelocity.x = -speed * animator.transform.right.x;
        rigid.velocity = newVelocity;
        if (Physics2D.OverlapArea(foot.position, checker.position, LayerMask.GetMask("PlayerProjectile")) != null && Time.time > nextDefendingTime)
        {
            
            animator.SetTrigger("Defend");
            nextDefendingTime = Time.time + defendingDelay;
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{

    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
