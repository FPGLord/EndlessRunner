
using UnityEngine;

public class CharacterMeshSelecter : MonoBehaviour
{
    [SerializeField] private CharacterData _selectedCharacter;
    [SerializeField] private CharacterViewMesh _selectedMesh;
    [SerializeField] private CharacterData[] _data;

    private int _index;
    
    public void SelectCharacterView()
    {
        if (_index < _data.Length)
        {            
            _selectedMesh.ViewMechCaracter(_data[_index]);
            _selectedCharacter.LoadData(_data[_index]);
            _index++;
        }

        else
            _index = 0;
    }
    
}
