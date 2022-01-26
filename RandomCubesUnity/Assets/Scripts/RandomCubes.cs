//Created by Ben Jenkins
//Created 1/24/2022
//Last Edited by: NA
//Last Edited: 1/26/2022
//Description: Spawns multiple cube prefabs into scene
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCubes : MonoBehaviour
{
    //Variables
    public GameObject CubePrefab; //new gameObject
    public List<GameObject> gameObjectList; //list for all cubes
    public float scalingFactor = 0.95f;
    [HideInInspector]
    public int numberOfCubes = 0;


    // Start is called before the first frame update
    void Start()
    {
        gameObjectList = new List<GameObject>();//instantiates the list
    }

    // Update is called once per frame
    void Update()
    {
        numberOfCubes++;
        GameObject gameobj = Instantiate<GameObject>(CubePrefab); //instantiate the cube prefab
        gameobj.name = "Cube" + numberOfCubes;

        Color randomcolor = new Color(Random.value, Random.value, Random.value); //create a random color
        gameobj.GetComponent<Renderer>().material.color = randomcolor; // assign color to cube using material compenent
        
        gameobj.transform.position = Random.insideUnitSphere;//random point inside a sphere radius 1
        gameObjectList.Add(gameobj);

        List<GameObject> removeList = new List<GameObject>();

        foreach(GameObject goTemp in gameObjectList)
        {
            float scale = goTemp.transform.localScale.x;//record starting scale
            scale *= scalingFactor; //set scale by scalingFactor
            goTemp.transform.localScale = Vector3.one * scale;//Changes the scale by setting scale to a vector of one multiplied by scale
            if(scale<=0.1f)
            {
                removeList.Add(goTemp);
            }
        }

        foreach(GameObject goTemp in removeList)
        {
            gameObjectList.Remove(goTemp);
            Destroy(goTemp);//removes object from game scene
        }
    }
}
