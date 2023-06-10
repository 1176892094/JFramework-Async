using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace JFramework.Async
{
    public static class AwaitExtension
    {
        public static CoroutineAwaiter GetAwaiter(this WaitForSeconds result) => AsyncExtension.GetAwaiter(result);

        public static CoroutineAwaiter GetAwaiter(this WaitForEndOfFrame result) => AsyncExtension.GetAwaiter(result);

        public static CoroutineAwaiter GetAwaiter(this WaitForFixedUpdate result) => AsyncExtension.GetAwaiter(result);

        public static CoroutineAwaiter GetAwaiter(this WaitForSecondsRealtime result) => AsyncExtension.GetAwaiter(result);

        public static CoroutineAwaiter GetAwaiter(this WaitUntil result) => AsyncExtension.GetAwaiter(result);

        public static CoroutineAwaiter GetAwaiter(this WaitWhile result) => AsyncExtension.GetAwaiter(result);

        public static CoroutineAwaiter<AsyncOperation> GetAwaiter(this AsyncOperation result) => AsyncExtension.GetAwaiterAsync(result);

        public static CoroutineAwaiter<Object> GetAwaiter(this ResourceRequest result)
        {
            var awaiter = new CoroutineAwaiter<Object>();
            AsyncManager.Run(() => AsyncManager.Instance.StartCoroutine(AsyncExtension.ResourceRequest(awaiter, result)));
            return awaiter;
        }

        public static CoroutineAwaiter<T> GetAwaiter<T>(this IEnumerator<T> coroutine)
        {
            var awaiter = new CoroutineAwaiter<T>();
            AsyncManager.Run(() => AsyncManager.Instance.StartCoroutine(new CoroutineWrapper<T>(coroutine, awaiter).Run()));
            return awaiter;
        }

        public static CoroutineAwaiter<object> GetAwaiter(this IEnumerator coroutine)
        {
            var awaiter = new CoroutineAwaiter<object>();
            AsyncManager.Run(() => AsyncManager.Instance.StartCoroutine(new CoroutineWrapper<object>(coroutine, awaiter).Run()));
            return awaiter;
        }
    }
}