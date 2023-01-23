using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance;
    public bool gameOver;
    [SerializeField] private GameObject snake;
    public SnakeClass snakeClass_Access;
    [SerializeField] SnakeClass multiPlayerSnake;
    public ScoreManager ScoreManager_Access;
    public GameObject GameOverPanel;
    [SerializeField] private UIManager uiManager;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    // Start is called before the first frame update
    void OnEnable()
    {
        //if(!uiManager.GetMultiplayerStatus())
        //snakeClass_Access.InitilaliseSnake();
        var snakeObj = Instantiate(snake, snake.transform.position,Quaternion.identity);
        snakeClass_Access = snakeObj.GetComponent<SnakeClass>();
        ScoreManager_Access.InitScore();
    }
    // Update is called once per frame
    void Update()
    {
        if (!uiManager.GetMultiplayerStatus())
        {
           
            snakeClass_Access.SwipeControl();
            snakeClass_Access.KeyBoardControl();
            if (!gameOver)
                snakeClass_Access.MoveSnake();
        }
        else
        {
            
                multiPlayerSnake.SwipeControl();
            multiPlayerSnake.KeyBoardControl();
            if (!gameOver)
                multiPlayerSnake.MoveSnake();
        }
        
        
       
    }
    public void SetSnakeClass(SnakeClass snake)
    {
        multiPlayerSnake = snake;
    }
}
