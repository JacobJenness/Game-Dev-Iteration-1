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
    private GameObject target;

    void Awake() {
        rangeCollider.radius = range;
        Debug.Log("Turret Range: " + range);
    }

    // Update is called once per frame
    void Update()
    {
        if(target != null) {
            TurnToTarget(target.transform.position);
            Shoot();
        }
    }

    private void TurnToTarget(Vector3 targetPosition) {
        // Turn the turret towrds the mouse (or a target)
        // Vector3 mousePosition = Input.mousePosition;
        targetPosition.z = 2;
        Debug.Log("Target Position: " + targetPosition);
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(targetPosition);
        Vector2 direction = worldPosition - transform.position;
        float angle = Vector2.SignedAngle(Vector2.up, direction);
        Vector3 targetRotation = new Vector3(0, 0, angle);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(targetRotation), turnSpeed * Time.deltaTime);
    }

    // function to set target to first enemy that enters a radius of the turret
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Enemy") {
            Debug.Log("Enemy entered turret");
            target = other.gameObject;
        }
    }

    // function to set target to null when enemy leaves a radius of the turret
    private void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "Enemy") {
            Debug.Log("Enemy left turret");
            target = null;
        }
    }

    private void Shoot() {
        Debug.Log("Shoot");
        Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
    }
}
