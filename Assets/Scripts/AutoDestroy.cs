using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    public float delay;
    void Start()
    {
        Invoke(nameof(SelfDestroy), delay);
    }

    private void SelfDestroy()
    {
        Destroy(gameObject);
    }
}
