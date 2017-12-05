using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UpwardPushUpgrader : MonoBehaviour {
	[Tooltip("The rock (ZippyTerrain2D Ball)")]
	public GameObject player; 
	private static int upgradeLevel; // keep track of our current UpwardPush level
	[Tooltip("Place the upgrade lights in order into these sockets")]
	public Image[] Lights = new Image[5]; // array of the images corresponding to the upgrade lights
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
			thisButton.text = "Upward Pushs: " + requiredMoney;
		} else {
			int temp = upgradeLevel;
			while (temp > 0) {
				Lights [temp - 1].color = y;
				temp--;
			}
			thisButton.text = "Upward Pushs";
		}
	}

	public void UpgradeForwardPushLevel(){
		if ((playerStats.playerMoney >= requiredMoney) && (upgradeLevel != 5)) {
			playerStats.currentUpwardPushLevel += 1; //increase our static push level by one, this value is multiplied with our initial value of 3 to get our total number of pushes
			playerStats.playerMoney -= requiredMoney; // remove the money cost of the upgrade
			upgradeLevel++;
			Lights [upgradeLevel - 1].color = c;
			requiredMoney = requiredMoney * 2;
			//set up the text and upgrade lights based off of our current level
			if (upgradeLevel != 5) {
				thisButton.text = "Upward Pushs: " + requiredMoney;
			} else {
				int temp = upgradeLevel;
				while (temp > 0) {
					Lights [temp - 1].color = y;
					temp--;
				}
				thisButton.text = "Upward Pushs";
			}
		}
	}
}
