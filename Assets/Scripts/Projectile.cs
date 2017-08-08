using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // time before shot expires
    public float shotTime = 1.2f;

    private Rigidbody2D rigid2D;

    // Use this for initialization
    void Start()
    {
        // get the rigidbody of the projectile
        rigid2D = GetComponent<Rigidbody2D>();
        // destroy projectile after set time
        Destroy(gameObject, shotTime);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vel = rigid2D.velocity;
        float angle = Mathf.Atan2(vel.y, vel.x);
        rigid2D.rotation = angle * Mathf.Rad2Deg;
    }
}
