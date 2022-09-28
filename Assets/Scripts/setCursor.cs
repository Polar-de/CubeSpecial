using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setCursor : MonoBehaviour
{

    public Texture2D crosshair;
    
    // Start is called before the first frame update
    void Start()
    {
        Vector2 cursorOffset = new Vector2(crosshair.width/4, crosshair.height / 4);
        
        Cursor.SetCursor(crosshair, cursorOffset, CursorMode.Auto);
    }
}
