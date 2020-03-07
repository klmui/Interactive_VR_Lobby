using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Renderer))] // Tells Unity that this requires a Renderer, safety
public class MaterialGradientModifier : MonoBehaviour
{
    Renderer _renderer;

    // Called before start
    void Awake() {
        // Find first renderer that is in same game object
        _renderer = GetComponent<Renderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        _renderer.material.color = Color.red;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
