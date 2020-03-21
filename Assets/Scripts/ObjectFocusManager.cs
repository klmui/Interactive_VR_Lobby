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
    #endregion
}
