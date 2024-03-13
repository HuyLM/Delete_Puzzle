using AtoGame.Base;
using ScratchCardAsset;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DP
{
    public class ScratchBelowConditionMono : ConditionMono
    {
        [SerializeField] private ScratchCardManager scratchCard;
        [Range(0, 1), SerializeField] private float eraseProgress;

        public override bool CheckCondition()
        {
            Debug.LogError("ScratchBelowConditionMono: " + scratchCard.Progress.GetProgress());
            return scratchCard.Progress.GetProgress() <= eraseProgress;
        }
    }
}
