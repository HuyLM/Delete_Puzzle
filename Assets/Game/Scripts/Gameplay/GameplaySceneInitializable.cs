using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace DP
{
    public class GameplaySceneInitializable : SceneInitializable
    {
        [SerializeField] private Transform tfMapContainer;


        private AsyncOperationHandle<GameObject> operation;
        private Level level;

        public override IEnumerator IInitialize()
        {
            AssetReferenceGameObject _asMap = DataConfigs.Instance.TempLevel;

            operation = _asMap.InstantiateAsync(tfMapContainer);
            yield return operation;
            level = operation.Result.GetComponent<Level>();
        }

        public override IEnumerator Release()
        {
            Addressables.Release(operation);
            yield return Resources.UnloadUnusedAssets();
        }
    }
}
