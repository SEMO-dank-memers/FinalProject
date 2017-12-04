using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitialForceUpgrader : MonoBehaviour {
	[Tooltip("The rock (ZippyTerrain2D Ball)")]
	public GameObject player; 
	private static int upgradeLevel;
	[Tooltip("Place the upgrade lights in order into these sockets")]
	public Image[] Lights = new Image[5];
	private Color c = Color.blue;
	private Color y = Color.yellow;
	private static int requiredMoney = 80; 
	public Text thisButton;

	void Start(){
		if (upgradeLevel != 5) {
			int temp = upgradeLevel;
			while (temp > 0) {
				Lights [temp - 1].color = c;
				temp--;
			}
			thisButton.text = "Initial Force: " + requiredMoney;
		} else {
			int temp = upgradeLevel;
			while (temp > 0) {
				Lights [temp - 1].color = y;
				temp--;
			}
			thisButton.text = "Initial Force";
		}
	}

	public void UpgradeInitialForceLevel(){
		if ((playerStats.playerMoney >= requiredMoney) && (upgradeLevel != 5)) {
			playerStats.playerMoney -= requiredMoney;
			playerStats.initialForce += 5.0f;
			upgradeLevel++;
			Lights[upgradeLevel-1].color = c;
			requiredMoney = requiredMoney * 2;
			if (upgradeLevel != 5) {
				thisButton.text = "Initial Force: " + requiredMoney;
			} else {
				int temp = upgradeLevel;
				while (temp > 0) {
					Lights [temp - 1].color = y;
					temp--;
				}
				thisButton.text = "Initial Force";
			}
		}
	}
}
