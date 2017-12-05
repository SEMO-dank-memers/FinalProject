using UnityEngine;
using UnityEngine.SceneManagement;

public class ContributorController : MonoBehaviour {
    public void NextScene()
    {
		SceneManager.LoadScene("Contributors");//change to the specified scene
    }
}
