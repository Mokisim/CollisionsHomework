using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private Splitter _splitter;
    
    private void OnMouseUpAsButton()
    {
        _splitter.Multiply();
        Destroy(gameObject);
    }
}
