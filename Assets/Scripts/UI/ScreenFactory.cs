using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ScreenFactory : MonoBehaviour
{
    public static ScreenFactory Instance;
    [SerializeField] GameObject root;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
    public void Activate() 
    {
        root.SetActive(true);
   
    }
    public void Deactivate()
    {
        root.SetActive(false);
    }
    
}
