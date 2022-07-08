using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SceneNames 
{
    public static string MainMenu = "MainMenu";
    public static string GameScenePvP = "GameScenePvP";
    public static string GameScenePvM = "GameScenePvM";
}
public static class GameTags 
{
    public static string Player = "Player";
    public static string LeftWall = "LeftWall";
    public static string RightWall = "RightWall";
}
public static class PlayerAxis 
{
    public static string Player1 = "Vertical1";
    public static string Player2 = "Vertical2";
}
public enum PlayerType 
{
    Player1,
    Player2
}
public enum GameMode
{
    PvP,
    PvM
}


