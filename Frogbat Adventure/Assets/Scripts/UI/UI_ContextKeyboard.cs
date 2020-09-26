using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_ContextKeyboard : UI_ContextAction
{
    public TextMeshProUGUI StringTarget;
    public List<TextMeshProUGUI> StringList;
    bool CapsLock = true;
    int fileIndex = 0;

    protected override void Awake()
    {
        base.Awake();
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
    }

    protected override void OnDisable()
    {
        base.OnDisable();
    }

    protected override void OnEnable()
    {
        base.OnEnable();
    }

    public override void OnCancel()
    {
        //base.OnCancel()
        if (StringTarget.text.Length > 0)
        {
            string text = StringTarget.text;
            text = text.Remove(text.Length - 1);
            StringTarget.text = text;
        } 
        else if (StringTarget.text.Length == 0)
        {
            MenuMan.ToggleMenu(null, false);
            StringTarget.text = "Frobat"; 
        }
    }

    public void ToggleCaps()
    {
        CapsLock = !CapsLock;
        foreach(TextMeshProUGUI TMProObj in StringList)
        {
            if (CapsLock) TMProObj.text = TMProObj.text.ToUpper();
            else TMProObj.text = TMProObj.text.ToLower();
        }
    }

    public void AddLetter(string Letter)
    {
        string _new = Letter;

        if (CapsLock) _new = _new.ToUpper();
        else _new = _new.ToLower();

        if (StringTarget.text.Length < 16) 
            StringTarget.text += _new;
    }

    public void SendFileData(TextMeshProUGUI FileNameText)
    {
        MenuMan.SubmitFileName(FileNameText.text , fileIndex);
    }
    
    public void SetFileIndex(int _FileIndex)
    {
        fileIndex = _FileIndex;
    }

}
