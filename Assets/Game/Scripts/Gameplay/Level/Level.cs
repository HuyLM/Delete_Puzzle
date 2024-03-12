using ScratchCardAsset;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DP
{
    public class Level : MonoBehaviour
    {
        [SerializeField] private ScratchCardManager[] allScratchCards;
        [SerializeField] private CompleteScratchCondition[] completeCardConditions;

        private int tounchScratchCount;

        private void Start()
        {
            InitLevel();
            StartLevel();
        }

        public void InitLevel()
        {
            foreach (var card in allScratchCards)
            {
                card.InputEnabled = false;
                card.Card.Init();
                card.Card.ScratchCardInput.OnBeginScratch += OnBeginScratch;
                card.Card.ScratchCardInput.OnEndScratch += OnEndScratch;
            }
        }

        public void StartLevel()
        {
            tounchScratchCount = 0;
            foreach (var card in allScratchCards)
            {
                card.InputEnabled = true;
            }
        }

        private void RestartLevel()
        {
            tounchScratchCount = 0;
            foreach (var card in allScratchCards)
            {
                card.Card.ClearInstantly();
            }
        }

        private void OnBeginScratch()
        {
            tounchScratchCount++;

        }

        private void OnEndScratch()
        {
            tounchScratchCount--;
            if(tounchScratchCount <= 0)
            {
                CheckWin();
            }
        }

        private void CheckWin()
        {
            bool isWin = true;
            foreach (var condition in completeCardConditions)
            {
                if(condition.CheckWin() == false)
                {
                    isWin = false;
                    break;
                }
            }

            if(isWin)
            {
                Debug.LogError("Win");
            }
            else
            {
                Debug.LogError("Lose");
                RestartLevel();
            }
        }

        [System.Serializable]
        public class CompleteScratchCondition
        {
            public ScratchCardManager ScratchCard;
            [Range(0, 1)] public float NeedEraseProgress;

            public bool CheckWin()
            {
                Debug.LogError(ScratchCard.Progress.GetProgress());
                return ScratchCard.Progress.GetProgress() >= NeedEraseProgress;
            }
        }
    }
}
