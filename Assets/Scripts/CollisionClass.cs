using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionClass : MonoBehaviour
{
    [SerializeField] private SnakeClass SnakeClass_Access;
    [SerializeField] private GameController gamecontrol_Access;
    [SerializeField] private ScoreManager ScoreManager_Access;
    [SerializeField] GameOverScreen gameOverScreen;
    [SerializeField] UIManager uiManager;
    private bool startGame;
   
  
    // Start is called before the first frame update
    void Start()
    {
        Invoke("SetStartGame", 2f);
        gamecontrol_Access = GameController.Instance;
        ScoreManager_Access = ScoreManager.Instance;
        gameOverScreen = GameOverScreen.Instance;
        uiManager = UIManager.Instance;
        
    }

    private void SetStartGame()
    {
        startGame = true;
    }
    private void OnCollisionEnter(Collision collision)
    {
        
        if (this.gameObject.tag == "Edge")
        {
            if (collision.gameObject.name == "snakeBody")
            {
                gamecontrol_Access.gameOver = true;
                if (!uiManager.GetMultiplayerStatus())
                    gameOverScreen.Activate();
                else
                    ScoreManager_Access.CheckGameOver();

            }
        }
        if (this.gameObject.tag == "SNAKE")
        {
            if (startGame)
            {
                if (collision.gameObject.name == "snakeBody")
                {
                    
                     gamecontrol_Access.gameOver = true;
                    gameOverScreen.Activate();
                       
                }
            }
        }
       
    }
   
}
