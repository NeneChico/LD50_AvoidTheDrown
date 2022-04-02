using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Resize the game object of this component
public class Resizer : MonoBehaviour
{
    public GameObject ResizedObject;

    public float ResizeSpeed = 1f;

    public Vector3 ResizeDelta;

    private void Start()
    {
        if (ResizedObject == null)
        {
            ResizedObject = gameObject;
        }
    }

    // Resize the game object of this component (clamped scale to 0) 
    void Update()
    {
        if(ResizedObject.transform.localScale.x > 0 && ResizedObject.transform.localScale.y > 0 && ResizedObject.transform.localScale.z >0)
            ResizedObject.transform.localScale += ResizeDelta * ResizeSpeed * Time.deltaTime;
    }

}
