using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SnakeClass : MonoBehaviour
{
    public float snakeSpeed;
    public  Vector3 moveDirection;
    public int startSize;
    public List<Transform> snakeBody = new List<Transform>();
    public float GapDistance;
    public float RotateSpeed;
    public GameObject snakePart;
    public float distance;
    float TimeGap;
    Transform lastPart, currPart;
    private const float MIN_SWIPE_DISTANCE = 0.17f;
    private const float MAX_SWIPE_TIME = 0.5f;
    Vector2 startPos;
    float startTime;
    // public bool isFood;






    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void InitilaliseSnake()
    {
        for(int i = 0; i < startSize; i++)
        {
            CreateSnakeGrid();
        }
        moveDirection = new Vector3(0, 0, 1);
    }
    public void SwipeControl()
    {
       

        if (Input.touches.Length > 0)
        {
            Touch t = Input.GetTouch(0);
            if (t.phase == TouchPhase.Began)
            {
                startPos = new Vector2(t.position.x / (float)Screen.width, t.position.y / (float)Screen.width);
                startTime = Time.time;
            }
            if (t.phase == TouchPhase.Ended)
            {
                if (Time.time - startTime > MAX_SWIPE_TIME) // press too long
                    return;

                Vector2 endPos = new Vector2(t.position.x / (float)Screen.width, t.position.y / (float)Screen.width);

                Vector2 swipe = new Vector2(endPos.x - startPos.x, endPos.y - startPos.y);

                if (swipe.magnitude < MIN_SWIPE_DISTANCE) // Too short swipe
                    return;

                if (Mathf.Abs(swipe.x) > Mathf.Abs(swipe.y))
                { // Horizontal swipe
                    if (swipe.x > 0)
                    {
                        moveDirection = new Vector3(1, 0, 0);
                    }
                    else
                    {
                        moveDirection = new Vector3(-1, 0, 0);
                    }
                }
                else
                { // Vertical swipe
                    if (swipe.y > 0)
                    {
                        moveDirection = new Vector3(0, 0, 1);
                    }
                    else
                    {
                        moveDirection = new Vector3(0, 0, -1);
                    }
                }
            }
        }
    }
    public void KeyBoardControl()
    {
        if (Input.GetKey(KeyCode.RightArrow))
            moveDirection = new Vector3(1, 0, 0);
        if (Input.GetKey(KeyCode.LeftArrow))
            moveDirection = new Vector3(-1, 0, 0);
        if (Input.GetKey(KeyCode.UpArrow))
            moveDirection = new Vector3(0, 0, 1);
        if (Input.GetKey(KeyCode.DownArrow))
            moveDirection = new Vector3(0, 0, -1);


    }
    public void CreateSnakeGrid()
    {
       
        Transform newPart = (Instantiate(snakePart, snakeBody[snakeBody.Count - 1].position, snakeBody[snakeBody.Count - 1].rotation) as GameObject).transform;
        newPart.SetParent(this.transform);
        snakeBody.Add(newPart);
      
        
    }
   
    public void MoveSnake()
    {
        snakeBody[0].Translate(moveDirection * snakeSpeed * Time.smoothDeltaTime, Space.World);
        for(int i = 1; i < snakeBody.Count; i++)
        {
            currPart = snakeBody[i];
            lastPart=snakeBody[i-1];
            distance = Vector3.Distance(lastPart.position, currPart.position);
            Vector3 newPosition = lastPart.position;
            newPosition.y = snakeBody[0].position.y;
            TimeGap = Time.deltaTime * distance / GapDistance * snakeSpeed;
            if (TimeGap > 0.5f)
                TimeGap = 0.5f;
            currPart.position = Vector3.Slerp(currPart.position, newPosition, TimeGap);
            currPart.rotation = Quaternion.Slerp(currPart.rotation, lastPart.rotation, TimeGap);
        }
        
       
        
    }
    












}
