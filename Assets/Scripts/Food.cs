using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public abstract class Food : MonoBehaviour
{
    [SerializeField] private SnakeClass snakeClass;
    [SerializeField] private GameController gamecontrol;
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] public ObjectPooler objectPooler;
    public int direction = 1;
  
    

    private void OnCollisionEnter(Collision collision) 
    {

        if (collision.gameObject.name == "snakeBody")
        {
            snakeClass = collision.gameObject.transform.GetComponentInParent<SnakeClass>();
            if (UIManager.Instance.GetMultiplayerStatus())
            {
                if (collision.gameObject.GetComponent<PhotonView>().IsMine)
                    scoreManager.UpdateScore();
                else scoreManager.UpdateOpponentScore();
            }
            else
                scoreManager.UpdateScore();
            snakeClass.CreateSnakeGrid();
            Spawn();
            gameObject.SetActive(false);
        }
        if (collision.gameObject.tag == "Edge")
            direction = -direction;
    }
    public abstract void Spawn();
    
   
}
