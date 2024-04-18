using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private Split _splitter;
    [SerializeField] private Detonate _detonator;

    private void OnMouseUpAsButton()
    {
        _splitter.Multiply();
        _detonator.Explode();
        Destroy(gameObject);
    }
}
