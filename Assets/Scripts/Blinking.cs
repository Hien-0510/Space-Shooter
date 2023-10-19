using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blinking : MonoBehaviour
{
    public Renderer renderer;

    // Update is called once per frame
    void Update() => renderer.enabled = !renderer.enabled;
}
