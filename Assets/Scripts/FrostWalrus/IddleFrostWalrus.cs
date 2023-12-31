using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IddleFrostWalrus : StateMachineBehaviour
{
    private Transform target;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (target == null) target = animator.GetComponent<FrostWalrus>().target;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        var xDirection = animator.transform.position.x > target.position.x ? 1 : -1;
        animator.transform.right = new Vector3(xDirection, 0, 0);


        var choice = Random.Range(0, 4);
        if (choice == 0)
        {
            animator.SetTrigger("IceBlade");
            animator.SetInteger("IceBladeWave", 0);
        }
        else if (choice == 1) animator.SetTrigger("FrostTower");
        else animator.SetTrigger("Walk");
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
