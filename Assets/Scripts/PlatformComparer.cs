using System;
using UnityEngine;

public class PlatformComparer : MonoBehaviour
{
    [SerializeField] Distribution _firstPlatform;
    [SerializeField] Distribution _secondPlatform;

    public GameObject[] _platforms;

    private bool _hasAdditionalBoxFirst;
    private bool _hasAdditionalBoxSecond;

    private void Awake()
    {
    }

    private void Update()
    {
        CompareBoxPositions();
    }

    private void CompareBoxPositions()
    {
    }
}
