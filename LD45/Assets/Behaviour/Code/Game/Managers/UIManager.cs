using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] float letterTime = .05f;

    static public UIManager ui;

    void Awake() { ui = this; }

    [SerializeField] GameObject consolePanel;
    [SerializeField] TextMeshProUGUI console;

    bool breakOut = false;
    
    IEnumerator UpdateConsoleText(string text)
    {
        breakOut = false;

        string displayText = "";

        foreach (var letter in text.Reverse())
        {
            if (breakOut) { breakOut = false; yield break; }

            displayText = letter + displayText;
            console.text = displayText;

            yield return new WaitForSeconds(letterTime);
        }

        //console.text = text;
    }

    //void UpdateConsoleText(string text)
    //{
    //    console.text = text;
    //}

    public void Console(bool show, string text = "")
    {
        consolePanel.SetActive(show);

        if (show) StartCoroutine(UpdateConsoleText(text));
        else { breakOut = true; console.text = ""; }
    }
}