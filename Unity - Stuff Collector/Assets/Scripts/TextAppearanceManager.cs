using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TextAppearanceManager : MonoBehaviour {


    int index;
    bool isActive = true;

    private void Start()
    {
        index = 0;
    }

    public void TextAppeareance(Text text, Text textShadow, char[] sentence)
    {
        if (index < sentence.Length)
        {
            if (isActive)
                StartCoroutine(TextDisplayer(text, textShadow, sentence));
        }
    }

    IEnumerator TextDisplayer(Text text, Text textShadow, char[] sentence)
    {
        text.text += sentence[index];
        textShadow.text += sentence[index];
        index++;
        isActive = false;
        yield return new WaitForSecondsRealtime(0.05f);
        isActive = true;
    }

    public void ResetTextAppeareance(Text text, Text textShadow)
    {
        text.text = "";
        textShadow.text = "";
        index = 0;
    }

    public int Index
    {
        get
        {
            return index;
        }

        set
        {
            index = value;
        }
    }
}
