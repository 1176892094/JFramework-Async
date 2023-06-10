# JFramework-Async
对Unity的一些方法进行异步拓展，使其能够被await
```csharp
  private async void Start()
    {
        //等待一秒
        await new WaitForSeconds(1);
        
        //等待1秒，不受timeScale影响
        await new WaitForSecondsRealtime(1);
        
        //等待直到下一次FixedUpdate执行
        await new WaitForFixedUpdate();
        
        //等待这一帧结束
        await new WaitForEndOfFrame();
        
        //等待直到Test结果为false时退出
        await new WaitWhile(Test);
        
        //等待直到Test结果为true时退出
        await new WaitUntil(Test);
        
        //等待异步加载场景完成
        await SceneManager.LoadSceneAsync("SceneName");
        
        //等待异步资源加载完成
        await Resources.LoadAsync("ResourcesName");
        
         //等待异步操作
        AsyncOperation asyncOperation = new AsyncOperation();
        await asyncOperation;
        
        //等待资源请求
        ResourceRequest request = new ResourceRequest();
        await request;
        
        //等待协程完成
        await Test2();
    }
    
    private bool Test()
    {
        return true;
    }
    
    private IEnumerator Test2()
    {
        yield return null;
    }
```
