using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BulletType
{
    Handgun,
    Shotgun,
    Rifle
}

public class Bullet
{
    public Bullet(BulletType bt, int amt, int dmg, int f)
    {
        bulletType = bt; amount = amt; force = f;
    }
    public BulletType bulletType;
    public int amount;
    public int damage;
    public int force;
}
public class HandgunBullet : Bullet
{

    public HandgunBullet(BulletType bt, int amt, int dmg, int f, Vector3 dir)
        : base(bt, amt, dmg, f)

    {
        direction = dir;
    }
    public Vector3 direction;

}

public class ShotGunBullet : Bullet
{

    public Vector3[] directions;
    public ShotGunBullet(BulletType bt, int amt, int dmg, int f, Vector3 dir)
        : base(bt, amt, dmg, f)

    {
        //move the normalized dir to align with x axis
        //rotate and clear z axis
        Vector3 tmp_dir;
        float az = Mathf.Atan(dir.z / dir.x) * Mathf.Rad2Deg;

        Debug.Log("old direction" + dir);
        tmp_dir = Quaternion.Euler(new Vector3(0, az, 0)) * dir;
        Debug.Log("new xy direction" + tmp_dir);

        float ay = Mathf.Atan(dir.y / dir.x) * Mathf.Rad2Deg;
        tmp_dir = Quaternion.Euler(new Vector3(0, 0, ay)) * tmp_dir;
        Debug.Log("new x direction" + tmp_dir);
        directions = new Vector3[amt];
        for (int i = 0; i < amt; i++)
        {
            float radius = Random.Range(0.0f, 1.0f);
            float angle = Random.Range(0.0f, 360.0f);

            //to be randomized
            directions[i] = dir;
        }
    }
}

public class RifleBullet : Bullet
{

    public RifleBullet(BulletType bt, int amt, int dmg, int f, Vector3 dir, float rpm)
        : base(bt, amt, dmg, f)

    {
        RPM = rpm;
        direction = dir;
    }
    public float RPM;
    public Vector3 direction;
}

public class Shell
{
    public Shell(BulletType bt, int f, Vector3 dir)
    {
        bulletType = bt; force = f; direction = dir;
    }
    public Vector3 direction;
    public BulletType bulletType;
    public int force;

}

