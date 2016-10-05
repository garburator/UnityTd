using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    private Transform target;
    public GameObject impactEffect;
    public float speed = 70f;
    private float damage;

    public void Seek(Transform target, float damage) {
        this.target = target;
        this.damage = damage;
    }
	
	// Update is called once per frame
	void Update () {
	    if (target == null) {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distThisFrame) {
            HitTarget();
        }
        else {
            transform.Translate(dir.normalized * distThisFrame, Space.World);
        }
	}

    void HitTarget() {
        GameObject targ = this.target.gameObject;
        targ.GetComponent<Enemy>().TakeDamage(this.damage);
        Destroy((GameObject) Instantiate(this.impactEffect, transform.position, transform.rotation), 2f);
        Destroy(gameObject);
    }
}
