
using UnityEngine;

public class Cat : ScriptableObject
{
    [SerializeField] private Avatar _avatar;

    public Avatar avatar => _avatar;
}
