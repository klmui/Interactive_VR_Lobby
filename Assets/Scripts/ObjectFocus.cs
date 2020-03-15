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
        // Transform is the green cube
        // Reference is the camera
        //Debug.DrawLine(reference.position, transform.position, Color.yellow);
        // Shows forward direction of camera(reference.position) blue axis is z-index
        Vector3 d = (transform.position - reference.position).normalized; // source to dest

        Debug.DrawRay(reference.position, d, Color.yellow);
        Debug.DrawRay(reference.position, reference.forward, Color.cyan);

        // Normalize makes it so that the sum of all of its components = 1
        delta = Vector3.Angle(d.normalized, reference.forward);
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
        Fade();
    }

    private void OnGUI()
    {
        GUILayout.Label("delta: " + delta.ToString());
        GUILayout.Label("fadeAmount: " + fadeAmount.ToString());
    }
}
