using System;
using System.Collections.Generic;

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
public class Root
{
    public List<TrophyTitle> trophyTitles ;
    public int nextOffset ;
    public int totalItemCount ;
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