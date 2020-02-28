using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuScript : MonoBehaviour
{
    public TMP_InputField inputNbAsteroids;
    public TMP_InputField inputSceneSize;

    // Gets the inputs values and starts a new game (by loading the GameScene)
    public void StartGame()
	{
        CrossSceneInformation.nbAsteroids = int.Parse(inputNbAsteroids.text);
        CrossSceneInformation.sceneSize = (float)int.Parse(inputSceneSize.text);

        SceneManager.LoadScene("GameScene");
    }
}
