using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalTouchDown : MonoBehaviour
{
    [SerializeField] private bool Victory = false;
    [SerializeField] public GameObject WinMenu;
    [SerializeField] public GameObject ScriptHome;

    void Update() {
        if(this.Victory)
        {
            this.WinMenu.SetActive(true);
            this.ScriptHome.SetActive(false);
            Cursor.visible = true;
            return;
        }
        this.WinMenu.SetActive(false);
    }

    void OnCollisionEnter(Collision hit) 
    {
        Debug.Log("hit " + hit.collider.gameObject.name);
        if(hit.gameObject.tag.Equals("Player"))
        {
            Debug.Log("it's HIM!");
        }
    }

    void OnControllerColliderHit(ControllerColliderHit hit){
        if(hit.gameObject.tag.Equals("Player"))
        {
            Debug.Log("it's HIM!");
        }
    }

    public void Touched()
    {
        Debug.Log("It really is HIM!");
        this.Victory = true;
    }

    public bool Win()
    {
        return this.Victory;
    }
}
