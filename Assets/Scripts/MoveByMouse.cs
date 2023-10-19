using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveByMouse : MonoBehaviour
{

    public Camera mainCamera;
    // Update is called once per frame
    void Update()
    {
        Vector2 worldPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);

        transform.position = worldPosition;

        //print(worldPosition);
    }
}
