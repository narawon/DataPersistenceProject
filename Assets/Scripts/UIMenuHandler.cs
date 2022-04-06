using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

#if UNITY_EDITOR
using UnityEditor;
#endif

[DefaultExecutionOrder(10000)]
public class UIMenuHandler : MonoBehaviour
{

    [SerializeField] private TMP_Text bestScoreText;
    [SerializeField] private TMP_InputField nameInput;
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Showing the loaded data to UI");
        string bestPlayerName = DataManager.Instance.bestPlayerName;
        string playerName = DataManager.Instance.playerName;
        int bestScore = DataManager.Instance.bestScore;
        bestScoreText.text = "Best Score by " + bestPlayerName + " : " + bestScore;
        nameInput.text = playerName;
        


    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OnEnterNameField()
    {
        
        string name = nameInput.text;
        //Debug.Log("Player Name was Entered: " + name);
        DataManager.Instance.playerName = name;
    }

    public void OnClickStart()
    {
        SceneManager.LoadScene("Main");
    }

    public void OnClickExit()
    {
        DataManager.Instance.SaveData();

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
