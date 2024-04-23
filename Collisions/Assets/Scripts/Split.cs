using System;
using UnityEngine;

public class Split : MonoBehaviour
{
    public event Action<float> CubeNotSplitted;

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
                cube.GetComponent<Split>()._splitChance = cubeSplitChance / 2;
                cube.transform.localScale = cubePrefabScale / 2;
                cubePrefabScale = cube.transform.localScale;
                cubeSplitChance = cube.GetComponent<Split>()._splitChance;
            }
        }
        else
        {
            CubeNotSplitted.Invoke(_cubePrefab.transform.localScale.magnitude);
        }
    }
}
