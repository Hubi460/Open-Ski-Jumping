﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using CompCal;

public class JumpersCreatorListUI : ListDisplay
{
    public DatabaseManager databaseManager;
    public FlagsData flagsData;
    public TMPro.TMP_InputField lastNameInput;
    public TMPro.TMP_InputField firstNameInput;
    public TMPro.TMP_InputField countryCodeInput;
    public SimpleColorPicker helmetColorPicker;
    //     public string suitTopFrontColor;
    // public string suitTopBackColor;
    // public string suitBottomFrontColor;
    // public string suitBottomBackColor;
    public SimpleColorPicker suitTopFrontColorPicker;
    public SimpleColorPicker suitTopBackColorPicker;
    public SimpleColorPicker suitBottomFrontColorPicker;
    public SimpleColorPicker suitBottomBackColorPicker;
    public SimpleColorPicker skisColorPicker;
    // public TMPro.TMP_Dropdown genderDropdown;

    public bool updated;
    private bool initialized;

    public List<Competitor> competitorsList;
    private void LoadJumpersData(out List<Competitor> tmpList)
    {
        tmpList = new List<Competitor>();
        if (databaseManager.dbCompetitors.Loaded) { tmpList = databaseManager.dbCompetitors.Data; }
    }



    public override void ListInit()
    {
        LoadJumpersData(out competitorsList);
        foreach (var competitor in competitorsList) { AddListElement(NewListElement(competitor)); }
        updated = false;
        initialized = true;
    }
    public GameObject NewListElement(Competitor competitor)
    {
        GameObject tmp = Instantiate(elementPrefab);
        SetValue(tmp, competitor);
        return tmp;
    }

    public void SetValue(GameObject tmp, Competitor competitor)
    {
        tmp.GetComponentsInChildren<TMPro.TMP_Text>()[0].text = competitor.firstName + " " + competitor.lastName.ToUpper();
        tmp.GetComponentsInChildren<TMPro.TMP_Text>()[1].text = competitor.countryCode;
        tmp.GetComponentsInChildren<Image>()[1].sprite = flagsData.GetFlag(competitor.countryCode);
    }
    public override void ShowElementInfo(int index)
    {
        firstNameInput.text = competitorsList[index].firstName;
        lastNameInput.text = competitorsList[index].lastName;
        countryCodeInput.text = competitorsList[index].countryCode;
        // Debug.Log("SHOWING: " + competitorsList[index].helmetColor + " " + competitorsList[index].suitTopFrontColor + " " + competitorsList[index].skisColor);
        helmetColorPicker.Set(competitorsList[index].helmetColor);
        suitTopFrontColorPicker.Set(competitorsList[index].suitTopFrontColor);
        suitTopBackColorPicker.Set(competitorsList[index].suitTopBackColor);
        suitBottomFrontColorPicker.Set(competitorsList[index].suitBottomFrontColor);
        suitBottomBackColorPicker.Set(competitorsList[index].suitBottomBackColor);
        skisColorPicker.Set(competitorsList[index].skisColor);
        // genderDropdown.value = (int)(competitorsList[index].gender);

    }
    public void Add()
    {
        Competitor competitor = new Competitor("LastName", "FirstName", "XXX", Gender.Male, 2001, 1, 1);
        competitorsList.Add(competitor);
        AddListElement(NewListElement(competitor));
        updated = false;
    }

    public void Save()
    {
        competitorsList[currentIndex].lastName = lastNameInput.text;
        competitorsList[currentIndex].firstName = firstNameInput.text;
        competitorsList[currentIndex].countryCode = countryCodeInput.text;
        competitorsList[currentIndex].helmetColor = helmetColorPicker.ToHex;
        competitorsList[currentIndex].suitTopFrontColor = suitTopFrontColorPicker.ToHex;
        competitorsList[currentIndex].suitTopBackColor = suitTopBackColorPicker.ToHex;
        competitorsList[currentIndex].suitBottomFrontColor = suitBottomFrontColorPicker.ToHex;
        competitorsList[currentIndex].suitBottomBackColor = suitBottomBackColorPicker.ToHex;
        competitorsList[currentIndex].skisColor = skisColorPicker.ToHex;
        // Debug.Log(competitorsList[currentIndex].helmetColor + " " + competitorsList[currentIndex].suitColor + " " + competitorsList[currentIndex].skisColor);
        Debug.Log("SAVED COMPETITOR DATA");
        // competitorsList[currentIndex].gender = (Gender)genderDropdown.value;
        SetValue(elementsList[currentIndex], competitorsList[currentIndex]);
        updated = false;
    }

    public void Delete()
    {
        competitorsList.RemoveAt(currentIndex);
        DeleteListElement();
        updated = false;
    }
}
