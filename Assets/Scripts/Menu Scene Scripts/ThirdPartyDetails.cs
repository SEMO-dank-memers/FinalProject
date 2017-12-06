using UnityEngine;
using UnityEngine.SceneManagement;

public class ThirdPartyDetails : MonoBehaviour {
	public void NextScene()
	{
		SceneManager.LoadScene("Third Party Details");//change to the specified scene
	}
}
