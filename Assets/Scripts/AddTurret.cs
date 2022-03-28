using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddTurret : MonoBehaviour
{
    [SerializeField] private Button turretButton;

    void Start() {
        turretButton.onClick.AddListener(() => {
            GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
        });
    }
}
