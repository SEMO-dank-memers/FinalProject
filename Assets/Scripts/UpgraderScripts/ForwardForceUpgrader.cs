using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ForwardForceUpgrader : MonoBehaviour {
	[Tooltip("The rock (ZippyTerrain2D Ball)")]
	public GameObject player; 
	private static int upgradeLevel; //the number of upgrades bought for ForwardForce
	[Tooltip("Place the upgrade lights in order into these sockets")]
	public Image[] Lights = new Image[5]; //array to store the images corresponding to the upgrade "lights" in the gui
	private Color c = Color.blue;
	private Color y = Color.yellow;
	private static int requiredMoney = 80; 
	public Text thisButton;

	void Start(){
		if (upgradeLevel != 5) { //if we aren't max level set up the upgrade lights based off of the current upgrade level and display the cost of the next level
			int temp = upgradeLevel;
			while (temp > 0) {
				Lights [temp - 1].color = c;
				temp--;
			}
			thisButton.text = "Forward Force: " + requiredMoney;
		} else { // if we are max level set up the upgrade lights to be all yellow and simply display the name of the upgrade
			int temp = upgradeLevel;
			while (temp > 0) {
				Lights [temp - 1].color = y;
				temp--;
			}
			thisButton.text = "Forward Force";	
		}
	}

	public void UpgradeForwardPushLevel(){
		if ((playerStats.playerMoney >= requiredMoney) && (upgradeLevel != 5)) {
			playerStats.currentForwardPushForce *= 1.5f; //multiply the old value of our forward push force by 1.5 to get the new upgraded value
			playerStats.playerMoney -= requiredMoney; //remove the money from the player
			upgradeLevel++; //keeps track of the current number of upgrades bought
			Lights[upgradeLevel-1].color = c;
			requiredMoney = requiredMoney * 2; //increase the amount of money needed for the next upgrade
			if (upgradeLevel != 5) {
				thisButton.text = "Forward Force: " + requiredMoney;
			} else { // if we have reached max level with this purchase change the text and color of the upgrade lights to reflect that
				int temp = upgradeLevel;
				while (temp > 0) {
					Lights [temp - 1].color = y;
					temp--;
				}
				thisButton.text = "Forward Force";
			}
		}
	}
}
