using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Resize the game object of this component
public class Resizer : MonoBehaviour
{
    public GameObject ResizedObject;

    protected Vector3 initalResizedObjectScale;

    public float ResizeSpeed = 1f;

    public Vector3 ResizeDelta;

    private void Awake()
    {
        if (ResizedObject == null)
        {
            ResizedObject = gameObject;
        }
        initalResizedObjectScale = new Vector3(ResizedObject.transform.localScale.x,
                                                ResizedObject.transform.localScale.y,
                                                ResizedObject.transform.localScale.z);
    }

    // Resize the game object of this component (clamped scale to 0) 
    void Update()
    {
        if(ResizedObject.transform.localScale.x > 0 && ResizedObject.transform.localScale.y > 0 && ResizedObject.transform.localScale.z >0)
            ResizedObject.transform.localScale += ResizeDelta * ResizeSpeed * Time.deltaTime;
    }

    public void ResetSize()
    {
        ResizedObject.transform.localScale = initalResizedObjectScale;
    }

}
