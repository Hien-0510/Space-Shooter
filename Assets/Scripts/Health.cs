using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public GameObject explosionPrefabs;
    public int maxHealthPoint;
    public UnityEvent onDie;
    private int healthPoint;

    private void Start() => healthPoint = maxHealthPoint;

    public void TakeDamage(int damage){
        healthPoint -= damage;
        if(healthPoint <= 0){
            Die();
        }
    }

    public void Die(){
        GameObject explosion = Instantiate(explosionPrefabs, transform.position, transform.rotation);
        Destroy(gameObject);
        onDie.Invoke();
    }
}

