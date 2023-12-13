using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.Collections.Generic;
using System;


[RequireComponent(typeof(ToggleGroup))]
public class MenuToggleGroup : MonoBehaviour
{
    private ToggleGroup menuToggleGroup;
    private string selectedLevel;

    public string SelectedLevel
    {
        get { return selectedLevel; }
        private set { selectedLevel = value; }
    }

    private int selectedLevel_Index;

    public int SelectedLevel_Index
    {
        get { return selectedLevel_Index; }
        private set { selectedLevel_Index = value; }
    }

    private void Start()
    {
        menuToggleGroup = GetComponent<ToggleGroup>();
    }
    
    public void ReportLevelClicked(bool newValue)
    {
        if (newValue == true)
        {
            selectedLevel = menuToggleGroup.ActiveToggles().FirstOrDefault().name;
            if (Char.IsNumber(selectedLevel, 0) && Char.IsNumber(selectedLevel, 1))
            {
                selectedLevel_Index = int.Parse(selectedLevel.Substring(0, 2));
                Debug.Log(selectedLevel_Index);
            }
            else
            {
                selectedLevel_Index = int.Parse(selectedLevel.Substring(0, 1));
            }            
        }
    }
}