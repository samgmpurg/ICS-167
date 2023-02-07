using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int PlayerIndex{get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void Initalize(int index){
        PlayerIndex = index;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
