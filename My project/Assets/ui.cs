using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ui : MonoBehaviour
{
    public GameObject logoText;

    // Start is called before the first frame update
    public void Start()
    {
        logoText.SetActive(false);
    }

    // Update is called once per frame
    public void OnMouseOver()
    {
        logoText.SetActive(true);
    }

    public void OnMouseExit()
    {
        logoText.SetActive(false);
    }
}
