#import <Foundation/Foundation.h>
#import <UIKit/UIKit.h>
#import "UAFCSharpProxy.h"
#import "UnityAppController.h"

@interface UAFAppController : UnityAppController

+(UAFAppController*)sharedInstance;

extern "C"
{
    void _SetProxy(void* csharp_proxy);
}

@end