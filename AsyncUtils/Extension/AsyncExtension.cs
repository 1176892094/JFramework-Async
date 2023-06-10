using System.Collections;
using UnityEngine;
using Object = UnityEngine.Object;

namespace JFramework.Async
{
    internal static class AsyncExtension
    {
        public static CoroutineAwaiter GetAwaiter(object result)
        {
            var awaiter = new CoroutineAwaiter();
            AsyncManager.Run(() => AsyncManager.Instance.StartCoroutine(Return(awaiter, result)));
            return awaiter;
        }

        public static CoroutineAwaiter<T> GetAwaiterAsync<T>(T result)
        {
            var awaiter = new CoroutineAwaiter<T>();
            AsyncManager.Run(() => AsyncManager.Instance.StartCoroutine(ReturnAsync(awaiter, result)));
            return awaiter;
        }
        
        public static IEnumerator Return(CoroutineAwaiter awaiter, object result)
        {
            yield return result;
            awaiter.Complete(null);
        }

        public static IEnumerator ReturnAsync<T>(CoroutineAwaiter<T> awaiter, T result)
        {
            yield return result;
            awaiter.Complete(result, null);
        }

        public static IEnumerator ResourceRequest(CoroutineAwaiter<Object> awaiter, ResourceRequest result)
        {
            yield return result;
            awaiter.Complete(result.asset, null);
        }
    }
}