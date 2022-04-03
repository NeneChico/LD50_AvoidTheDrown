using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcefiedManager : MonoBehaviour
{

    [SerializeField]
    protected float sizeEntropy = 0.1f;

    [SerializeField]
    protected float resizeEntropy = 0.1f;

    [SerializeField]
    protected float FloatAmplitude;

    [SerializeField]
    protected float FloatSpeed;
    
    protected float tempFloatVal;

    protected Vector3 tempPos;

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
        // TODO: tilt from player weight
        // TODO: move to player direction

        if(gameObject.transform.localScale.x <= 0.01f)
        {
            Destroy(gameObject);
        }

        // floating movement
        tempPos.y = tempFloatVal + FloatAmplitude * Mathf.Sin(FloatSpeed * Time.time);
        transform.position = tempPos;
    }
}
