using UnityEngine;
using UnityEngine.Serialization;

public class CharacterClothSelecter : MonoBehaviour
{
    [SerializeField] private CharacterData _selectedCharacter;
    [SerializeField] private CharacterViewCloth selectedCloth;
    [SerializeField] private CharacterData[] _data;

    private int _index;

    public void SelectCharacterView()
    {
        _index++;
        if (_index >= _data.Length)
            _index = 0;

        selectedCloth.ViewClothCaracter(_data[_index]);
        _selectedCharacter.LoadData(_data[_index]);
    }
}