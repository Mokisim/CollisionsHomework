using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detonator : MonoBehaviour
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;
    [SerializeField] private Splitter _split;

    private void OnEnable()
    {
        _split.SplitFailed += Explode;
    }

    private void OnDisable()
    {
        _split.SplitFailed -= Explode;
    }

    private void Explode(float explosionMultiplier)
    {
        foreach (Rigidbody explodableObjects in GetExplodableObjects())
        {
            explodableObjects.AddExplosionForce(_explosionForce/explosionMultiplier, transform.position, _explosionRadius/explosionMultiplier);
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
}
