using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float BulletTimeFactor;

    [SerializeField] private GameObject Player;

    [SerializeField] private GameObject Target;

    [SerializeField] private float RotationSpeed = 0.5f;

    [SerializeField] private float SpawnRadius = 3.0f;

    [SerializeField] private GameObject Head;

    [SerializeField] private int Health = 1;

    [SerializeField] private bool Dead = false;

    [SerializeField] private bool ShowBot = false;

    [SerializeField] GameObject Gun1;

    [SerializeField] private float FireGapTime = 0.5f;

    private bool CanFire = true;

    private float CD = 0.0f;

    private bool InLineOfSight = false;

    private Animator animator;

    private EnemyGunController GunController;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        Vector3 spawnLocation = new Vector3(this.gameObject.transform.position.x + SpawnRadius * Random.Range(0f, SpawnRadius) * (Random.Range(0, 2) * 2 - 1), 0f, this.gameObject.transform.position.z + SpawnRadius * Random.Range(0f, SpawnRadius) * (Random.Range(0, 2) * 2 - 1));
        this.transform.position = spawnLocation;
        GunController = Gun1.GetComponent<EnemyGunController>();
    }

    void Update()
    {
        
        this.InLineOfSight = false;
        if (this.Dead)
        {
            animator.SetBool("Exit", true);
            return;
        }
        RaycastHit hit;
        var rayDirection = Target.transform.position - Head.transform.position;
        Debug.DrawRay(Head.transform.position, rayDirection * 10.0f, Color.blue);
        if (Physics.Raycast(Head.transform.position, rayDirection, out hit))
        {
            bool hitPlayer = false;
            float hitDistance = Mathf.Sqrt(
                Mathf.Pow((Target.transform.position.x - hit.point.x), 2.0f) +
                Mathf.Pow((Target.transform.position.y - hit.point.y), 2.0f) +
                Mathf.Pow((Target.transform.position.z - hit.point.z), 2.0f)
            );
            if (hitDistance < 0.4)
            {
                this.InLineOfSight = true;
                Debug.DrawRay(Head.gameObject.transform.position, rayDirection * 10000f, Color.yellow);
            }
            else
            {
                this.InLineOfSight = false;
                Debug.DrawRay(Head.gameObject.transform.position, rayDirection * 10000f, Color.red);
            }
        }

        if (this.InLineOfSight)
        {
            Vector3 direction = rayDirection.normalized;
            Quaternion lookRotation = Quaternion.LookRotation(rayDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * RotationSpeed);
            GunController.RenewDirection(hit.point);

        }
        if (this.ShowBot)
        {
            return;
        }
        
        if(this.InLineOfSight)
        {
            if(CanFire)
            {
                Debug.Log("Shooting");
                this.GunController.Shoot();
                this.CanFire = false;
            }
        }

        this.CD += Time.deltaTime;
        if(CD > FireGapTime)
        {
            this.CanFire = true;
            this.CD = 0;
        }

    }

    public void TakeDamage()
    {
        this.Health -= 1;
        if (this.Health <= 0)
        {
            EnterDeathAnimation();
            this.Dead = true;
            
        }
    }
    private void EnterDeathAnimation()
    {
        if (ShowBot)
        {
            animator.SetBool("Dead", true);
        }
        else
        {
            animator.SetBool("Dead", true);
        }
    }
}
