using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LauchingIceBladeFrostWalrus : StateMachineBehaviour
{
    private Transform laucher1;
    private Transform laucher2;
    private EnemyProjectile blade1;
    private EnemyProjectile blade2;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (laucher1 == null) laucher1 = animator.GetComponent<FrostWalrus>().iceBladeLaucher1;
        if (laucher2 == null) laucher2 = animator.GetComponent<FrostWalrus>().iceBladeLaucher2;
        if (blade1 == null) blade1 = animator.GetComponent<FrostWalrus>().iceBlade1;
        if (blade2 == null) blade2 = animator.GetComponent<FrostWalrus>().iceBlade2;

        Instantiate(blade1, laucher1.position, laucher1.rotation);
        Instantiate(blade2, laucher2.position, laucher2.rotation);
        var currentWave = animator.GetInteger("IceBladeWave");
        currentWave++;
        animator.SetInteger("IceBladeWave", currentWave);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

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
