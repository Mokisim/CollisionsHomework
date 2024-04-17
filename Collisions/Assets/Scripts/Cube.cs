using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private SplitSkill _splitter;
    [SerializeField] private DetonateSkill _detonator;

    private void OnMouseUpAsButton()
    {
        _splitter.Split();
        _detonator.Detonate();
        Destroy(gameObject);
    }
}
