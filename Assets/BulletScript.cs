using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField] private Transform bulletTransform;
    [SerializeField] private float bulletSpeed;

    void Start()
    {
        StartCoroutine(MoveBullet());
    }

    private IEnumerator MoveBullet() {
        while(true) {
            bulletTransform.Translate(Vector3.up * bulletSpeed * Time.deltaTime);
            yield return null;
        }
    }
}
