using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcefiedManager : MonoBehaviour
{

    [SerializeField]
    protected float entropy = 0.1f;

    [SerializeField]
    protected float FloatAmplitude = 2;

    [SerializeField]
    protected float FloatSpeed;

    [SerializeField]
    protected float DivingScaleSize = 5f;

    // emerging management
    protected Vector3 emergeVelocity = Vector3.zero;
    protected float emergeSpeedSeconds = 1f;

    // floating management
    protected float tempFloatVal;
    protected Vector3 tempPos;

    // diving management
    protected Vector3 diveVelocity = Vector3.zero;
    protected float diveSpeedSeconds = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        // randomize size
        gameObject.transform.localScale -= new Vector3(Random.Range(entropy, entropy*2), 0, Random.Range(entropy, entropy*2));

        // randomize melt
        Resizer resizer = gameObject.GetComponentInChildren<Resizer>();
        resizer.ResizedObject = this.gameObject;

        // prepare floating movement
        tempFloatVal = transform.position.y;

        // TODO: start food spawner
        // TODO: start enemy spawner

    }

    // Update is called once per frame
    void Update()
    {
        // dive ?
        if (gameObject.transform.localScale.x <= DivingScaleSize)
        {
            Debug.Log($"Diving {gameObject}");
            Vector3 targetPosition = new Vector3(gameObject.transform.position.x, -3, gameObject.transform.position.z);
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref diveVelocity, diveSpeedSeconds);
        }
        else
        {
            // emerge
            if (transform.position.y < 0)
            {
                Debug.Log($"Emerging {gameObject}");
                Vector3 targetPosition = new Vector3(gameObject.transform.position.x, 0, gameObject.transform.position.z);
                transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref emergeVelocity, emergeSpeedSeconds);
            }
            else
            {
                // TODO: tilt from player weight
                // TODO: move to player direction

                // floating movement
                tempPos.y = tempFloatVal + FloatAmplitude * Mathf.Sin(FloatSpeed * Time.time);
                transform.position = tempPos;
            }
        }
    }
}
