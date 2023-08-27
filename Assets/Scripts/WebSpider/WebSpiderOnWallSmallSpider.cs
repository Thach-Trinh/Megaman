using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebSpiderOnWallSmallSpider : StateMachineBehaviour
{
    public int speed;
    public float offset;
    private Transform foot;
    private Rigidbody2D rigid;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (foot == null) foot = animator.GetComponent<WebSpiderSmallSpider>().foot;
        if (rigid == null) rigid = animator.GetComponent<Rigidbody2D>();

        var newPosition = animator.transform.position;
        newPosition.x -= offset * animator.transform.right.x;
        animator.transform.position = newPosition;


        var yAngle = animator.transform.rotation.eulerAngles.y;
        animator.transform.rotation = Quaternion.Euler(0, yAngle, -90);

        rigid.gravityScale = 0;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        var newVelocity = rigid.velocity;
        newVelocity.y = speed;
        rigid.velocity = newVelocity;

        var isOnGround = Physics2D.OverlapCircle(foot.position, 0.1f, LayerMask.GetMask("Ground")) == null;
        if (isOnGround) animator.SetTrigger("IsOnGround");
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        var newPosition = animator.transform.position;
        newPosition.x -= offset * animator.transform.right.x;
        animator.transform.position = newPosition;

        var yAngle = animator.transform.rotation.eulerAngles.y;
        animator.transform.rotation = Quaternion.Euler(0, yAngle, 0);

        rigid.gravityScale = 1;
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
