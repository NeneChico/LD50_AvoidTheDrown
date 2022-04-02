using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Resize the game object of this component
public class Resizer : MonoBehaviour
{
    [SerializeField]
    protected GameObject resizedObject;

    public float ResizeSpeed = 1f;

    public Vector3 ResizeDelta;

    private void Start()
    {
        if (resizedObject == null)
        {
            resizedObject = gameObject;
        }
    }

    // Resize the game object of this component (clamped scale to 0) 
    void Update()
    {
        if(gameObject.transform.localScale.x > 0 && gameObject.transform.localScale.y > 0 && gameObject.transform.localScale.z >0)
            gameObject.transform.localScale += ResizeDelta * ResizeSpeed * Time.deltaTime;
    }

}
