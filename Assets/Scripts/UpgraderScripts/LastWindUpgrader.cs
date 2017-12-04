using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LastWindUpgrader : MonoBehaviour {
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
			thisButton.text = "Last Wind: " + requiredMoney;
		} else {
			int temp = upgradeLevel;
			while (temp > 0) {
				Lights [temp - 1].color = y;
				temp--;
			}
			thisButton.text = "Last Wind";
		}
	}

	public void UpgradeLastWindLevel(){
		if ((playerStats.playerMoney >= requiredMoney) && (upgradeLevel != 5)) {
			playerStats.playerMoney -= requiredMoney;
			playerStats.lives += 1;
			upgradeLevel++;
			Lights[upgradeLevel-1].color = c;
			requiredMoney = requiredMoney * 2;
			if (upgradeLevel != 5) {
				thisButton.text = "Last Wind: " + requiredMoney;
			} else {
				int temp = upgradeLevel;
				while (temp > 0) {
					Lights [temp - 1].color = y;
					temp--;
				}
				thisButton.text = "Last Wind";
			}
		}
	}
}
