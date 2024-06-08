using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class AnchorSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _anchors;

    [FormerlySerializedAs("randomRotationYSetter")] [SerializeField]
    private RandomScaleXSetter randomScaleXSetter;

    [SerializeField] private AnchorMover _anchorMover;
    [SerializeField] private int _distanceBetweenAnchors;
    private Vector3 _spawnPoint;

    private void Awake()
    {
        _spawnPoint = new Vector3(-190, transform.position.y, transform.position.z);
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
            yield return new WaitForSeconds(Random.Range(2f, 5f));
        }
    }

    private void Move()
    {
        foreach (var anchor in _anchors)
        {
            if (anchor.activeInHierarchy)
                _anchorMover.MoveAnchor(anchor.transform);
        }
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
        randomScaleXSetter.Set(anchor.transform);
        anchor.transform.position = _spawnPoint;
    }
}