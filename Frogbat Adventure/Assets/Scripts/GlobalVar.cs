using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Sooo Launch types are basically... How the unit flies when it's hit
//Grapple is a forward and upward force
//Damage is A launch upward and backwards
//Superjump is a launch straight upward it's also currently not used
public enum LaunchType { NONE, GRAPPLE, DAMAGE, SUPERJUMP};

//So Bubble Elements are applied to the bubble when the player eats stuff... 
//It'll check what the eatable target's element is then tell the bubble shooter what kind of thing to shoot
public enum Element { NONE, FIRE, ICE, WATER, EARTH, AIR, ELECTRIC };

//So if the player enters the hazard
public enum HazardType { STAGE, SINGLE };

//Item Types
public enum CollectibleType {KEYS, TEMPSHOT, SHOTOVERRIDE, POWERUP};

public enum GameState { MAINMENU, CUTSCENE, GAMEPLAY, GAMEMENU}

public enum CameraType { STATIC, HORIZONTAL, VERTICAL, FOLLOW, RAILED}

public enum AnimTriggers { Action1, Action2, Action3, ToIdle, EXMovement, IdleLayer}
public enum P_AnimTriggers { IsGrounded, IsFloating, IsMoving, IsJumping, IsCrouching, InWater}
public enum GameTags { Player}

public enum AIStates {Idle,Chase, Attack, Damaged, Dead}

//Used for the Shooters
public enum ShooterType {Stats, Single, Burst, Fan, Shotgun, Rapid, Laser}
public enum ProjectileLogic { Basic, Boomerang, Lob, Lift}
public enum ProjectileModifier { None , Piercing, Multipart, Bouncing, Stats }



//DEBUG MENUS
public enum DEBUG_MENUS {SYSTEM,STAGE,PLAYER }


public class GlobalVar : MonoBehaviour
{
    public static bool PAUSED = false;


    #region Physics Variables
    public static float LowGravity { get; } = 2f;
    public static float HighGravity { get; } = 2.5f;

    public static LayerMask PlayerGround = LayerMask.GetMask("Default", "Platform");//= 1536/1537;
    public static LayerMask DropThroughPlatform = LayerMask.GetMask("Default");
    #endregion


    public static Controls2D GlobalControls { get; } = new Controls2D();
    public static string MAINMENU_NAME { get; } = "MainMenu";


    //public static string[] StageNames;

    
}


