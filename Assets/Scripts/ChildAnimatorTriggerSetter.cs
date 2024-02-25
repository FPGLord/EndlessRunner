using UnityEngine;

public class ChildAnimatorTriggerSetter : MonoBehaviour
{
   public void SetAnimatorTrigger(string triggerName)
    {
        Animator animator = GetComponentInChildren<Animator>();
        animator.SetTrigger(triggerName);
    }
}