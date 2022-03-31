using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AddTurret : MonoBehaviour
{
    [SerializeField] private Button turretButton;
    [SerializeField] private TMP_Text buttonText;
    [SerializeField] private BoxCollider2D allowedArea;
    private GameObject turret;
    private bool isTurretPlaced;

    void Start() {
        turretButton.onClick.AddListener(() => {
            //Debug.Log("Turret Button Clicked");
            isTurretPlaced = false;
            StartCoroutine(TurretPlacer());
        });
    }

    void Update() {
        
    }
    
    private IEnumerator TurretPlacer() {
        //Debug.Log("Turret Placer Started");
        yield return null;
        buttonText.text = "Click Again To Place Turret";
        //Debug.Log("Waited one frame");
        GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
        while(!isTurretPlaced) {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 2;
            //Debug.Log("Mouse Position: " + mousePos);
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
            //Debug.Log("World Position Updated: " + worldPos);
            // allowedArea.OverlapPoint(worldPos)
            if (Input.GetMouseButtonDown(0) && mousePos.x >= 996f && mousePos.x <= 1910f && mousePos.y >= 143f && mousePos.y <= 910f) {
                turret = (GameObject)Instantiate(turretToBuild, worldPos, transform.rotation);
                //Debug.Log("Turret Instantiated");
                isTurretPlaced = true;
                //Debug.Log("Turret placed");
            }
            yield return null;
        }
        //Debug.Log("Turret Placer Ended");
        buttonText.text = "Add New Turret";
    }
}
