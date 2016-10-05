using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour {

    public Color hoverColor;
    private Renderer rend;
    private Color color;

    private GameObject turret;
    public Vector3 turretOffset;

	// Use this for initialization
	void Start () {
        this.rend = GetComponent<Renderer>();
        this.color = this.rend.material.color;
	}

    void OnMouseDown() {
        if (BuildManager.instance.getTurretToBuild() == null || EventSystem.current.IsPointerOverGameObject()) {
            return;
        }

        if (turret != null) {
            Debug.Log("Cant build here, something already exists! TODO: Display on screen.");
            return;
        }

        //Build a turret
        GameObject turretToBuild = BuildManager.instance.getTurretToBuild();
        Turret tur = turretToBuild.GetComponent<Turret>();

        if (BuildManager.instance.Purchase(tur.cost)) {
            this.turret = (GameObject)Instantiate(turretToBuild, transform.position + turretOffset, transform.rotation);
        }
    }

    void OnMouseEnter() {
        //Skip if no turret to build or pointer over ui.
        if (BuildManager.instance.getTurretToBuild() == null || EventSystem.current.IsPointerOverGameObject()) {
            return;
        }
        this.rend.material.color = this.hoverColor;
    }

    void OnMouseExit() {
        rend.material.color = this.color;
    }
}
