using UnityEngine;
using System.Collections;

public class Turret : MonoBehaviour {

    private Transform target;
    private float fireCountDown = 0f;

    [Header("Attributes")]
    public float range = 15f;
    public float rotationSpeed = 15f;
    public float fireRate = 1f;
    public float damage = 5f;
    public int cost = 10;

    [Header("Unity Fields")]
    public Transform rotator;
    public string enemyTag = "Enemy";
    public GameObject bulletPrefab;
    public Transform firePoint;

    // Use this for initialization
    void Start () {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
	}

    void UpdateTarget() {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(this.enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach(GameObject enemy in enemies) {
            float distToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distToEnemy < shortestDistance) {
                shortestDistance = distToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range) {
            target = nearestEnemy.transform;
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (target == null) return;

        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(this.rotator.rotation, lookRotation, Time.deltaTime * this.rotationSpeed).eulerAngles;

        this.rotator.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        this.fireCountDown -= Time.deltaTime;
        if (this.fireCountDown <= 0f) {
            Shoot();
            fireCountDown = 1f / this.fireRate;
        }
	}

    void Shoot() {
        GameObject bulletObj = (GameObject) Instantiate(this.bulletPrefab, this.firePoint.position, this.firePoint.rotation);
        Bullet bullet = bulletObj.GetComponent<Bullet>();
        
        if (bullet != null) {
            bullet.Seek(target, this.damage);
        }
    }

    void OnDrawGizmosSelected() {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
