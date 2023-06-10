# JFramework-Async
对Unity的一些方法进行异步拓展，使其能够被await
```csharp
  private async void Start()
    {
        await new WaitForSeconds(1);//等待一秒
        await new WaitForSecondsRealtime(1);//等待1秒，不受timeScale影响
        await new WaitForFixedUpdate();//等待直到下一次FixedUpdate执行
        await new WaitForEndOfFrame();//等待这一帧结束
        await new WaitWhile(WaitTime);//等待WaitTime结果为false时退出
        await new WaitUntil(WaitTime);//等待WaitTime结果为true时退出
        await SceneManager.LoadSceneAsync("SceneName");
        await Resources.LoadAsync("ResourcesName");
        AsyncOperation asyncOperation = new AsyncOperation();
        await asyncOperation;//等待异步操作
        ResourceRequest request = new ResourceRequest();
        await request;//等待资源请求
    }
    
    private bool WaitTime()
    {
        return true;
    }
```