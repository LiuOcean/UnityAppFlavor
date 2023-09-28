#if OVERSEA
#import "UAFAppController.h"
#import "UnityAppController.h"
#import "UAFCSharpProxy.h"

IMPL_APP_CONTROLLER_SUBCLASS(UAFAppController)

@implementation UAFAppController

static UAFAppController *instance = nil;
static UAFCSharpProxy *proxy = nil;
static bool _init = false;
static NSDictionary* launchOptions;
static UIApplication* application;

+ (UAFAppController *)sharedInstance
{
    @synchronized(self)
    {
        if(instance == nil)
        {
            instance = [[[self class] alloc] init];
        }
    }
    return instance;
}

// MARK: UAF 生命周期
- (BOOL)application:(UIApplication*)app didFinishLaunchingWithOptions:(NSDictionary*)options
{
    launchOptions = options;
    application = app;
    
    bool result = [super application:app didFinishLaunchingWithOptions:options];

    _InitUAFSDK();
    
    return result;
}

-(void)application:(UIApplication *)application didRegisterForRemoteNotificationsWithDeviceToken:(NSData *)deviceToken
{
//    [super application:application didRegisterForRemoteNotificationsWithDeviceToken: deviceToken];
}

-(void)application:(UIApplication *)application didReceiveRemoteNotification:(nonnull NSDictionary *)userInfo
{
    [super application:application didReceiveRemoteNotification:userInfo];
}

-(void)application:(UIApplication *)application didReceiveRemoteNotification:(NSDictionary *)userInfo fetchCompletionHandler:(void (^)(UIBackgroundFetchResult))completionHandler
{
    [super application:application didReceiveRemoteNotification:userInfo];
}

-(void)application:(UIApplication *)application didReceiveLocalNotification:(UILocalNotification *)notification
{
    [super application:application didReceiveLocalNotification:notification];
}

- (void)applicationWillResignActive:(UIApplication *)application
{
    
    [super applicationWillResignActive:application];
}

- (void)applicationDidEnterBackground:(UIApplication *)application
{
    [super applicationDidEnterBackground:application];
}

- (void)applicationWillEnterForeground:(UIApplication *)application
{
    [super  applicationWillEnterForeground:application];
}

- (void)applicationDidBecomeActive:(UIApplication *)application
{
    [super applicationDidBecomeActive:application];
}

- (void)applicationWillTerminate:(UIApplication *)application
{
    [super applicationWillTerminate:application];
}

-(BOOL)application:(UIApplication *)application handleOpenURL:(NSURL *)url
{
    return no;
}

-(BOOL)application:(UIApplication *)application openURL:(NSURL *)url sourceApplication:(NSString *)sourceApplication annotation:(id)annotation
{
    return [super application:application openURL:url sourceApplication:sourceApplication annotation:annotation];
}


void _InitUAFSDK()
{
    if(_init)
    {
        if(proxy!= NULL)
        {
            proxy->OnInitResult(1, "");
        }
        
        return;
    }
    
    _init = true;
 
    // 调用对应 SDK 的初始化
    // 此处模拟初始化成功 
    if(proxy != NULL) 
    {
        proxy->OnInitResult(1, "");
    }
}
@end
#endif
