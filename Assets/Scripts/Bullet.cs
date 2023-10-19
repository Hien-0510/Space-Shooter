using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    // Update is called once per frame
    public GameObject explosionPrefabs;   
    public int damage; 
    void Update()
    {
        transform.Translate(0,speed * Time.deltaTime,0);
        if(transform.position.y>6f){
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.TryGetComponent(out Health health))
        {
            health.TakeDamage(damage);
        }
        Explode();
    }

    private void Explode(){
        Destroy(gameObject);
            GameObject explosion = Instantiate(explosionPrefabs,transform.position,transform.rotation);
            Destroy(explosion,1f);
    }
}
