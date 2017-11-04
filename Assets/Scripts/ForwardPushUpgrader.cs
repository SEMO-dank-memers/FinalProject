using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ForwardPushUpgrader : MonoBehaviour {
	public GameObject player; 
	private static int upGradeLevel;
	public Image[] Lights = new Image[5];
	private Color c = Color.blue;
	private static int requiredMoney = 80; 
	public Text thisButton;

	void Start(){
		
		int temp = upGradeLevel;
		while (temp > 0) {
			Lights [temp - 1].color = c;
			temp--;
		}
		thisButton.text = "Forward Push: " + requiredMoney;
	}

	public void UpgradeForwardPushLevel(){
		if (player.GetComponent<ZippyTerrain2DRollingBall> ().playerMoney >= requiredMoney) {
			player.GetComponent<ZippyTerrain2DRollingBall> ().forwardPushLevel = player.GetComponent<ZippyTerrain2DRollingBall> ().forwardPushLevel + 1;
			playerStats.currentForwardPushLevel = playerStats.currentForwardPushLevel + 1;
			upGradeLevel++;
			Lights[upGradeLevel-1].color = c;
			requiredMoney = requiredMoney * 2;
			thisButton.text = "Forward Push: " + requiredMoney;
		}
	}
}
