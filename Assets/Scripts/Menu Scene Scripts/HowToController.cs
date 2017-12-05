using UnityEngine;
using UnityEngine.SceneManagement;

public class HowToController : MonoBehaviour {

    public void NextScene()
    {
		SceneManager.LoadScene("How To Play");//change to the specified scene
    }
}
