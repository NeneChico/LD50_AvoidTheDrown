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
    protected float emergeTime = 1f;

    // floating management
    protected float tempFloatVal;
    protected Vector3 tempPos;

    // diving management
    protected Vector3 diveVelocity = Vector3.zero;
    protected float diveTime = 0.5f;

    // moving to playermanagement
    protected Vector3 targetPosition = Vector3.zero;
    protected Vector3 targetVelocity = Vector3.zero;
    protected bool targetReached = false;

    [SerializeField]
    protected string PlayerTag = "Player";

    [SerializeField][Range(0.1f,1f)]
    protected float speed = 0.25f;


    // Start is called before the first frame update
    void Start()
    {
        // randomize size
        gameObject.transform.localScale -= new Vector3(Random.Range(entropy, entropy*2), 0, Random.Range(entropy, entropy*2));
        gameObject.transform.Rotate(new Vector3(0, Random.Range(-entropy, entropy) * 360, 0));

        // randomize melt
        Resizer resizer = gameObject.GetComponentInChildren<Resizer>();
        resizer.ResizedObject = this.gameObject;

        // prepare floating movement
        tempFloatVal = transform.position.y;

        // prepare to move to player position at start time
        Vector3 playerPosition = GameObject.FindGameObjectWithTag(PlayerTag).transform.position;
        targetPosition = new Vector3(playerPosition.x, 0, playerPosition.z);

        // TODO: start food spawner
        // TODO: start enemy spawner

    }

    // Update is called once per frame
    void Update()
    {
        // dive ?
        if (gameObject.transform.localScale.x <= DivingScaleSize)
        {
            //Debug.Log($"Diving {gameObject.name}");
            Vector3 divePosition = new Vector3(gameObject.transform.position.x, -3, gameObject.transform.position.z);
            transform.position = Vector3.SmoothDamp(transform.position, divePosition, ref diveVelocity, diveTime);
            
            /*FIXME
            if(transform.position == divePosition) // desactivate object for spawners
                gameObject.SetActive(false);
            */
        }
        else
        {
            // emerge
            if (transform.position.y < 0)
            {
                //Debug.Log($"Emerging {gameObject.name}");
                Vector3 emergePosition = new Vector3(gameObject.transform.position.x, 0, gameObject.transform.position.z);
                transform.position = Vector3.SmoothDamp(transform.position, emergePosition, ref emergeVelocity, emergeTime);
            }
            else
            {
                // move to player direction
                if (!targetReached)
                {
                    Debug.Log($"Moving {gameObject.name} to player");
                    Vector3 playePosition = new Vector3(gameObject.transform.position.x, 0, gameObject.transform.position.z);
                    transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref targetVelocity, 1 / speed);
                }

                // TODO: tilt from player weight

                // floating movement
                tempPos.y = tempFloatVal + FloatAmplitude * Mathf.Sin(FloatSpeed * Time.time);
                transform.position = tempPos;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("Collision enter:" + collision);
        if (collision.gameObject.CompareTag(PlayerTag))
        {
            Debug.Log($"Emerging {gameObject.name} player reached");
            targetReached = true;
        }
    }
}
