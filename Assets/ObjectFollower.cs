using UnityEngine;
using System.Collections;


public class ObjectFollower : MonoBehaviour
{
    public GameObject followedObject;

    private Vector3 offset;

	[Tooltip("Check to keep the actual position and rotation offset")]
	public bool useOffset = false;

    // Use this for initialization
    void Start()
    {
        this.offset = this.transform.position - followedObject.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        this.transform.position = followedObject.transform.position;
		if(useOffset)
			this.transform.position += this.offset;
			// this.transform.rotation unchanged
		else
			this.transform.rotation = followedObject.transform.rotation;
    }
}
