using System;
using System.Threading;
using UnityEngine;

namespace JFramework.Async
{
    [AddComponentMenu("")]
    public class AsyncManager : MonoBehaviour
    {
        private static SynchronizationContext context;
        private static AsyncManager instance;

        internal static AsyncManager Instance
        {
            get
            {
                if (instance != null) return instance;
                var obj = new GameObject(nameof(AsyncManager));
                instance = obj.AddComponent<AsyncManager>();
                obj.hideFlags = HideFlags.HideAndDontSave;
                return instance;
            }
        }

        private void Awake() => DontDestroyOnLoad(gameObject);

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void Runtime() => context = SynchronizationContext.Current;

        public static void Run(Action action)
        {
            if (SynchronizationContext.Current != context)
            {
                context.Post(state => action?.Invoke(), null);
                return;
            }

            action?.Invoke();
        }

        public static void Assert(bool condition)
        {
            if (!condition)
            {
                throw new Exception("<color=#00FFFF>AsyncManager</color> => <color=#FF8888>Assert!</color>");
            }
        }
    }
}