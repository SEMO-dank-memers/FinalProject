using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MoneyMultiplierUpgrader : MonoBehaviour {
	[Tooltip("The rock (ZippyTerrain2D Ball)")]
	public GameObject player; 
	private static int upgradeLevel; // keep track of our current MoneyMultiplier level
	[Tooltip("Place the upgrade lights in order into these sockets")]
	public Image[] Lights = new Image[5]; // array of images corresponding to the upgrade lights
	private Color c = Color.blue;
	private Color y = Color.yellow;
	private static int requiredMoney = 80; 
	public Text thisButton;

	void Start() {
		//set up the upgrade lights depending on our current upgradeLevel
		if (upgradeLevel != 5) {
			int temp = upgradeLevel;
			while (temp > 0) {
				Lights [temp - 1].color = c;
				temp--;
			}
			thisButton.text = "Money Multiplier: " + requiredMoney;
		} else{
			int temp = upgradeLevel;
			while (temp > 0) {
				Lights [temp - 1].color = y;
				temp--;
			}
			thisButton.text = "Money Multiplier";		
		}
	}

	public void UpgradeMoneyMultiplier() {
		if ((playerStats.playerMoney >= requiredMoney) && (upgradeLevel != 5)) {
			playerStats.playerMoney -= requiredMoney; //remove the money cost of the upgrade
			upgradeLevel++;
			Lights [upgradeLevel - 1].color = c;
			requiredMoney = requiredMoney * 2;
			playerStats.moneyMultiplier = upgradeLevel + 1; // increase the moenyMultiplier value, we multiply this by the initial value of each coin (2) and add that amount to player money each time a coin is picked up
			//set up the text and upgrade lights based off of our current level
			if (upgradeLevel != 5) {
				thisButton.text = "Money Multiplier: " + requiredMoney;
			} else {
				int temp = upgradeLevel;
				while (temp > 0) {
					Lights [temp - 1].color = y;
					temp--;
				}
				thisButton.text = "Money Multiplier";
			}
		}
	}
}
