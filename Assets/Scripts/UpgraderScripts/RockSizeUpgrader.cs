using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RockSizeUpgrader : MonoBehaviour {
	[Tooltip("The rock (ZippyTerrain2D Ball)")]
	public GameObject player; 
	private static int upgradeLevel; // keep track of our current RockSize level
	[Tooltip("Place the upgrade lights in order into these sockets")]
	public Image[] Lights = new Image[5]; // array of images corresponding to the upgrade lights
	private Color c = Color.blue;
	private Color y = Color.yellow;
	private static int requiredMoney = 80; 
	public Text thisButton;

	void Start(){
		//set up the upgrade lights depending on our current upgradeLevel
		if (upgradeLevel != 5) {
			int temp = upgradeLevel;
			while (temp > 0) {
				Lights [temp - 1].color = c;
				temp--;
			}
			thisButton.text = "Rock Size: " + requiredMoney;
		} else {
			int temp = upgradeLevel;
			while (temp > 0) {
				Lights [temp - 1].color = y;
				temp--;
			}
			thisButton.text = "Rock Size";
		}
	}

	public void UpgradeRockSize(){
		if ((playerStats.playerMoney >= requiredMoney) && (upgradeLevel != 5)) {
			playerStats.playerSize = new Vector3(playerStats.playerSize.x+0.45f, playerStats.playerSize.y+0.45f, playerStats.playerSize.z); //increase the size of the rock by increaseing the y and x value of our playerSize vector
			playerStats.playerMoney -= requiredMoney; // remove the money cost of the upgrade
			upgradeLevel++;
			Lights[upgradeLevel-1].color = c;
			requiredMoney = requiredMoney * 2;
			//set up the text and upgrade lights based off of our current level
			if (upgradeLevel != 5) {
				thisButton.text = "Rock Size: " + requiredMoney;
			} else {
				int temp = upgradeLevel;
				while (temp > 0) {
					Lights [temp - 1].color = y;
					temp--;
				}
				thisButton.text = "Rock Size";
			}
		}
	}
}
