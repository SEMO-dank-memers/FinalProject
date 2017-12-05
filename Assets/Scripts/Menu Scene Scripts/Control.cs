using UnityEngine;
using UnityEngine.SceneManagement;

public class Control : MonoBehaviour
{
    public void NextScene()
    {
		SceneManager.LoadScene("Main");//change to the specified scene
    }
}