//
//  UAFCSharpProxy.cpp
//  Unity-iPhone
//
//  Created by L on 2023/6/8.
//

#include "UAFCSharpProxy.h"
#include <vm/Class.h>
#include <il2cpp-class-internals.h>
#include <vm/CCWBase.h>
#include <utils/StringUtils.h>

using namespace il2cpp::vm;

void ThrowException(const char* error)
{
    std::string err_msg = il2cpp::utils::StringUtils::Printf(error);
    Exception::Raise(Exception::GetMissingMethodException(err_msg.c_str()));
}

void UAFCSharpProxy::Init(void* csharp_proxy)
{
    CCWBase *ccw = (CCWBase*) csharp_proxy;

    if(ccw == NULL)
    {
        ThrowException("csharp_proxy is not ManagedObject!");
        return;
    }
    
    _proxy = ccw->GetManagedObject();
    
    if(_proxy == NULL)
    {
        ThrowException("_proxy holder is null!");
        return;
    }
    
    Il2CppClass* proxyClass = _proxy->klass;

    if(proxyClass == NULL)
    {
        ThrowException("UAF.iOSUAFAdaptor is null !");
        return;
    }
    
    // @formatter:off
    _onInitResult               = Class::GetMethodFromName(proxyClass, "OnInitResultInternal", -1);

    // @formatter:on
}

#define INVOKE_METHOD(method, param) \
    if (_proxy == NULL) \
    { \
        ThrowException("UAFHelper._ADAPTOR is null !"); \
        return; \
    } \
    \
    if (method == NULL) \
    { \
        ThrowException(#method "is null !"); \
        return; \
    } \
    \
    method->invoker_method(method->methodPointer, method, _proxy, param, NULL);


void UAFCSharpProxy::OnInitResult(int code, const char* msg)
{
    void* param[2] = {&code, (void*)String::NewWrapper(msg)};

    INVOKE_METHOD(_onInitResult, param);
}
