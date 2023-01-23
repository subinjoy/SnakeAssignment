using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinglePlayerManager : MonoBehaviour
{
    [SerializeField] GameObject snakeObj;
    private void OnEnable()
    {
        snakeObj.SetActive(true);
    }
    private void OnDisable()
    {
       // snakeObj.SetActive(false);
    }

}
