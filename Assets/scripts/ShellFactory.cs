using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellFactory : MonoBehaviour
{
    [SerializeField] GameObject handgunShell;
    [SerializeField] GameObject shotgunShell;
    void OnEnable()
    {
        //foreach (GameObject go in Resources.FindObjectsOfTypeAll(typeof(GameObject)) as GameObject[])
        //{
        //    if (go.name.Equals("HandGunBS"))
        //    {

        //        handgunShell = go;
        //        //shotgunShell = go;
        //    }

        //}
        //handgunShell = Resources.Load("HandGunBS") as GameObject;
    }

    public GameObject Build(bool random, Vector3 position, Shell sh)
    {
        GameObject shell = null;
        if (!random)
        {
            if (sh.bulletType == BulletType.Handgun)
            {
                shell = Instantiate<GameObject>(handgunShell, position, Quaternion.identity);
                var controller = shell.GetComponent<ShellController>();

                Debug.Log("in shell factory" + sh.force + " " + sh.direction);
                controller.SetFields(sh.force, sh.direction);

            }

            if (sh.bulletType == BulletType.Shotgun)
            {
                shell = Instantiate<GameObject>(shotgunShell, position, Quaternion.identity);
                var controller = shell.GetComponent<ShellController>();
                controller.SetFields(sh.force, sh.direction);

            }
        }
        if (shell == null)
            Debug.LogError("Shell Build Failed");
        return shell;
    }

}
