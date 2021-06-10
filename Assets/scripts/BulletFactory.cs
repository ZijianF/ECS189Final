using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BulletFactory : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] int forceFactor;

    void OnEnable()
    {
        // foreach (GameObject go in Resources.FindObjectsOfTypeAll(typeof(GameObject)) as GameObject[])
        // {
        //     if (go.name.Equals("HandGunBullet"))
        //         bullet = go;
        // }
        // bullet = Resources.Load("HandGunBullet") as GameObject;
        //Object prefab = this.AssetDatabase.LoadAssetAtPath("Assets/GameObject.prefab", typeof(GameObject));
    }

    public GameObject[] Build(bool random, Vector3 position, Bullet bt)
    {
        GameObject[] ball = new GameObject[1];
        if (!random)
        {
            if (bt.bulletType == BulletType.Handgun)
            {

                HandgunBullet btVar = (HandgunBullet)bt;
                ball = new GameObject[bt.amount];
                for (int i = 0; i < bt.amount; i++)
                {

                    ball[i] = Instantiate<GameObject>(bullet, position, Quaternion.identity);//, gameObject.transform);
                    ball[i].transform.forward = btVar.direction;
                    var controller = ball[i].GetComponent<BulletController>();
                    controller.SetFields(btVar.force * forceFactor, btVar.direction, btVar.damage);

                }
            }

            if (bt.bulletType == BulletType.Shotgun)
            {

                ShotGunBullet btVar = (ShotGunBullet)bt;
                ball = new GameObject[bt.amount];
                for (int i = 0; i < bt.amount; i++)
                {

                    ball[i] = Instantiate<GameObject>(bullet, position, Quaternion.identity);//, gameObject.transform);

                    ball[i].transform.forward = btVar.directions[i];
                    var controller = ball[i].GetComponent<BulletController>();
                    controller.SetFields(btVar.force * forceFactor, btVar.directions[i], btVar.damage);
                }

            }
        }

        return ball;
    }
}