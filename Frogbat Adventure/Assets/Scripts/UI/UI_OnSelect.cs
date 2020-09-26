using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System;
using TMPro;
using System.Globalization;
using UnityEngine.PlayerLoop;

public class UI_OnSelect: MonoBehaviour, ISelectHandler, IDeselectHandler
{
    public SettingsNames SettingsTarget;
    public MenuItemType MenuType;
    //public GameObject DataTarget;
    NumberFormatInfo Digit = new NumberFormatInfo();
    public Image UIBackground;
    public Color PanelColor = Color.white;
    public float Steps = 10f;

    public GameObject MenuPreview;
    MenuNavigator MenuCon;
    public TextMeshProUGUI DisplayText;

    [Header("Events")]
    [Space]
    public UnityEvent OnSelectEvents;
    public UnityEvent OnDeselectEvents;


    private void Start()
    {
        if (UIBackground != null) StartCoroutine(PanelFade(false));


        if (MenuType == MenuItemType.NONE || MenuType == MenuItemType.BUTTON) 
        { 
            //Do nothing
        }
        else
        {
            Digit.NumberDecimalDigits = 2;
            StartCoroutine(SetupField());
        }

        
    }
    private void Awake()
    {
        if (OnSelectEvents == null)
            OnSelectEvents = new UnityEvent();
        if (OnDeselectEvents == null)
            OnDeselectEvents = new UnityEvent();
    }

    private void OnEnable()
    {
        //Debug.Log("PrintOnEnable: script was enabled");
        /*
        if (OnCrouchEvent == null)
            OnCrouchEvent = new BoolEvent();
        */
        //UIBackground.color = new Color(PanelColor.r, PanelColor.g, PanelColor.b, 1);
    }
    private void OnDisable()
    {
        UIBackground.color = new Color(PanelColor.r, PanelColor.g, PanelColor.b, 0);
    }

    public void OnSelect(BaseEventData eventData)
    {
        //Debug.Log(this.gameObject.name + " was selected");
        if (OnSelectEvents != null) OnSelectEvents.Invoke();
        OnScreen();
        FadeBackPanel(true);
              //throw new System.NotImplementedException();
    }

    public void OnDeselect(BaseEventData eventData)
    {
        if (OnDeselectEvents != null) OnDeselectEvents.Invoke();
        FadeBackPanel(false);
        //throw new System.NotImplementedException();
    }
    void FadeBackPanel(bool FadeIn)
    {
        if (UIBackground == null)
        {
            Debug.LogWarning("There is no background for this Selectable Object:" + name);
        }
        else
        {
            StopAllCoroutines();
            StartCoroutine(PanelFade(FadeIn));
        }
    }

    IEnumerator PanelFade(bool FadeIn)
    {
        //Debug.LogWarning(name + " Has been selected " + FadeIn);
        yield return new WaitForSecondsRealtime(Time.deltaTime);
        //Debug.Log(name + " this is a UI Image " + FadeIn);
        #region UI Image Property
        if (FadeIn)
        {
            float alpha = Mathf.MoveTowards(UIBackground.color.a, 1, 1f / Steps);
            UIBackground.color = new Color(PanelColor.r, PanelColor.g, PanelColor.b, alpha);
            //Debug.Log(alpha);
            if (alpha < PanelColor.a) StartCoroutine(PanelFade(true));
        }
        else
        {
            float alpha = Mathf.MoveTowards(UIBackground.color.a, 0, 1f / Steps);
            UIBackground.color = new Color(PanelColor.r, PanelColor.g, PanelColor.b, alpha);
            //Debug.Log(alpha);
            if (alpha > 0) StartCoroutine(PanelFade(false));
        }
        #endregion

        /*
        switch (UIBackground.GetType().ToString())
        {
            case "UnityEngine.UI.Image"://This is going to trigger every time you hilight something to emphasize the item.
                Debug.Log(name + " this is a UI Image");
                #region UI Image Property
                if (FadeIn)
                {
                    float alpha = Mathf.MoveTowards(UIBackground.color.a, 1, 1f / Steps);
                    UIBackground.color = new Color(PanelColor.r, PanelColor.g, PanelColor.b, alpha);
                    //Debug.Log(alpha);
                    if (alpha < 1f) StartCoroutine(PanelFade(true));
                }
                else
                {
                    float alpha = Mathf.MoveTowards(UIBackground.color.a, 0, 1f / Steps);
                    UIBackground.color = new Color(PanelColor.r, PanelColor.g, PanelColor.b, alpha);
                    //Debug.Log(alpha);
                    if (alpha> 0) StartCoroutine(PanelFade(false));
                }
                #endregion
                break;
            default:
                throw new System.NotImplementedException();
        }
        */
    }

 

    void OnScreen()
    {
        if (GetComponentInParent<UI_Scroller>())
        {
            GetComponentInParent<UI_Scroller>().CheckPosition(GetComponent<RectTransform>());
            //Debug.Log(GetComponentInParent<UI_Scroller>().rectTransform);
            //Debug.Log(GetComponent<RectTransform>());
            //GetComponentInParent<UI_Scroller>().SetIndex(transform.position);
        }    
    }

    #region Set Initial Value For Settings
    IEnumerator SetupField()
    {
        yield return null;
        switch (MenuType) 
        {
            case MenuItemType.SLIDER:
                #region Slider Cases if you aren't supported you fall into 'default'
                Slider Slid = GetComponent<Slider>();
                float val = 0;
                switch (SettingsTarget)
                {
                    case SettingsNames.AUD_MASTER:
                        val = FindObjectOfType<MenuNavigator>().GetSettings().Audio.Master;
                        break;
                    case SettingsNames.AUD_MUSIC:
                        val = FindObjectOfType<MenuNavigator>().GetSettings().Audio.Music;
                        break;
                    case SettingsNames.AUD_EFFECTS:
                        val = FindObjectOfType<MenuNavigator>().GetSettings().Audio.Effects;
                        break;
                    case SettingsNames.AUD_VOICE:
                        val = FindObjectOfType<MenuNavigator>().GetSettings().Audio.Voice;
                        break;
                    case SettingsNames.GP_TIMESCALE:
                        val = FindObjectOfType<MenuNavigator>().GetSettings().Gameplay.TimeScale;
                        break;
                    default:
                        Debug.LogWarning(SettingsTarget.ToString() + " Is not supported by " + MenuType.ToString());
                        break;
                }

                Slid.normalizedValue = val;
                if (SettingsTarget == SettingsNames.GP_TIMESCALE)
                {
                    UpdateText(val.ToString("N", Digit));
                }
                else
                {
                    UpdateText((val * 100).ToString());
                }
                #endregion
                break;
            case MenuItemType.SPINNER:
                #region Spinner Cases if you aren't supported you fall into 'default'
                Scrollbar Scroll = GetComponent<Scrollbar>();
                int Value = 0;
                switch (SettingsTarget)
                {
                    case SettingsNames.GFX_RES:
                        #region This is a bit complex since we need to do a lot with values...
                        Scroll.numberOfSteps = Screen.resolutions.Length;
                        //Value = (int)(Scroll.value * Scroll.numberOfSteps);
                        //if (Res == null) Res = Screen.resolutions[0];
                        ScreenRes Res = FindObjectOfType<MenuNavigator>().GetSettings().Graphics.Res;
                        foreach(Resolution _res in Screen.resolutions)
                        {
                            if (Res.width <= _res.width)
                            {
                                //Debug.Log(Value + " | " +Res.width + " | " + _res.width);
                                break;
                            }
                            else Value++; 
                        }
                        Scroll.value = Value / (Scroll.numberOfSteps - 1);
                        UpdateText(Res.width + "x" + Res.height);
                        #endregion
                        break;
                    case SettingsNames.GFX_FULLSCREEN:
                        #region
                        Scroll.numberOfSteps = 4;
                        Value = (int)(Scroll.value * Scroll.numberOfSteps);
                        //UpdateSpinner(Scroll);
                        #endregion
                        break;
                    default:
                        Debug.LogWarning(SettingsTarget.ToString() + " Is not supported by " + MenuType.ToString());
                        break;
                }
                ;
                #endregion
                break;
            case MenuItemType.BUTTON:
                #region Button Cases if you aren't supported you fall into 'default'
                switch (SettingsTarget)
                {
                    default:
                        Debug.LogWarning(SettingsTarget.ToString() + " Is not supported by " + MenuType.ToString());
                        break;
                }
                #endregion
                break;
            case MenuItemType.TOGGLE:
                #region Button Cases if you aren't supported you fall into 'default'
                switch (SettingsTarget)
                {
                    default:
                        Debug.LogWarning(SettingsTarget.ToString() + " Is not supported by " + MenuType.ToString());
                        break;
                }
                #endregion
                break;
            case MenuItemType.NONE:
            default:
                Debug.LogWarning(MenuType.ToString() + " Is not supported as settings");
                break;
        }
  
    }

    #endregion

    public void UpdateField()
    {
        switch (MenuType)
        {
            case MenuItemType.SLIDER:
                UpdateSlider(GetComponent<Slider>());
                break;
            case MenuItemType.SPINNER:
                UpdateSpinner(GetComponent<Scrollbar>());
                break;
            case MenuItemType.TOGGLE:
                UpdateToggle(GetComponent<Toggle>());
                break;
            case MenuItemType.NONE:
            case MenuItemType.BUTTON:
                Debug.LogWarning(MenuType.ToString() + " Is not something that needs to be updated");
                break;
            default:
                Debug.LogWarning("This is an invalid Menu Type");
                break;
        }
    }

    #region Slider Updaters
    void UpdateSlider(Slider ValTarget)
    {
        if (MenuCon == null) MenuCon = FindObjectOfType<MenuNavigator>();
        if (MenuCon != null)
        {
            MenuCon.SetSliderValue(ValTarget);
            MenuCon.SaveToVar(SettingsTarget,ValTarget.normalizedValue);
            if (SettingsTarget == SettingsNames.GP_TIMESCALE) 
            {
                UpdateText(ValTarget.normalizedValue.ToString("N",Digit));
            } else
            {
                UpdateText((ValTarget.normalizedValue * 100).ToString());
            }
        }
    }
    #endregion

    #region Spinner/Scrollbar Updaters
    void UpdateSpinner(Scrollbar Scroll)
    {
        if (MenuCon == null) MenuCon = FindObjectOfType<MenuNavigator>();
        if (MenuCon != null)
        {
            int Value = (int)(Scroll.value * (Scroll.numberOfSteps - 1));
            string Text;

            Debug.Log(Value + " | " + Scroll.value + " | " + Scroll.numberOfSteps + " | " + Screen.resolutions.Length);
            switch (SettingsTarget)
            {
                case SettingsNames.GFX_RES:
                    //UpdateSpinner(Scroll, Screen.resolutions[Value]);
                    Resolution Res = Screen.resolutions[Value];
                    Text = (Res.width + "x" + Res.height);
                    UpdateText(Text);
                    MenuCon.SaveToVar(SettingsTarget, Value);
                    break;
                case SettingsNames.GFX_FULLSCREEN:
                    FullScreenMode FSMode = (FullScreenMode)Value;
                    //UpdateSpinner(Scroll, FSMode);
                    Text = FSMode.ToString();
                    UpdateText(Text);
                    MenuCon.SaveToVar(SettingsTarget, Value);
                    break;
                default:
                    break;
            }
        }
    }

    void UpdateSpinner(Scrollbar Scroll, int Value)
    {
        string Text = "Not Filled out Yet";
        UpdateText(Text);
        MenuCon.SaveToVar(SettingsTarget, Value);
    }

    //
    void UpdateSpinner(Scrollbar Scroll, Resolution Res)
    {

    }
    void UpdateSpinner(Scrollbar Scroll, FullScreenMode FSMode)
    {
        string Text = FSMode.ToString();
        UpdateText(Text);
    }
    //So this is mostly for Resolution and Screen Changes

    #endregion


    #region Toggle Updaters
    public void UpdateToggle(Toggle tog)
    {

    }
    public void UpdateToggle(Toggle tog, bool value)
    {

    }
    #endregion

    //Figure out what you WANT the string to be... Then Send it here
    void UpdateText(string Value)
    {
        if (DisplayText != null) DisplayText.text = Value;
    }

  
}
