using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReleasingHadokenSecondWaveMagmaDragoon : StateMachineBehaviour
{
    public int numberOfHadoken;
    public float releasingDelay;


    private float nextReleasingTime;
    private EnemyProjectile hadokenPrefab;
    private Transform releasingPosition;
    private int currentHadokenIndex;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        hadokenPrefab = animator.GetComponent<MagmaDragoon>().hadoken;
        releasingPosition = animator.GetComponent<MagmaDragoon>().hadokenSecondWavePoint;
        currentHadokenIndex = 0;


    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Time.time >= nextReleasingTime)
        {
            Instantiate(hadokenPrefab, releasingPosition.position, releasingPosition.rotation);
            nextReleasingTime = Time.time + releasingDelay;
            currentHadokenIndex++;
        }
        if (currentHadokenIndex == numberOfHadoken) animator.SetTrigger("StopHadoken");

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
