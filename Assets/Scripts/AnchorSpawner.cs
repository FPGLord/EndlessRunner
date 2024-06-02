using System.Collections;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class AnchorSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _anchors;
    [SerializeField] private RandomRotationYSetter randomRotationYSetter;
    [SerializeField] private AnchorMover _anchorMover;
    [SerializeField] private int _distanceBetweenAnchors;
    private Vector3 _spawnPoint;

    private void Awake()
    {
        _spawnPoint = new Vector3(-90, transform.position.y, transform.position.z);
    }

    private void Update()
    {
        DisableAnchor();
        Move();
    }

    private void Start()
    {
        StartCoroutine(SpawnAnchorsAtRandomTime());
    }

    private IEnumerator SpawnAnchorsAtRandomTime()
    {
        var disabledAnchors = _anchors.ToArray();
        disabledAnchors.Shuffle();
        foreach (var anchor in disabledAnchors)
        {
            InizializeAnchor(anchor);
            yield return new WaitForSeconds(Random.Range(2f,5f));
        }
    }

    private void Move()
    {
        foreach (var anchor in _anchors)
        {
            _anchorMover.MoveAnchor(anchor.transform);
        }
    }

    private void EnableAnchor()
    {
        foreach (var anchor in _anchors)
            InizializeAnchor(anchor);
    }

    private void DisableAnchor()
    {
        foreach (var anchor in _anchors)
            if (anchor.transform.position.x >= 90f)
                InizializeAnchor(anchor);
    }

    private void InizializeAnchor(GameObject anchor)
    {
        anchor.SetActive(true);
        randomRotationYSetter.Set(anchor.transform);
        anchor.transform.position = _spawnPoint;
    }
}