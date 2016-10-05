using UnityEditor;
using UnityEngine;

public class Tools : MonoBehaviour{

    public int width = 16;
    public int height = 16;
    public GameObject nodePrefab;

    // Use this for initialization
    void Start() {
        GameObject node;
        //get the spacing.
        float nodeWidth = nodePrefab.transform.localScale.x + 1;
        float nodeheight = nodePrefab.transform.localScale.z + 1;
        for (int i = 0; i < this.width; i++) {
            for (int j = 0; j < this.height; j++) {
                node = Instantiate(nodePrefab, gameObject.transform) as GameObject;
                node.transform.position = new Vector3(i * nodeWidth, 0, j * nodeheight);
            }
        }
    }
}
