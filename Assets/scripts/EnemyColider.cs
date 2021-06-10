using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyColider : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject Parent;
    
    void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag.Equals("Bullet"))
        {
            Debug.Log("I'm hit by bullet");
            Parent.gameObject.GetComponent<EnemyController>().TakeDamage();
        }
    }
}
