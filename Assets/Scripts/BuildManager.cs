using UnityEngine;
using UnityEngine.UI;

public class BuildManager : MonoBehaviour {

    private GameObject turretToBuild;
    public static BuildManager instance;
    public GameObject turretPrefab;
    public GameObject otherPrefab;

    public Text moneyText;

    public int money = 20;

    void Awake() {
        //make sure there is never more than one buildManager
        if (instance == null) instance = this;
        TextUpdate();
    }

    public GameObject getTurretToBuild() {
        return this.turretToBuild;
    }

    public void setTurretToBuild(GameObject turret) {
        this.turretToBuild = turret;
    }

    public bool Purchase(int cost) {
        if (money >= cost) {
            money -= cost;
            TextUpdate();
            return true;
        }
        else {
            return false;
        }
    }

    public void Deposit(int value) {
        money += value;
        TextUpdate();
    }

    private void TextUpdate() {
        moneyText.text = money.ToString();
    }
}
