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
        [SerializeField] TMPro.TextMeshProUGUI txtResult;

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
            txtResult.text = string.Empty;
        }

      
        public void StartLevel()
        {
            curStepIndex = 0;
            StartCurrentStep();
        }

        private void StartCurrentStep()
        {
            Debug.LogError("StartCurrentStep: " + curStepIndex);
            steps[curStepIndex].StartStep();
            steps[curStepIndex].SetOnComplete(OnStepWin);
        }


        private void OnStepWin()
        {
            Debug.LogError("OnStepWin: " + curStepIndex);
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
            txtResult.text = "Win";
        }
    }
}
