using System.Collections.Generic;
using UnityEngine;
using CompCal;

[CreateAssetMenu(menuName = "ScriptableObjects/Competition/RuntimeCompetitiorsList")]
public class RuntimeCompetitorsList : ScriptableObject
{
    public List<Competitor> competitors;
    public List<Team> teams;
}
