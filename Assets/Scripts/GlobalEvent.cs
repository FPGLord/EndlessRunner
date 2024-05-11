using UnityEngine;
using UnityEngine.Events;

public class GlobalEvent : ScriptableObject
{

public UnityEvent OnInvoke;
 public void Invoke()
 {
  OnInvoke.Invoke();
 }
 
}
