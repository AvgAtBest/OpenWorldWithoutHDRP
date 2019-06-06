using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 35f;
    public GameObject bulletHolePrefab;
    public Transform line;

    private Rigidbody rigid;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        line.transform.rotation = Quaternion.LookRotation(rigid.velocity);
    }
    private void OnCollisionEnter(Collision collision)
    {

        //Spawn Decals
        ContactPoint contact = collision.contacts[0];
        Instantiate(bulletHolePrefab, contact.point, Quaternion.LookRotation(contact.normal));

        Destroy(gameObject);
    }
    public void Fire(Vector3 lineOrigin, Vector3 direction)
    {
        line.transform.position = lineOrigin;
        rigid.AddForce(direction * speed, ForceMode.Impulse);
    }
}
