//
//  U8Proxy.hpp
//  Unity-iPhone
//
//  Created by L on 2023/6/8.
//

#include <stdio.h>
#include <vm/Class.h>
#include <il2cpp-class-internals.h>

class UAFCSharpProxy
{
public:
    void Init(void* csharp_proxy);
    
private:

    Il2CppObject* _proxy;
    const MethodInfo* _onInitResult;
};
