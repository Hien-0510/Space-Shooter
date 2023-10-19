using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Suicide : MonoBehaviour
{
    // Start is called before the first frame update
    public EnemyHealth health;
    public bool destroyOnCrash;
    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.TryGetComponent(out PlayerHealth playerHealth))
        {
            playerHealth.Die();
            if(destroyOnCrash){
                health.Die();
            }
        }
    }
}
