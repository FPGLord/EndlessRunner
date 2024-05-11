using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelector : MonoBehaviour
{
    [SerializeField] private CharacterView _viewPrefab;
    [SerializeField] private CharacterData _selectedCharacter;
    [SerializeField] private CharacterData[] _data;

    private void Start()
    {
        _selectedCharacter.LoadData(_data[0]);
    }

    private int _index;

    public void ChooseNextCharacter()
    {
        if (_index < _data.Length)
        {
            _viewPrefab.ViewCat(_data[_index]);
            _selectedCharacter.LoadData(_data[_index]);
            _index++;
        }

        else
            _index = 0;
    }

    public void ChoosePreviousCharacter()
    {
        if (_index != 0)
        {
            _viewPrefab.ViewCat(_data[_index]);
            _index--;
        }

        else
            _index = _data.Length - 1;
    }

    public void LoadCharacter()
    {
        SceneManager.LoadScene(0);
    }
}