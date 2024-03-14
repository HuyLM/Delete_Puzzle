using AtoGame.Base;
using ScratchCardAsset;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace DP
{
    public class Step : MonoBehaviour
    {
        [SerializeField] private ScratchCardManager[] allScratchCards;
        [SerializeField] private ConditionMono winCondition;
        [SerializeField] private ActionMono startStepAction;
        [SerializeField] private ActionMono restartStepAction;
        [SerializeField] private ActionMono endStepAction;

        private int tounchScratchCount;
        private Action onCompleteStep;

        public void InitStep()
        {
            foreach (var card in allScratchCards)
            {
                card.Card.Init();
            }
        }


        public void StartStep()
        {
            tounchScratchCount = 0;
            foreach (var card in allScratchCards)
            {
                card.Card.ScratchCardInput.OnBeginScratch += OnBeginScratch;
                card.Card.ScratchCardInput.OnEndScratch += OnEndScratch;
            }
            startStepAction?.Execute();
        }

        private void RestartStep()
        {
            tounchScratchCount = 0;
            foreach (var card in allScratchCards)
            {
                card.Card.ClearInstantly();

                if (card.Progress != null)
                {
                    card.Progress.ResetProgress();
                    card.Progress.UpdateProgress();
                }
            }
            restartStepAction?.Execute();
        }

        public void EndStep()
        {
            foreach (var card in allScratchCards)
            {
                card.Card.ScratchCardInput.OnBeginScratch -= OnBeginScratch;
                card.Card.ScratchCardInput.OnEndScratch -= OnEndScratch;
            }
        }

        private void OnBeginScratch()
        {
            tounchScratchCount++;

        }

        private void OnEndScratch()
        {
            tounchScratchCount--;
            if (tounchScratchCount <= 0)
            {
                CheckWin();
            }
        }

        private void CheckWin()
        {
            bool isWin = winCondition.CheckCondition();

            if (isWin)
            {
                DoActionsAfterWin();
            }
            else
            {
                RestartStep();
            }
        }

        private void DoActionsAfterWin()
        {
            if(endStepAction != null)
            {
                endStepAction.Execute(onCompleteStep);
            }
            else
            {
                onCompleteStep?.Invoke();
            }
        }

        public void SetOnComplete(Action onComplete)
        {
            this.onCompleteStep = onComplete;
        }
    }
}
