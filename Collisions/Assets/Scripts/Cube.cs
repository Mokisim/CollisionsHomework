using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] Cube _cubePrefab;
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;

    private int _minCubesCount = 1;
    private int _maxCubesCount = 7;
    private float _splitChance = 100;

    private void OnMouseUpAsButton()
    {
        Split();
        Detonate();
        Destroy(gameObject);
    }

    private void Detonate()
    {
        foreach (Rigidbody explodableObjects in GetExplodableObjects())
        {
            explodableObjects.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
        }
    }

    private List<Rigidbody> GetExplodableObjects()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, _explosionRadius);

        List<Rigidbody> cubes = new();

        foreach (Collider hit in hits)
        {
            if (hit.attachedRigidbody != null)
            {
                cubes.Add(hit.attachedRigidbody);
            }
        }

        return cubes;
    }

    private void Split()
    {
        float randomMin = 0;
        float randomMax = 101;

        float chance = Random.Range(randomMin, randomMax);

        if (chance < _splitChance)
        {
            int cubesCount = Random.Range(_minCubesCount, _maxCubesCount);
            Vector3 cubePrefabScale = _cubePrefab.transform.localScale;
            float cubeSplitChance = _splitChance;

            for (int i = 0; i < cubesCount; i++)
            {
                Cube cube = Instantiate(_cubePrefab, transform.position, Quaternion.identity);
                cube._splitChance = cubeSplitChance / 2;
                cube.transform.localScale = cubePrefabScale / 2;
                cubePrefabScale = cube.transform.localScale;
                cubeSplitChance = cube._splitChance;
            }
        }
    }
}
