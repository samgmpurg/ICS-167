using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    protected int mov;
    [SerializeField]
    protected int atkRange;
    [SerializeField]
    private Vector3 location {get; set;}
    [SerializeField]
    private GameObject redSquare;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void defineAtkTile()
    {
        ArrayList temp = new ArrayList();

        for ( int i = (int)(location.y) - mov; i <= location.y + mov; i++)
        {
            for (int j = (int)(location.x) - mov; j <= location.x + mov; j++)
            {
                if (Mathf.Abs(i + j) <= mov)
                    temp.Add(new Vector3(i, j));
            }
        }

        for ( int i = 0; i < temp.Count; i++)
        {
            foreach (Vector3 vec in temp)
                Instantiate(redSquare, vec, Quaternion.identity);
        }

    }

}
