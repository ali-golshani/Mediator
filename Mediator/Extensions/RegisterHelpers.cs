// File: RegisterHelpers.cs
// The MIT License
//
// Copyright (c) 2021 DementCore
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.
//

using Microsoft.Extensions.DependencyInjection;

namespace Minimal.Mediator.Extensions;

internal static class RegisterHelpers
{
    internal static void RegisterClassesFromAssemblyAndType(
        IServiceCollection services,
        Type openType,
        IEnumerable<Type> types,
        bool allowMultiple,
        bool allowGeneric,
        ServiceLifetime serviceLifetime)
    {
        string OpenTypeName = openType.Name;

        if (allowGeneric)
        {
            foreach (Type type in types.Where(t => IsNotAbstract(t) && t.GetInterface(OpenTypeName) != null))
            {
                if (!IsOpenType(type))
                {
                    continue;
                }

                if (!services.Any(s => s.ServiceType == openType && s.ImplementationType == type))
                {
                    Register(services, openType, type, serviceLifetime);
                }
            }
        }

        foreach (Type type in types.Where(t => IsNotAbstract(t) && t.GetInterface(OpenTypeName) != null))
        {
            if (!IsClosedType(type))
            {
                continue;
            }

            Type serviceType = type.GetInterface(OpenTypeName)!;

            if (allowMultiple)
            {
                if (!services.Any(s => s.ServiceType == serviceType))
                {
                    services.AddTransient(serviceType, type);
                }
            }
            else
            {
                if (!services.Any(s => s.ServiceType == serviceType && s.ImplementationType == type))
                {
                    services.AddTransient(serviceType, type);
                }
            }
        }
    }

    private static void Register(IServiceCollection services, Type serviceType, Type implementationType, ServiceLifetime serviceLifetime)
    {
        switch (serviceLifetime)
        {
            case ServiceLifetime.Singleton:
                services.AddSingleton(serviceType, implementationType);
                break;
            case ServiceLifetime.Scoped:
                services.AddScoped(serviceType, implementationType);
                break;
            case ServiceLifetime.Transient:
                services.AddTransient(serviceType, implementationType);
                break;
        }
    }

    private static bool IsNotAbstract(Type type)
    {
        return !type.IsAbstract && !type.IsInterface;
    }

    private static bool IsClosedType(Type type)
    {
        return !type.IsGenericType && !type.IsGenericTypeDefinition;
    }

    private static bool IsOpenType(Type type)
    {
        return type.IsGenericType && type.IsGenericTypeDefinition;
    }
}