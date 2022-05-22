using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    public static bool isActive = true;
    private GameObject obj;
    private bool isDragging = true;

    public static bool isTrash = false;
    
    private void Awake()
    {
        // print("awake");
        RotateItems.cur = transform;
        isTrash = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(isActive)
        {
            var touch = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            // print(touch);
            if (!Input.GetMouseButton(0) && isDragging)
            {
                StopDrag();
            }
            if (isDragging)
            {
                var t = transform;
                t.position = new Vector3(touch.x, touch.y, t.position.z);
            }

        }
    }
    
    
    

    private void OnMouseDown()
    {
        if(isActive)
        {
            // print(1);
            isDragging = true;
            RotateItems.cur = transform;
            
        }
    }
    
    private void OnMouseUp()
    {
        if(isActive)
        {
            // print(2);
            StopDrag();
        }
    }

    private void StopDrag()
    {
        isDragging = false;
        if (isTrash)
        {
            switch (gameObject.tag)
            {
                case "Wall":
                    GameManager.NumWalls++;
                    break;
                case "Magnet":
                    GameManager.NumMagnets++;
                    break;
                case "Vent":
                    GameManager.NumVents++;
                    break;
            }

            RotateItems.cur = null;
            ValuesManager.UpdateQuants();
            Destroy(gameObject);
        }
    }
}
