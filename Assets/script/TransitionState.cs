using UnityEngine;

public class BorneStateBehavior : StateMachineBehaviour
{
    public float speed;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetFloat("TransitionSpeed", speed);
    }
}
