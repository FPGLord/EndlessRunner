
using UnityEngine;
using UnityEngine.Serialization;

public class CharacterClothSelecter : MonoBehaviour
{
    [SerializeField] private CharacterData _selectedCharacter;
    [FormerlySerializedAs("_selectedMesh")] [SerializeField] private CharacterViewCloth selectedCloth;
    [SerializeField] private CharacterData[] _data;

    private int _index;
    
    public void SelectCharacterView()
    {
        if (_index < _data.Length)
        {            
            selectedCloth.ViewClothCaracter(_data[_index]);
            _selectedCharacter.LoadData(_data[_index]);
            _index++;
        }

        else
            _index = 0;
    }
    
}
