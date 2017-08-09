using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float projectileSpeed = 20f;
    public float recoil = 30f;
    // Minimum time between shots
    public float shotDelay = 0.1f;

    private float shotTimer = 0f;
    private Rigidbody2D rigid;

    // Use this for initialization
    void Start()
    {
        // Get rigidbody to apply recoil later
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        shotTimer += Time.deltaTime;
        // If we can shoot again and space was just pressed
        if (Input.GetKeyDown(KeyCode.Space) && shotTimer >= shotDelay)
        {
            Shoot();
            shotTimer = 0f;
        }
    }

    void Shoot()
    {
        // Instantiate and add force to a projectile
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        Rigidbody2D projectileRigid = projectile.GetComponent<Rigidbody2D>();
        projectileRigid.AddForce(transform.right * projectileSpeed, ForceMode2D.Impulse);
        // Apply recoil to player
        rigid.AddForce(-transform.right * recoil, ForceMode2D.Impulse);
    }
}
