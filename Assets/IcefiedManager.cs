using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcefiedManager : MonoBehaviour
{

    [SerializeField]
    protected float sizeEntropy = 0.1f;

    [SerializeField]
    protected float resizeEntropy = 0.1f;


    // Start is called before the first frame update
    void Start()
    {
        // randomize size
        gameObject.transform.localScale += new Vector3(Random.Range(1 - sizeEntropy, 1 + sizeEntropy), 1, Random.Range(1 - sizeEntropy, 1 + sizeEntropy));

        // randomize melt
        Resizer resizer = gameObject.GetComponentInChildren<Resizer>();
        resizer.ResizeDelta = new Vector3(Random.Range(1 - resizeEntropy, 1 + resizeEntropy), 1, Random.Range(1 - resizeEntropy, 1 + resizeEntropy));
        resizer.ResizeSpeed = Random.Range(1 - resizeEntropy, 1 + resizeEntropy);

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
    }
}
