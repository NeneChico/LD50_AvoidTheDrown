using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    public float Health = 100f;

    // Update is called once per frame
    public void Damage(float damageAmount)
    {
        Health -= damageAmount;
    }
}
