using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFocusManager : MonoBehaviour
{

    List<ObjectFocus> objectsInRange = new List<ObjectFocus>();

    #region Singleton

    private static ObjectFocusManager _instance;
    public static ObjectFocusManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<ObjectFocusManager>();

                if (_instance == null)
                {
                    _instance = (new GameObject("ObjectFocusManager : Singleton")).AddComponent<ObjectFocusManager>();
                }
            }
            return _instance;
        }
        set
        {
            _instance = value;
        }
    }

    #endregion

    // Static makes it accessable from the object itself
    #region Static Properties & Methods
    static public int Count { get { return Instance.objectsInRange.Count; } }
    static public void Add(ObjectFocus objectFocus)
    {
        if (Instance.objectsInRange.Contains(objectFocus))
            return;
        Instance.objectsInRange.Add(objectFocus);
    }
    static public void Remove(ObjectFocus objectFocus)
    {
        Instance.objectsInRange.Remove(objectFocus);
    }

    #endregion

    #region MonoBehaviour
    private void Awake()
    {
        // Prevent duplicate instances of this game object
        if (Instance && Instance != this)
        {
            Destroy(gameObject);
        }

        Instance = this;
    }

    private void OnDisable()
    {
        Instance = null;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    #if DEBUG
    private void OnGUI()
    {
        GUILayout.Label("Objects in Focus : " + Count.ToString());
    }
    #endif  
    #endregion
}
