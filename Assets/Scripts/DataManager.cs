
using UnityEngine;

public class DataManager : ScriptableObject
{
    [SerializeField] private CharacterData[] _data;


    public CharacterData[] data => _data;
}


