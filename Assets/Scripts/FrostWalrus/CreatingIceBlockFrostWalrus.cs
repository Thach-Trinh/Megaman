using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatingIceBlockFrostWalrus : StateMachineBehaviour
{
    public int numberOfIceGas;
    public float releasingDelay;

    //public float minAngleInDegree;
    //public float maxAngleInDegree;

    private Transform mouth;
    private Transform creatingPoint;
    private float nextReleasingTime;
    private FrostWalrusIceGas iceGas;
    private FrostWalrusIceBlock iceBlock;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (iceBlock == null) iceBlock = animator.GetComponent<FrostWalrus>().iceBlock;
        if (iceGas == null) iceGas = animator.GetComponent<FrostWalrus>().iceGas;
        if (mouth == null) mouth = animator.GetComponent<FrostWalrus>().mouth;
        if (creatingPoint == null) creatingPoint = animator.GetComponent<FrostWalrus>().iceBlockPosition;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Time.time > nextReleasingTime)
        {
            for (int i = 0; i < numberOfIceGas; i++)
            {
                var newIceGas = Instantiate(iceGas, mouth.position, mouth.rotation);
                var xDirection = -1f;
                var yDirection = Random.Range(-1f, 1f);
                newIceGas.direction = new Vector2(xDirection, yDirection);
            }

            nextReleasingTime = Time.time + releasingDelay;
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        FrostWalrus.currentIceBlock = Instantiate(iceBlock, creatingPoint.position, creatingPoint.rotation);
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
