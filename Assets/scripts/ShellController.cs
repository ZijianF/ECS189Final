using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellController : MonoBehaviour
{
    Vector3 shellVelocity;
    int force;
    Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKey("w") || Input.GetKey("s") ||
            Input.GetKey("d") || Input.GetKey("a"))
        {
            shellVelocity = gameObject.GetComponent<Rigidbody>().velocity;
            gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        }
        else
        {
            //gameObject.GetComponent<Rigidbody>().velocity = shellVelocity;

        }

    }
    private void OnCollisionExit(Collision collision)
    {
        //Destroy(gameObject);
        //Destroy(this);
    }

    public void SetFields(int f, Vector3 dir) { force = f; direction = dir; }
    public void Fly()
    {

        Debug.Log("in shell controller" + force + " " + direction);
        this.gameObject.GetComponent<Rigidbody>().AddForce(force * direction);
    }
}
