using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ForwardPushUpgrader : MonoBehaviour {
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
		thisButton.text = "Forward Pushs: " + requiredMoney;
	}

	public void UpgradeForwardPushLevel(){
		if (playerStats.playerMoney >= requiredMoney) {
			playerStats.currentForwardPushLevel += 1;
			playerStats.playerMoney -= requiredMoney;
			upgradeLevel++;
			Lights[upgradeLevel-1].color = c;
			requiredMoney = requiredMoney * 2;
			thisButton.text = "Forward Pushs: " + requiredMoney;

		}
	}
}
