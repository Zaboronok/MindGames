using UnityEngine;

public class BoxDistribution : MonoBehaviour
{
    [SerializeField] GameObject _box;

    private readonly int _rows = 3;
    private readonly int _columns = 3;
    private readonly float _spacing = 2f;

    public bool[] hasAdditionalBox;

    private void OnEnable()
    {
        Distribution.onPlatformGenerated += Generation;
    }

    private void OnDisable()
    {
        Distribution.onPlatformGenerated -= Generation;
    }
    
    void Generation(GameObject[] platforms)
    {
        int totalCubes = _rows * _columns;
        hasAdditionalBox = new bool[totalCubes];

        int numAdditionalCubes = Random.Range(1, totalCubes);

        for (int i = 0; i < numAdditionalCubes; i++)
        {
            int randomIndex;

            do
            {
                randomIndex = Random.Range(0, totalCubes);
            } while (hasAdditionalBox[randomIndex]);

            hasAdditionalBox[randomIndex] = true;
            Vector3 additionalPosition = platforms[randomIndex].transform.position + Vector3.up * _spacing;
            Instantiate(_box, additionalPosition, Quaternion.identity);
        }
    }
}
