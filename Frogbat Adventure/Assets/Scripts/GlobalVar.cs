using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR.Haptics;
using UnityEngine.SceneManagement;

//Sooo Launch types are basically... How the unit flies when it's hit
//Grapple is a forward and upward force
//Damage is A launch upward and backwards
//Superjump is a launch straight upward it's also currently not used
public enum LaunchType { NONE, GRAPPLE, DAMAGE, SUPERJUMP, EXTERNAL};

//So Bubble Elements are applied to the bubble when the player eats stuff... 
//It'll check what the eatable target's element is then tell the bubble shooter what kind of thing to shoot
public enum SecretBlessing { NONE, FIRE, ICE, EARTH, AIR, LIGHT, DARK };

//So if the player enters the hazard
public enum HazardType { STAGE, SINGLE };

//Item Types
public enum CollectibleType {KEYS, TEMPSHOT, SHOTOVERRIDE, POWERUP, COLLECTIBLE};

public enum GameState { MAINMENU, CUTSCENE, GAMEPLAY, GAMEMENU, STAGESELECT}

public enum CameraType { STATIC, HORIZONTAL, VERTICAL, FOLLOW, RAILED}

//Triggers for the player Animator
public enum P_AnimTriggers { IsGrounded, IsFloating, IsMoving, IsJumping, IsCrouching, InWater}

public enum GameTags { Player}

public enum RailType { OneWay, Rubberband, Loop, UnitActivated}


//BASIC ENEMY STATES
public enum AIStates {Idle,Chase, Attack, Damaged, Dead}
//Used for Triggering the Basic animator
public enum AnimTriggers { Action1, Action2, Action3, ToIdle, EXMovement, IdleLayer }


//Used for the Shooters
public enum ShooterType {Stats, Single, Burst, Fan, Shotgun, Rapid, Laser, Area}
public enum ProjectileLogic { Basic, Boomerang, Lob, Lift}
public enum ProjectileModifier { None , Piercing, Multipart, Bouncing, Stats }


public enum ButtonType {OneTime, Toggle, Weighted, KeyLocked}
public enum RecieverType {Single, OrSwitch, AllTrue, AllFalse}

public enum ToggleType { GameObject, Collider, Animator, Effector }


//AUDIO ENUMS
public enum AudioType { OneShot, Looping }

//DEBUG MENUS
public enum DEBUG_MENUS {SYSTEM,STAGE,PLAYER }

//public enum Resolution { _1920x1080 , _1600x900 , _1280x720}
public enum Language {English}

public enum SliderValues{NONE, G_Brightness, A_Master, A_Music, A_Effects }

public enum MenuItemType{NONE, SLIDER, TOGGLE, BUTTON, SPINNER}
//Spinner is a bit tougher to use... It needs to sense it's a scrollbar...

public enum SettingsNames{NONE, 
    AUD_MASTER, AUD_MUSIC, AUD_EFFECTS, AUD_VOICE,
    GFX_RES, GFX_FULLSCREEN, GFX_COLORFILTER,
    GP_LANG, GP_TIMESCALE, GP_EAT, GP_FLOAT, GP_FLYING, GP_CHECKPOINT}


public enum FileSelectContext
{
    StartGame, Copy, Delete
}

public static class GlobalVar
{
    public static bool PAUSED = false;


    #region Physics Variables
    public static float LowGravity { get; } = 2f;
    public static float HighGravity { get; } = 2.5f;

    public static LayerMask PlayerGround { get; } = LayerMask.GetMask("Default", "Surface");//= 1536/1537;
    public static LayerMask DropThroughPlatform { get; } = LayerMask.GetMask("Default");


    #endregion


    public static Controls2D GlobalControls { get; } = new Controls2D();
    public static string MAINMENU_NAME { get; } = "MainMenu";
    public static string STAGESELECT_NAME { get; } = "StageSelect";

    //public static string[] StageNames;

    //Generic Forces that I need to keep constant then have multipliers to adjust how hard they fly
    public static Vector2 GrappleForce{ get; } = new Vector2(5f, 2f);
    public static Vector2 KnockbackForce { get; } = new Vector2(-2.5f, 1f);

    public static float waterMoveMod = 0.75f;
    public static float waterJumpMod = 1.5f;

}


