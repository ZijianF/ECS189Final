using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField] GameObject Muzzle;
    [SerializeField] GameObject Gun; //will be changed to aimed position
    [SerializeField] GameObject EjectionPort;
    [SerializeField] GameObject EjectionDirPoint;
    [SerializeField] Vector3 bulletDirection;
    [SerializeField] Vector3 shellDirection;
    Animator anim;

    [SerializeField] BulletType type;
    [SerializeField] int gunSelection = 0;
    [SerializeField] int magSize;
    int currMagsize;
    BulletFactory bulletFactory;
    ShellFactory shellFactory;

    Vector3 scaleFactor = Vector3.one;

    // Start is called before the first frame update
    void Awake()
    {
        //Default bullet direction
        bulletDirection = Muzzle.transform.position - Gun.transform.position;
        bulletDirection = bulletDirection.normalized;

        //Ejection can be randomized by choosing multiple dirpoints
        shellDirection = EjectionDirPoint.transform.position - EjectionPort.transform.position;
        shellDirection = shellDirection.normalized;

        bulletFactory = gameObject.GetComponent<BulletFactory>();
        shellFactory = gameObject.GetComponent<ShellFactory>();
        try
        {
            anim = gameObject.GetComponent<Animator>();
        }
        catch (MissingComponentException) { anim = null; }
        GameObject go = this.gameObject;
        int i = 0;

        //The loop is supposed to find the global scale of a child of Gun object
        do
        {
            i++;
            scaleFactor = new Vector3(
                go.transform.localScale.x * scaleFactor.x,
                go.transform.localScale.y * scaleFactor.y,
                go.transform.localScale.z * scaleFactor.z);
            go = go.transform.parent.gameObject;
        } while (!go.tag.Equals("Player") && i < 100);
        if (go.tag.Equals("Player"))
            Debug.Log("Found blake");
        currMagsize = magSize;

    }
    Bullet GetBulletSpec()
    {
        Bullet spec = new Bullet(BulletType.Handgun, -1, -1, 0);
        switch (gunSelection)
        {
            case 0:
                spec = new HandgunBullet(BulletType.Handgun, 1, 1, 100, bulletDirection);
                break;

            case 1:
                spec = new ShotGunBullet(BulletType.Shotgun, 10, 1, 100, bulletDirection);
                break;
            case 2:
                spec = new RifleBullet(BulletType.Rifle, 1, 1, 100, bulletDirection, 400);
                break;

        }
        return spec;

    }

    Shell GetShellSpec()
    {
        Shell shell = new Shell(BulletType.Handgun, -1, new Vector3(0, 0, 0));
        switch (gunSelection)
        {

            case 0:
                shell = new Shell(BulletType.Handgun, 1000, shellDirection);
                break;

            case 1:

                shell = new Shell(BulletType.Shotgun, 60, shellDirection);
                break;
            case 2:

                shell = new Shell(BulletType.Rifle, 40, shellDirection);
                break;

        }
        return shell;
    }

    public int CurrentAmmo()
    {
        return currMagsize;
    }
    public void Reload()
    {

        currMagsize = magSize;
    }

    //Shoot will be called by character controller scripts living on the character
    //holding a reference to this Gun object
    public void Shoot()
    {
        if (anim)
            anim.SetBool("Fire", false);
        if (Input.GetKeyDown("r"))
        {

            currMagsize = magSize;
        }

        Bullet bulletSpec = GetBulletSpec();
        Shell shellSpec = GetShellSpec();
        if (anim)
            anim.SetBool("Fire", true);

        GameObject[] bullet = bulletFactory.Build(false,
           Muzzle.transform.position
            , bulletSpec);
        GameObject shell = shellFactory.Build(false,
            EjectionPort.transform.position, shellSpec);

        //Every bullet will need to be scaled and prepare to interact in global
        for (int i = 0; i < bulletSpec.amount; i++)
        {
            bullet[i].transform.SetParent(this.transform, true);
            bullet[i].transform.localScale = new Vector3(
            bullet[i].transform.localScale.x * gameObject.transform.localScale.x,
            bullet[i].transform.localScale.y * gameObject.transform.localScale.y,
            bullet[i].transform.localScale.z * gameObject.transform.localScale.z);

            //to disjoin the instantiated bullet and this gun
            bullet[i].transform.parent = null;
            var bulletController = bullet[i].GetComponent<BulletController>();
            bulletController.Fire();
        }
        shell.transform.SetParent(this.transform, true);
        shell.transform.localScale = new Vector3(
        shell.transform.localScale.x * gameObject.transform.localScale.x,
        shell.transform.localScale.y * gameObject.transform.localScale.y,
        shell.transform.localScale.z * gameObject.transform.localScale.z);
        shell.transform.parent = null;
        var shellController = shell.GetComponent<ShellController>();
        shellController.Fly();
    }


    //Renewing the bullet direction based on the focus point global tramsform position
    public void RenewDirection(Vector3 position)
    {
        if (position.x == position.y && position.y == position.z && position.x == -1)
        {
            bulletDirection = Muzzle.transform.position - Gun.transform.position;
        }
        bulletDirection = position - Muzzle.gameObject.transform.position;
        bulletDirection = bulletDirection.normalized;
    }

}