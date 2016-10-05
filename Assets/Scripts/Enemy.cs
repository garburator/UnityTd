using UnityEngine;

public class Enemy : MonoBehaviour {

    public float speed = 8f;
    public float distanceError = 0.4f;
    public float health = 100f;
    public int value = 10;
    private Transform target;
    private int nodeIndex = 0;
    private Vector3 dir;
    

	// Use this for initialization
	void Start () {
        this.target = Waypoints.nodes[nodeIndex];
        this.nodeIndex++;
        this.dir = this.target.position - transform.position;
	}
	
	void Update() {
        transform.Translate(this.dir.normalized * this.speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, this.target.position) <= this.distanceError) {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint() {
        if (this.nodeIndex >= Waypoints.nodes.Length) {
            EnemyScore();
        }
        else {
            this.target = Waypoints.nodes[nodeIndex];
            this.nodeIndex++;
            this.dir = this.target.position - transform.position;
        }
    }

    void EnemyScore() {
        WinCondition.ReachedObjective();
        Destroy(gameObject);
    }

    public void TakeDamage(float damage) {
        this.health -= damage;
        if (this.health <= 0) {
            BuildManager.instance.Deposit(value);
            Destroy(gameObject);
        }
    }


}
