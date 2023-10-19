using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Route : MonoBehaviour
{
    public Transform[] waypoints;
    public Vector2 this[int index] => waypoints[index].position;

    private void OnDrawGizmos(){
        for (int i = 0; i < waypoints.Length; i++){
            Gizmos.DrawSphere(this[i], 0.2f);
                if(i>0){
                    Gizmos.DrawLine(this[i], this[i-1]);
                }
        }
    }
}
