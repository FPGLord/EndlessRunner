using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelector : MonoBehaviour
{
    [SerializeField] private CharacterView _viewPrefab;
    [SerializeField] private CharacterData _selectedCharacter;
    [SerializeField] private CharacterData[] _data;
    private int _index;

    private void Start()
    {
        _selectedCharacter.LoadData(_data[0]);
        _index = 0;
    }


    public void ChooseNextCharacter()
    {
        _index++;
        if (_index >= _data.Length)
            _index = 0;

        _viewPrefab.ViewCat(_data[_index]);
        _selectedCharacter.LoadData(_data[_index]);
    }

    public void ChoosePreviousCharacter()
    {
        _index--;
        if (_index < 0)
            _index = _data.Length - 1;

        _viewPrefab.ViewCat(_data[_index]);
        _selectedCharacter.LoadData(_data[_index]);
    }

    public void LoadCharacter()
    {
        SceneManager.LoadScene(0);
    }
}