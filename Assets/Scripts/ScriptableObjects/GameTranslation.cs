using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class Wrapper
{
    public StringVariable label;
    public string text;
}

[CreateAssetMenu]
public class GameTranslation : ScriptableObject
{
    [SerializeField]
    private List<Wrapper> labelsList;
    [SerializeField]
    private UnityEvent onLabelsReplace;

    public void SetLabels()
    {
        foreach (var item in labelsList)
        {
            Debug.Log(item.text);
            item.label.Value = item.text;
        }
        
        onLabelsReplace.Invoke();
    }
}