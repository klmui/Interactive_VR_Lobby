using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFocus : MonoBehaviour
{
    [SerializeField] Transform reference;

    [SerializeField] float minAngle = 10; // Distance to camera is 10 or less, label will be fully opaque
    [SerializeField] float maxAngle = 10;

    private float _fadeAmount;
    public float fadeAmount
    {
        get { return _fadeAmount; }
        set
        {
            if(value != _fadeAmount)
            {
                _fadeAmount = value;
            }
        }
    }

    private float _delta;
    public float delta
    {
        get { return _delta; }
        set
        {
            if (value != _delta)
            {
                _delta = value;
                // Update fade amount value
            }
        }
    }

    void Fade()
    {
        // Update delta
    }

    // Start is called before the first frame update
    void Awake()
    {
        //reference = GameObject.FindGameObjectWithTag("MainCamera").transform;
        //reference = Camera.main.transform;
        if (!reference)
        {
            reference = Camera.main.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
