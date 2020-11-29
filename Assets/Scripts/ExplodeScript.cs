using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeScript : StateMachineBehaviour
{
    [SerializeField] GameObject biggerBall;
    [SerializeField] GameObject DeathPowerUp;
    [SerializeField] GameObject ExpandPowerUp;
    [SerializeField] GameObject FasterBallPowerUp;
    [SerializeField] GameObject LasersPowerUp;
    [SerializeField] GameObject MultipleBallsPowerUp;
    [SerializeField] GameObject ShrinkPowerUp;
    [SerializeField] GameObject SlowerBallsPowerUp;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    //override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        int x = Random.Range(3, 5);
        switch (x)
        {
            case 1: Instantiate(biggerBall, new Vector3(animator.gameObject.transform.position.x, animator.gameObject.transform.position.y), Quaternion.identity);
                break;
            case 2:
                Instantiate(DeathPowerUp, new Vector3(animator.gameObject.transform.position.x, animator.gameObject.transform.position.y), Quaternion.identity);
                break;
            case 3:
                Instantiate(ExpandPowerUp, new Vector3(animator.gameObject.transform.position.x, animator.gameObject.transform.position.y), Quaternion.identity);
                break;
            case 4:
                Instantiate(FasterBallPowerUp, new Vector3(animator.gameObject.transform.position.x, animator.gameObject.transform.position.y), Quaternion.identity);
                break;
            case 5:
                Instantiate(LasersPowerUp, new Vector3(animator.gameObject.transform.position.x, animator.gameObject.transform.position.y), Quaternion.identity);
                break;
            case 6:
                Instantiate(MultipleBallsPowerUp, new Vector3(animator.gameObject.transform.position.x, animator.gameObject.transform.position.y), Quaternion.identity);
                break;
            case 7:
                Instantiate(ShrinkPowerUp, new Vector3(animator.gameObject.transform.position.x, animator.gameObject.transform.position.y), Quaternion.identity);
                break;
            case 8:
                Instantiate(SlowerBallsPowerUp, new Vector3(animator.gameObject.transform.position.x, animator.gameObject.transform.position.y), Quaternion.identity);
                break;
        }
        Destroy(animator.gameObject, stateInfo.length);
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
