using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ColliderEventSender : MonoBehaviour
{
    [SerializeField]
    protected string CollideTag = "Player";

    public UnityEvent onCollisionEnterEvent;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(CollideTag))
        {

            if (onCollisionEnterEvent != null)
            {
                onCollisionEnterEvent.Invoke();
            }
        }
    }
}
