using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodClass : MonoBehaviour
{
    public GameObject food1, food2, currentFood;
    public string currentFoodType;
    public LoadData dataAccess;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SpawnFood()
    {
        currentFoodType = dataAccess.foodTypes[Random.Range(0, dataAccess.foodTypes.Length)];
        if (currentFoodType == dataAccess.foodTypes[0])
            currentFood = food1;
        if (currentFoodType == dataAccess.foodTypes[1])
            currentFood = food2;
        Instantiate(currentFood, new Vector3(Random.Range(-5, 5), 1, Random.Range(-16, 3)),Quaternion.identity);
    }
    
}
