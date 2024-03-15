using AtoGame.Base;
using DG.Tweening;
using ScratchCardAsset;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DP
{
    public class Level : MonoBehaviour
    {
        [SerializeField] private Step[] steps;

        private int curStepIndex;

        private void Start()
        {
            InitLevel();
            StartLevel();
        }

        public void InitLevel()
        {
            foreach (var s in steps)
            {
                s.InitStep();
            }
        }

      
        public void StartLevel()
        {
            curStepIndex = 0;
            StartCurrentStep();
        }

        private void StartCurrentStep()
        {
            steps[curStepIndex].StartStep();
            steps[curStepIndex].SetOnComplete(OnStepWin);
        }


        private void OnStepWin()
        {
            steps[curStepIndex].EndStep();
            curStepIndex++;
            if(curStepIndex == steps.Length)
            {
                WinLevel();
            }
            else
            {
                StartCurrentStep();
            }
        }

        private void WinLevel()
        {
        }
    }
}
