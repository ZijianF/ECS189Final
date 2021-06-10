using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellController : MonoBehaviour
{
    //Vector3 shellVelocity;
    int force;
    Vector3 direction;


    //To be called before the Fly function
    public void SetFields(int f, Vector3 dir) { force = f; direction = dir; }

    public void Fly()
    {
        //Debug.Log("in shell controller" + force + " " + direction);
        this.gameObject.GetComponent<Rigidbody>().AddForce(force * direction);
    }
}
