using System;
using DG.Tweening;
using UnityEngine;

public class ButtonPanel : Panel
{
    public RectTransform settingsLayout;
    public GameObject settingsButton;
    public bool isSettingsOpen = false;

    private Vector2 firsSettingsLayoutPos;

    public void SettingsButton()
    {
        if (isSettingsOpen)
        {
            isSettingsOpen = false;
            settingsButton.transform.DORotate(new Vector3(0, 0, 0), .5f);
            settingsLayout.DOAnchorPosY(firsSettingsLayoutPos.y, .5f);
        }
        else
        {
            firsSettingsLayoutPos = settingsLayout.anchoredPosition;
            isSettingsOpen = true;
            settingsButton.transform.DORotate(new Vector3(0, 0, -90), .5f);
            settingsLayout.DOAnchorPosY(0, .5f);
        }
    }
}
