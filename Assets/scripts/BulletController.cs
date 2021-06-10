using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    int force, damage;
    Vector3 direction;

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag.Equals("Enemy"))
        {
            //Debug.Log("Hit Enemy");
            collision.transform.SendMessage("TakeDamage", SendMessageOptions.DontRequireReceiver);

        }
        Destroy(this.gameObject);
    }

    //To be called before the fire function
    public void SetFields(int f, Vector3 dir, int d) { force = f; direction = dir; damage = d; }

    public void Fire()
    {

        gameObject.GetComponent<Rigidbody>().AddForce(force * direction);

    }
}
