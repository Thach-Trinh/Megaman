using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebSpiderActiveLightningWeb : StateMachineBehaviour
{
    public float speed;
    public float detectingRadius;

    private Transform target;
    private Vector2 direction;
    private bool isLocked;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (target == null) target = animator.GetComponent<WebSpiderLightningWeb>().target;
        isLocked = false;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!isLocked)
        {
            direction = target.position - animator.transform.position;
            if (direction.magnitude <= detectingRadius) isLocked = true;
        }
        animator.transform.Translate(speed * Time.deltaTime * direction.normalized);
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
