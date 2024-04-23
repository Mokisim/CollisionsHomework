using System;
using UnityEngine;

public class Splitter : MonoBehaviour
{
    public event Action<float> SplitFailed;

    [SerializeField] private Cube _cubePrefab;

    private int _minCubesCount = 1;
    private int _maxCubesCount = 7;
    private float _splitChance = 100;

    public void Multiply()
    {
        float randomMin = 0;
        float randomMax = 101;

        float chance = UnityEngine.Random.Range(randomMin, randomMax);

        if (chance < _splitChance)
        {
            int cubesCount = UnityEngine.Random.Range(_minCubesCount, _maxCubesCount);
            Vector3 cubePrefabScale = _cubePrefab.transform.localScale;
            float cubeSplitChance = _splitChance;
            
            for (int i = 0; i < cubesCount; i++)
            {
                Cube cube = Instantiate(_cubePrefab, transform.position, Quaternion.identity);
                cube.GetComponent<Splitter>()._splitChance = cubeSplitChance / 2;
                cube.transform.localScale = cubePrefabScale / 2;
                cubePrefabScale = cube.transform.localScale;
                cubeSplitChance = cube.GetComponent<Splitter>()._splitChance;
            }
        }
        else
        {
            SplitFailed.Invoke(_cubePrefab.transform.localScale.magnitude);
        }
    }
}
