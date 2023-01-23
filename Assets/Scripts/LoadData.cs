using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LoadData : MonoBehaviour
{
    string path;
    public TextAsset jsonString;
    public string[] foodTypes;
    
    // Start is called before the first frame update
    void Start()
    {
        foodInfo foodinfoInJson = JsonUtility.FromJson<foodInfo>(jsonString.text);
        foodTypes[0] = foodinfoInJson.food1;
        foodTypes[1] = foodinfoInJson.food2;
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    [System.Serializable]
    public class foodInfo
    {
        public string food1;
        public string food2;
    }
     
}
