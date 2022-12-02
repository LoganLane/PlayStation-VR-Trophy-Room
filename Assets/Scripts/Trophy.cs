using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Root
{
    public List<TrophyTitle> trophyTitles;
    public string trophySetVersion;
    public bool hasTrophyGroups;
    public DateTime lastUpdatedDateTime;
    public List<Trophy> trophies;
    public List<RarestTrophy> rarestTrophies;
    public int totalItemCount;
}
[Serializable]
public class Trophy
{
    public int trophyId;
    public bool trophyHidden;
    public bool earned;
    public string trophyType;
    public int trophyRare;
    public string trophyName;
    public string trophyDetail;
    public string trophyIconUrl;
    public string trophyGroupId;
    public string trophyEarnedRate;
    public DateTime? earnedDateTime;
}
[Serializable]
public class RarestTrophy
{
    public int trophyId;
    public bool trophyHidden;
    public bool earned;
    public DateTime earnedDateTime;
    public string trophyType;
    public int trophyRare;
    public string trophyEarnedRate;
}


[Serializable]
public class DefinedTrophies
{
    public int bronze ;
    public int silver ;
    public int gold ;
    public int platinum ;
}

[Serializable]
public class EarnedTrophies
{
    public int bronze ;
    public int silver ;
    public int gold ;
    public int platinum ;
}

[Serializable]
public class TrophyTitle
{
    public string npServiceName ;
    public string npCommunicationId ;
    public string trophySetVersion ;
    public string trophyTitleName ;
    public string trophyTitleIconUrl ;
    public string trophyTitlePlatform ;
    public bool hasTrophyGroups ;
    public DefinedTrophies definedTrophies ;
    public int progress ;
    public EarnedTrophies earnedTrophies ;
    public bool hiddenFlag ;
    public DateTime lastUpdatedDateTime ;
    public string trophyTitleDetail ;
}



