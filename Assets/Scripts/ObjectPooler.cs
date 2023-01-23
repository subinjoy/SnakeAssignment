using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class ObjectPooler : MonoBehaviour
{
    [SerializeField] Transform food1, food2;
    private void OnEnable()
    {
        EnableFood2();
    }

    public void EnableFood1()
    {
        food1.transform.position =  new Vector3(Random.Range(-5, 5), 1, Random.Range(-16, 3));
        food1.gameObject.SetActive(true);
    }
    public void EnableFood2()
    {
        food2.transform.position = new Vector3(Random.Range(-5, 5), 1, Random.Range(-16, 3));
        food2.gameObject.SetActive(true);
        
    }
    
}
