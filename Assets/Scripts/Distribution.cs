using System;
using UnityEngine;

public class Distribution : MonoBehaviour
{
    [SerializeField] GameObject _platform;
    [SerializeField] bool _withBoxes;

    public static Action<GameObject[]> onPlatformGenerated;

    private int _rows = 3;
    private int _columns = 3;
    private float _spacing = 2f;
    private GameObject[] _boxes;

    private void Awake()
    {        
        Generation();
    }

    private void Generation()
    {
        int totalCubes = _rows * _columns;
        _boxes = new GameObject[totalCubes];

        Vector3 parentPosition = transform.position;

        for (int i = 0; i < totalCubes; i++)
        {
            int row = i / _columns;
            int col = i % _columns;
            Vector3 position = parentPosition + new Vector3(col * _spacing, 0, row * _spacing);
            _boxes[i] = Instantiate(_platform, position, Quaternion.identity, transform);
        }

        if (_withBoxes)
            onPlatformGenerated?.Invoke(_boxes);
    }
}
