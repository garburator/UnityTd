using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    private bool canMove = true;

    public float panSpeed = 30f;
    public float borderBuffer = 15f;
    public float scrollSpeed = 5f;
    public float minY = 10f;
    public float maxY = 100f;

	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape)) canMove = !canMove;
        if (!canMove) return;

        ProcessMovement();

        float scroll = Input.GetAxis("Mouse ScrollWheel");

        if (scroll != 0f) {
            Vector3 pos = transform.position;
            pos.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;
            pos.y = Mathf.Clamp(pos.y, minY, maxY);
            transform.position = pos;
        }
	}

    void ProcessMovement() {
        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - borderBuffer) {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("s") || Input.mousePosition.y <= borderBuffer) {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("a") || Input.mousePosition.x <= borderBuffer) {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - borderBuffer) {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }
    }
}
