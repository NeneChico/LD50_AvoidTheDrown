using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Resize the game object of this component (clamped scale to 0) 
public class Resizer : MonoBehaviour
{
    [SerializeField]
    protected float resizeSpeed = 1f;

    [SerializeField]
    protected Vector3 resizeDelta;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Resize the game object of this component (clamped scale to 0) 
    void Update()
    {
        if(gameObject.transform.localScale.x > 0 && gameObject.transform.localScale.y > 0 && gameObject.transform.localScale.z >0)
            gameObject.transform.localScale += resizeDelta * resizeSpeed * Time.deltaTime;
    }
}
