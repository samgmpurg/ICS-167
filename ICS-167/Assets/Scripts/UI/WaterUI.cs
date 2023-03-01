using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterUI : MonoBehaviour
{
    public GameObject WaterText;

    // Start is called before the first frame update
    public void Start()
    {
        WaterText.SetActive(false);
    }

    // Update is called once per frame
    public void OnMouseOver()
    {
        WaterText.SetActive(true);
    }

    public void OnMouseExit()
    {
        WaterText.SetActive(false);
    }
}
