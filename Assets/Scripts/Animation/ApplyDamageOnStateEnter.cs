using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyDamageOnStateEnter : StateMachineBehaviour
{
    // Gets melee script on parent object and calls hit
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Melee melee = animator.transform.parent.GetComponent<Melee>();

        melee.Hit();
    }
}
