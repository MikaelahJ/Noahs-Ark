using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SettingsScript : MonoBehaviour
{
    [SerializeField] private List<Image> volumeMainImages = new List<Image>();
    [SerializeField] private List<Image> volumeMainImagesBG = new List<Image>();
    [SerializeField] private List<Sprite> volumeSprites = new List<Sprite>();
    //VolumeIndex[0] is master 1 is music 2 is SFX
    private int[] volumeIndex = new int[3] { 3, 3, 3 };

    [SerializeField] private Toggle fullscreenToggle;
    [SerializeField] private Toggle fullscreenToggleBG;

    private void Start()
    {
        Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
        UpdateScreenMode();
    }

    public void AddVolume(int whichToChange)
    {
        volumeIndex[whichToChange]++;
        volumeIndex[whichToChange] = Mathf.Clamp(volumeIndex[whichToChange], 0, 4);

        OnVolumeChanged(volumeIndex[whichToChange], volumeMainImages[whichToChange], volumeMainImagesBG[whichToChange]);
    }

    public void RemoveVolume(int whichToChange)
    {
        volumeIndex[whichToChange]--;
        volumeIndex[whichToChange] = Mathf.Clamp(volumeIndex[whichToChange], 0, 4);

        OnVolumeChanged(volumeIndex[whichToChange], volumeMainImages[whichToChange], volumeMainImagesBG[whichToChange]);
    }

    private void OnVolumeChanged(int volume, Image imageToChange, Image imageToChangeBG)
    {
        switch (volume)
        {
            case 0:
                imageToChange.sprite = volumeSprites[0];
                imageToChangeBG.sprite = volumeSprites[0];
                break;

            case 1:
                imageToChange.sprite = volumeSprites[1];
                imageToChangeBG.sprite = volumeSprites[1];
                break;

            case 2:
                imageToChange.sprite = volumeSprites[2];
                imageToChangeBG.sprite = volumeSprites[2];
                break;

            case 3:
                imageToChange.sprite = volumeSprites[3];
                imageToChangeBG.sprite = volumeSprites[3];
                break;

            case 4:
                imageToChange.sprite = volumeSprites[4];
                imageToChangeBG.sprite = volumeSprites[4];
                break;
        }
    }

    public void ToggleScreenMode()
    {
        bool isFullscreen = fullscreenToggle.isOn;

        fullscreenToggleBG.isOn = isFullscreen;

        if (isFullscreen)
            Screen.fullScreenMode = FullScreenMode.Windowed;
        else
            Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;

        //switch (Screen.fullScreenMode)
        //{
        //    case FullScreenMode.ExclusiveFullScreen:
        //        Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
        //        break;

        //    case FullScreenMode.FullScreenWindow:
        //        Screen.fullScreenMode = FullScreenMode.Windowed;
        //        break;

        //    case FullScreenMode.Windowed:
        //        Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
        //        break;
        //}
        UpdateScreenMode();
    }

    private void UpdateScreenMode()
    {
        Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, Screen.fullScreenMode);
    }
}
