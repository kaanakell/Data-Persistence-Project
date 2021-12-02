using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public Text highScoreText;
    public int highScore;
    public string newName;
    public InputField input;


    private void Start()
    {
        SecondManager.Instance.LoadHighScore();

        newName = SecondManager.Instance.newName;
        highScore = SecondManager.Instance.highScore;

        if(SecondManager.Instance.highScore != 0)
        {
            highScoreText.text = "Best Score : " + newName + " : " + highScore;

            Debug.Log(Application.persistentDataPath);
        }
    }

    /*public void NewNameSelected(string name)
    {
        SecondManager.Instance.newName = name;
    }*/

    public void StartGame()
    {
        SecondManager.Instance.oldName = input.text;
        Debug.Log("entered name: " + SecondManager.Instance.oldName);
    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void Back()
    {
        SceneManager.LoadScene(0);
    }

    public void Exit()
    {
        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else

            Application.Quit(); //original code to quit Unity player

        #endif

    }

}
