using UnityEngine;

[RequireComponent(typeof(Renderer))] // Tells Unity that this requires a Renderer, safety
public class MaterialGradientModifier : MonoBehaviour
{
    private Renderer _renderer; // Don't want it to be accessable to other scripts

    // public Color myColor;
    [SerializeField] private Gradient gradient; // Tell Unity to serialize field, only available from Unity

    // Disappear from inspector if no public
    float _gradientPosition = -1;
    public float gradientPosition
    {
        get { return _gradientPosition; }
        set
        {
            if (_gradientPosition != value)
            {
                _gradientPosition = value;
                _renderer.material.color = gradient.Evaluate(_gradientPosition);
            }
        }
    }

    //void SetGradientPosition (float position)
    //{
    //    if (position == gradientPosition)
    //    {
    //        return;
    //    } else
    //    {
    //        gradientPosition = position;
    //        _renderer.material.color = gradient.Evaluate(gradientPosition);
    //    }
    //}

    // Called before start
    private void Awake()
    {
        // Find first renderer that is in same game object
        _renderer = GetComponent<Renderer>();
    }

    // Start is called before the first frame update
    //private void Start()
    //{
    //    //SetGradientPosition(0);
    //    gradientPosition = 0;
    //}

    // Update is called once per frame
    //private void Update()
    //{
    //    // Current time of the game and sin goes from -1 to 1
    //    //SetGradientPosition(Mathf.Sin((Time.time) * 0.5f) + 0.5f);
    //    gradientPosition = Mathf.Sin((Time.time) * 0.5f) + 0.5f;
    //}
}