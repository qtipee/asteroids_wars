using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScene : MonoBehaviour
{
    public TextMeshProUGUI score;

    private void Start()
    {
        score.text = "Vous avez un score de : " + CrossSceneInformation.score.ToString();
    }

    public void TryAgain()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
