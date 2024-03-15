using AtoGame.Base.Helper;
using AtoGame.Base.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DP
{
    public class StartLogoScene : MonoBehaviour
    {
        [SerializeField] private BaseProgressBar pbLoading;
        [SerializeField] private float delayLoading = 0.3f;
        [SerializeField] private float fakeLoadingTime = 3f;

        private void Start()
        {
            StartCoroutine(IFakeLoading());
        }

        private IEnumerator IFakeLoading()
        {
            pbLoading.gameObject.SetActive(false);
            yield return Yielder.Wait(delayLoading);
            pbLoading.gameObject.SetActive(true);
            pbLoading.Initialize();
            pbLoading.ForceFillBar(0);
            yield return null;
            float time = 0;
            while (time < fakeLoadingTime)
            {
                float progressValue = time / fakeLoadingTime;
                pbLoading.ForceFillBar(progressValue);
                time += Time.deltaTime;
                yield return null;
            }
            yield return Yielder.Wait(0.5f);
            pbLoading.ForceFillBar(1);
            yield return null;
            ChangeScene();
        }

        private void ChangeScene()
        {
            SceneLoader.Instance.LoadGameplayScene();
        }

    }
}
