using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RoutingAgent : MonoBehaviour
{
    public Route route;
    public float flySpeed;
    public float delay;
    public float smoothTime;
    private Vector2 velocity;

    public bool bossLoop;

    private GameObject rabbit;

    private void Start(){
        rabbit = new GameObject();
        rabbit.transform.position = route[0]; 
        transform.position = route[0];
        Invoke(nameof(StartFlying),delay);
    }
    private void StartFlying(){

        Sequence seq =  DOTween.Sequence();
        for(int i=1; i< route.waypoints.Length; i++)
        { 
            MoveTo(seq, i - 1 , i);
        }
        if(bossLoop){
            MoveTo(seq, route.waypoints.Length - 1, 0);
        }
        seq.OnComplete(OnRoutingFinished);
    }

    private void MoveTo(Sequence seq,int from, int to){
        float distance = Vector2.Distance(route[to],route[from]);
            seq.Append(rabbit.transform
            .DOMove(route[to], distance/flySpeed)
            .From(route[from])
            .SetEase(Ease.Linear)
            );
    }

    private void OnRoutingFinished(){
            if(bossLoop){
                StartFlying();
            }
            else {
                Destroy(gameObject);
            }
    }

    private void Update(){
        LookAtTheRabbit();
        transform.position = Vector2.SmoothDamp(transform.position,rabbit.transform.position, ref velocity, smoothTime);
    }

    private void LookAtTheRabbit(){
        Vector2 direction = rabbit.transform.position - transform.position;
        float angle = Vector2.SignedAngle(Vector2.down, direction);
        transform.rotation = Quaternion.Euler(0,0,angle);
    }
}
