using ScratchCardAsset;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DP
{
    public class ScratchProgressDebug : MonoBehaviour
    {
        public ScratchCardManager scratch;

        void Start()
        {
            if(scratch == null)
            {
                scratch = GetComponent<ScratchCardManager>();
            }
            if(scratch)
            {
                scratch.Progress.OnProgress += Progress_OnProgress;
            }
        }

        private void Progress_OnProgress(float progress)
        {
            Debug.Log($"{scratch.gameObject.name} - {progress}");
        }

    }
}
