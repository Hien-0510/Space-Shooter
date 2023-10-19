using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackround : MonoBehaviour
{
    public float speed;
    public float spacing;
    public float cameraSize;
    private float lowerBound;
    private float jumpDistance;
    private void Start(){
        lowerBound = -cameraSize - spacing / 2 ;
        jumpDistance = spacing * 2 ;
    }
    void Update()
    {
        transform. Translate(0, -Time.deltaTime*speed, 0);
        if(transform.position.y < lowerBound){
            Vector2 newPos = transform.position;
            newPos.y = transform.position.y + jumpDistance;
            transform.position = newPos;
        }
    }
}
