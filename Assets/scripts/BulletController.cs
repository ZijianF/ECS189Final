using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    int force, damage;
    Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        // Debug.Log("Bullet Position" + gameObject.transform.position);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Debug.Log("Hit " + collision.gameObject.name);

        if(collision.gameObject.tag.Equals("Enemy"))
        {
            Debug.Log("Hit Enemy");
            collision.transform.SendMessage("TakeDamage", SendMessageOptions.DontRequireReceiver);

        }
        Destroy(this.gameObject);
    }

    public void SetFields(int f, Vector3 dir, int d) { force = f; direction = dir; damage = d; }
    public void Fire()
    {

        gameObject.GetComponent<Rigidbody>().AddForce(force * direction);

    }
}
