using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcefiedManager : MonoBehaviour
{

    [SerializeField]
    protected float entropy = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        // randomize size
        gameObject.transform.localScale -= new Vector3(Random.Range(entropy, entropy*2), 0, Random.Range(entropy, entropy*2));

        // randomize melt
        Resizer resizer = gameObject.GetComponentInChildren<Resizer>();
        resizer.ResizedObject = this.gameObject;

        // TODO: start tangle

        // TODO: start food spawner
        // TODO: start enemy spawner

    }

    // Update is called once per frame
    void Update()
    {
        // TODO: tangle from wave
        // TODO: tangle from player
        // TODO: move

        if(gameObject.transform.localScale.x <= 0.01f)
        {
            Destroy(gameObject);
        }
    }
}
