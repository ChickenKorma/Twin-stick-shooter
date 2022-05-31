using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyDamageOnStateEnter : StateMachineBehaviour
{
    [SerializeField] private float damageRadius, damage;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(animator.transform.position, damageRadius);

        foreach(Collider2D hit in hits)
        {
            Destructible obj = hit.transform.GetComponent<Destructible>();

            if(obj != null)
            {
                obj.ApplyDamage(damage);
            }
        }
    }
}
