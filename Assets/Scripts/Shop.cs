using UnityEngine;

public class Shop : MonoBehaviour {

    BuildManager bm;

    void Start() {
        bm = BuildManager.instance;
    }

    public void PurchaseStandardTurret() {
        Debug.Log("Standard turret Purchased");
        bm.setTurretToBuild(bm.turretPrefab);
    }

    public void PurchaseOther() {
        Debug.Log("Other turret");
        bm.setTurretToBuild(bm.otherPrefab);
    }
}
