using DevCommon;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotGame : Singleton<SlotGame>
{
    public List<ReelMovement> ReelsList = new List<ReelMovement>();
    public float MinimumRotateDistance = 640.0f;

    public void OnSpinButtonPressed()
    {
        StartSpin();
    }

    public void StartSpin()
    {
        //Start Reels spin
        for (int x = 0; x < ReelsList.Count; ++x)
        {
            ReelsList[x].Spin();
        }
    }
}
 