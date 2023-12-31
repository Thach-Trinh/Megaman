using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebSpiderOnAirSmallSpider : StateMachineBehaviour
{
    private Transform foot;
    //private Transform head;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (foot == null) foot = animator.GetComponent<WebSpiderSmallSpider>().foot;
        //if (head == null) head = animator.GetComponent<WebSpiderSmallSpider>().head;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        var isOnGround = Physics2D.OverlapCircle(foot.position, 0.1f, LayerMask.GetMask("Ground")) != null;
        if (isOnGround) animator.SetTrigger("IsOnGround");
        //var isOnWall = Physics2D.OverlapCircle(head.position, 0.1f, LayerMask.GetMask("Ground")) != null;
        //if (isOnWall) animator.SetTrigger("Walk");
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
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
