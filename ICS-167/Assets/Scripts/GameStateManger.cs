using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManger : MonoBehaviour
{
    public GameObject object1; //this is just a temp spawn in as I need to go to Office hours for assistance
    public GameObject object2;
    public GameObject object3;
    public GameObject object4;
    public GameObject object5;
    public GameObject object6;
    private Vector3 spot1;
    private Vector3 spot2;
    private Vector3 spot3;
    private Vector3 spot4;
    private Vector3 spot5;

    private static GameStateManger _instance;
    // Start is called before the first frame update
    void Start()
    {
        spot1 = new Vector3(0.0f,0.0f,1.0f); //Each x and y value corosponses to a grid spot on the map
        spot2 = new Vector3(1.0f,1.0f,1.0f); //Can be potentially spawned out of the map if we're not careful
        spot3 = new Vector3(5.0f,1.0f,1.0f);
        spot4 = new Vector3(5.0f,2.0f,1.0f);
        spot5 = new Vector3(7.0f,6.0f,1.0f);
        if(_instance == null){
            _instance = this; //standard GameStateManger stuff
        }
        else{ 
            Destroy(object1);
            Destroy(object2);
            Destroy(object3);
            Destroy(object4);
            Destroy(object5);
        }//This is a very bad way to initialize stuff and WILL be changed in the fututre
        DontDestroyOnLoad(object1);
        Instantiate(object1,spot1, Quaternion.identity);
        DontDestroyOnLoad(object2);
        Instantiate(object2,spot2, Quaternion.identity);
        DontDestroyOnLoad(object3);
        Instantiate(object3,spot3, Quaternion.identity);
        DontDestroyOnLoad(object4);
        Instantiate(object4,spot4, Quaternion.identity);
        DontDestroyOnLoad(object5);
        Instantiate(object5,spot5, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
