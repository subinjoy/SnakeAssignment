using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableFood : Food
{
 
    [SerializeField] private float moveSpeed;
    public override void Spawn()
    {
        objectPooler.EnableFood2();
    }
    private void Update()
    {
        MoveFood();
    }
    private void MoveFood()
    {
            gameObject.transform.Translate(new Vector3((moveSpeed *direction* Time.deltaTime), 0, 0));
       
    }
   
}

