using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnStateExit : StateMachineBehaviour
{
    // Destroys the parent game object
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Destroy(animator.transform.parent.gameObject);
    }
}
