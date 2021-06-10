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
        directions = new Vector3[amt];
        for (int i = 0; i < amt; i++)
        {
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

