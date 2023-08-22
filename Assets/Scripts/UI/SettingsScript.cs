using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SettingsScript : MonoBehaviour
{
    [SerializeField] private List<Image> volumeMainImages = new List<Image>();

    [SerializeField] private List<Sprite> volumeSprites = new List<Sprite>();

    //VolumeIndex[0] is master 1 is music 2 is SFX
    private int[] volumeIndex = new int[3] { 3, 3, 3 };

    private void Start()
    {
        //UpdateScreenMode();
    }

    public void AddVolume(int whichToChange)
    {
        volumeIndex[whichToChange]++;
        volumeIndex[whichToChange] = Mathf.Clamp(volumeIndex[whichToChange], 0, 4);

        OnVolumeChanged(volumeIndex[whichToChange], volumeMainImages[whichToChange]);
    }

    public void RemoveVolume(int whichToChange)
    {
        volumeIndex[whichToChange]--;
        volumeIndex[whichToChange] = Mathf.Clamp(volumeIndex[whichToChange], 0, 4);

        OnVolumeChanged(volumeIndex[whichToChange], volumeMainImages[whichToChange]);
    }

    private void OnVolumeChanged(int volume, Image imageToChange)
    {
        switch (volume)
        {
            case 0:
                imageToChange.sprite = volumeSprites[0];
                break;

            case 1:
                imageToChange.sprite = volumeSprites[1];
                break;

            case 2:
                imageToChange.sprite = volumeSprites[2];
                break;

            case 3:
                imageToChange.sprite = volumeSprites[3];
                break;

            case 4:
                imageToChange.sprite = volumeSprites[4];
                break;
        }
    }

    public void ToggleScreenMode()
    {
        switch (Screen.fullScreenMode)
        {
            case FullScreenMode.ExclusiveFullScreen:
                Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
                break;

            case FullScreenMode.FullScreenWindow:
                Screen.fullScreenMode = FullScreenMode.Windowed;
                break;

            case FullScreenMode.Windowed:
                Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
                break;
        }
        UpdateScreenMode();
    }

    private void UpdateScreenMode()
    {
        Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, Screen.fullScreenMode);
    }
}
