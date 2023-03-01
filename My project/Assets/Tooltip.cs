using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tooltip : MonoBehaviour
{

    public string message;

    private void OnMouseEnter()
    {
        Tooltipmanager._instance.SetAndShowToolTip(message);
    }
    
    private void OnMouseExit()
    {
        Tooltipmanager._instance.HideToolTip();
    }
}
