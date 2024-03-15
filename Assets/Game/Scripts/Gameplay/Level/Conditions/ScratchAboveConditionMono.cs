using AtoGame.Base;
using ScratchCardAsset;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DP
{
    public class ScratchAboveConditionMono : ConditionMono
    {
        [SerializeField] private ScratchCardManager scratchCard;
        [Range(0, 1), SerializeField] private float eraseProgress;

        public override bool CheckCondition()
        {
            return scratchCard.Progress.GetProgress() >= eraseProgress;
        }
    }
}
