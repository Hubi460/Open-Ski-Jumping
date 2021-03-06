﻿using System;
using System.Collections.Generic;
using UnityEngine;

using CompCal;
using UnityEngine.Events;

public class CompetitionManager : MonoBehaviour
{
    public SkiJumperData currentJumper;
    public DatabaseManager databaseManager;
    // public JumpUIManager jumpUIManager;
    public JudgesController judges;

    private CompCal.EventInfo currentEvent;
    private RoundRunner roundRunner;
    private EventProcessor eventManager;

    public FloatVariable leaderPoints;
    public FloatVariable currentJumperPoints;
    public CompetitorVariable competitorVariable;
    public CompetitorVariable competitorVariable2;
    public CompCal.ResultsDatabase resultsContainer;
    public Calendar calendar;
    public UnityEventInt jumperPreparation;

    private int jumperIt;

    private void LoadData()
    {
        resultsContainer = databaseManager.dbSaveData.savesList[databaseManager.dbSaveData.currentSaveId].resultsContainer;
        calendar = databaseManager.dbSaveData.savesList[databaseManager.dbSaveData.currentSaveId].calendar;
    }

    private void EventManagerInit()
    {
        // EventProcessor eventManager = new EventProcessor(resultsContainer.eventIt, calendar, resultsContainer);
    }

    public void CompetitionInit()
    {
        LoadData();
        EventManagerInit();

        // judges.PrepareHill(calendarResults.hillProfiles[calendarResults.calendar.events[calendarResults.eventIt].hillId]);
    }

    public void RoundInit()
    {
        // calendarResults.RoundInit();
    }

    public bool NextJump()
    {
        // Update Scriptable Objects

        jumperIt++;

        // calendarResults.jumpIt++;
        //     if (calendarResults.jumpIt < calendarResults.CurrentStartList.Count)
        //     {
        //         CompCal.Competitor comp = calendarResults.CurrentCompetitor;
        //         currentJumper.Set(comp);
        //         int bib = calendarResults.CurrentEventResults.bibs[calendarResults.CurrentStartList[calendarResults.jumpIt]][calendarResults.roundIt];
        //         currentJumperPoints.Value = (float)calendarResults.CurrentEventResults.totalResults[calendarResults.CurrentStartList[calendarResults.jumpIt]];

        //         if (calendarResults.CurrentEventResults.allroundResults.Count > 0)
        //         { leaderPoints.Value = (float)calendarResults.CurrentEventResults.allroundResults.Keys[0].Item1; }
        //         else
        //         { leaderPoints.Value = 0; }

        //         competitorVariable.Set(comp, bib);

        //         if (calendarResults.CurrentRoundInfo.roundType == RoundType.Normal)
        //         {
        //             if (calendarResults.roundIt > 0)
        //             {
        //                 competitorVariable.SetResult((float)calendarResults.CurrentEventResults.totalResults[calendarResults.CurrentStartList[calendarResults.jumpIt]],
        //                 calendarResults.CurrentEventResults.lastRank[calendarResults.CurrentStartList[calendarResults.jumpIt]]);
        //             }
        //         }
        //         else if (calendarResults.CurrentRoundInfo.roundType == RoundType.KO)
        //         {
        //             if (calendarResults.jumpIt % 2 == 0 && calendarResults.jumpIt == calendarResults.CurrentStartList.Count - 1)
        //             {
        //                 // jumpUIManager.ShowJumperInfoKO(comp, bib);
        //             }
        //             else
        //             {
        //                 int cnt = calendarResults.jumpIt - calendarResults.jumpIt % 2;
        //                 int id1 = calendarResults.CurrentStartList[cnt];
        //                 int id2 = calendarResults.CurrentStartList[cnt + 1];
        //                 Competitor comp1 = calendarResults.calendar.competitors[calendarResults.CurrentEventResults.participants[id1]];
        //                 Competitor comp2 = calendarResults.calendar.competitors[calendarResults.CurrentEventResults.participants[id2]];
        //                 int bib1 = calendarResults.CurrentEventResults.bibs[id1][calendarResults.roundIt];
        //                 int bib2 = calendarResults.CurrentEventResults.bibs[id2][calendarResults.roundIt];

        //                 if (calendarResults.jumpIt % 2 == 0)
        //                 {
        //                     // jumpUIManager.ShowJumperInfoKO(comp1, bib1, comp2, bib2);
        //                 }
        //                 else
        //                 {
        //                     // jumpUIManager.ShowJumperInfoKO(comp1, bib1, comp2, bib2, calendarResults.CurrentEventResults.totalResults[id1]);
        //                 }
        //             }
        //         }

        //         jumperPreparation.Invoke(calendarResults.roundIt);
        //         judges.NewJump();
        //     }
        //     else if (calendarResults.jumpIt == calendarResults.CurrentStartList.Count)
        //     {
        //         showingResults = true;
        //         jumpUIManager.ShowEventResults(calendarResults);
        //     }
        //     else if (calendarResults.jumpIt >= calendarResults.CurrentStartList.Count)
        //     {
        //         calendarResults.jumpIt = 0;
        //         return NextRound();
        //     }

        return true;
    }


    public bool NextRound()
    {
        // calendarResults.RecalculateFinalResults();
        // jumpUIManager.HideResults();
        // if (calendarResults.roundIt >= calendarResults.CurrentEvent.roundInfos.Count)
        // {
        //     calendarResults.roundIt = 0;
        //     return NextEvent();
        // }

        RoundInit();
        NextJump();
        return true;
    }

    public bool NextEvent()
    {
        // calendarResults.UpdateClassifications();
        resultsContainer.eventIt++;
        // if (calendarResults.eventIt >= calendarResults.calendar.events.Count)
        // {
        //     ShowClassificationsResults();
        //     return false;
        // }

        // CompetitionInit();
        return true;
    }

    void Start()
    {
        LoadData();
        CompetitionInit();
        // SaveData();
    }
}
