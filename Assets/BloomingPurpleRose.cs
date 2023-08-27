using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloomingPurpleRose : StateMachineBehaviour
{
    public int xForce1;
    public int yForce1;
    public int xForce2;
    public int yForce2;
    private WebSpiderSmallSpider spider;
    private Transform spiderSpawner;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (spider == null) spider = animator.GetComponent<PurpleRose>().spider;
        if (spiderSpawner == null) spiderSpawner = animator.transform;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        var baby1 = Instantiate(spider, spiderSpawner.position, Quaternion.Euler(0, 0, 0));
        baby1.Jump(-xForce1, yForce1);
        var baby2 = Instantiate(spider, spiderSpawner.position, Quaternion.Euler(0, 0, 0));
        baby2.Jump(-xForce2, yForce2);
        var baby3 = Instantiate(spider, spiderSpawner.position, Quaternion.Euler(0, 180, 0));
        baby3.Jump(xForce1, yForce1);
        var baby4 = Instantiate(spider, spiderSpawner.position, Quaternion.Euler(0, 180, 0));
        baby4.Jump(xForce2, yForce2);
    }

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
