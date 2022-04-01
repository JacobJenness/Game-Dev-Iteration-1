using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBehavior : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform bulletSpawn;
    [SerializeField] private float fireRate;
    [SerializeField] private float turnSpeed;
    [SerializeField] private float range;
    [SerializeField] private CircleCollider2D rangeCollider;
    [SerializeField] private Transform bulletTransform;
    private GameObject target;
    private float lastShot = 0;

    void Awake() {
        rangeCollider.radius = range;
        //Debug.Log("Turret Range: " + range);
    }

    // Update is called once per frame
    void Update()
    {
        //FindClosestEnemy();
        // if(target != null) {
        //     TurnToTarget(Input.mousePosition);
        //     Shoot();
        // }
        TurnToTarget(Input.mousePosition);
        if (Input.GetMouseButton(0) && (lastShot > fireRate)) {
            Shoot();
            lastShot = 0;
        }
        lastShot += Time.deltaTime;
    }

    private void TurnToTarget(Vector3 targetPosition) {
        // Turn the turret towrds the mouse (or a target)
        // Vector3 mousePosition = Input.mousePosition;
        targetPosition.z = 2;
        //Debug.Log("Target Position: " + targetPosition);
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(targetPosition);
        Vector2 direction = worldPosition - transform.position;
        float angle = Vector2.SignedAngle(Vector2.up, direction);
        Vector3 targetRotation = new Vector3(0, 0, angle);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(targetRotation), turnSpeed * Time.deltaTime);
    }

    private void Shoot() {
        GameObject newBullet = Instantiate(bullet);
        //Vector3 newBulletPosition = new Vector3(bulletSpawn.transform.position.x, bulletSpawn.transform.position.y, 0);
        // Set the bullet's position
        newBullet.transform.SetPositionAndRotation(bulletSpawn.transform.position, bulletSpawn.rotation);
    }

    private GameObject FindClosestEnemy() {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject closestEnemy = null;
        float closestDistance = range;
        foreach (GameObject enemy in enemies) {
            float distanceToEnemy = Vector2.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < closestDistance) {
                closestDistance = distanceToEnemy;
                closestEnemy = enemy;
            }
        }
        return closestEnemy;
    }
}
