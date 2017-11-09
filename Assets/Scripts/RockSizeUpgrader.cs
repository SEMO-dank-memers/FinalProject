using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RockSizeUpgrader : MonoBehaviour {
	[Tooltip("The rock (ZippyTerrain2D Ball)")]
	public GameObject player; 
	private static int upgradeLevel;
	[Tooltip("Place the upgrade lights in order into these sockets")]
	public Image[] Lights = new Image[5];
	private Color c = Color.blue;
	private static int requiredMoney = 80; 
	public Text thisButton;

	void Start(){

		int temp = upgradeLevel;
		while (temp > 0) {
			Lights [temp - 1].color = c;
			temp--;
		}
		thisButton.text = "Rock Size: " + requiredMoney;
	}

	public void UpgradeRockSize(){
		if (playerStats.playerMoney >= requiredMoney) {
			playerStats.playerSize = new Vector3(playerStats.playerSize.x+0.45f, playerStats.playerSize.y+0.45f, playerStats.playerSize.z);
			playerStats.playerMoney -= requiredMoney;
			upgradeLevel++;
			Lights[upgradeLevel-1].color = c;
			requiredMoney = requiredMoney * 2;
			thisButton.text = "Rock Size: " + requiredMoney;

		}
	}
}
