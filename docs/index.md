# IocServiceStack.Client

[![Gitter](https://badges.gitter.im/IocServiceStack/Lobby.svg)](https://gitter.im/IocServiceStack/IocServiceStack)  [![Build status](https://ci.appveyor.com/api/projects/status/y27lcxxgah666hf9/branch/master?svg=true)](https://ci.appveyor.com/project/rjinaga/iocservicestack-client/branch/master)

IocServiceStack.Client is a open source .NET library to communicate over HTTP with IocServiceStack.Gateway. This enables communication to remote services of IocServiceStack.

> `out` and `ref` arguments cannot be used when making remote calls.

### Supports
- .NET Framework 4.6


### [NuGet](https://www.nuget.org/packages/IocServiceStack.Gateway/)
```
PM> Install-Package IocServiceStack.Client -Pre
```
[![NuGet Pre Release](https://img.shields.io/badge/nuget-Pre%20Release-yellow.svg)](https://www.nuget.org/packages/IocServiceStack.Client/)


## Usage

### Setup

```c#
using IocServiceStack.Client;

//Configure remote services
IocServicelet.Configure(config =>
{
    config.UseRemoteServices(
	gatewayBaseUrl : 
		"http://localhost:8080/serviceapi");
});

```

### Web N-Tier Architecture using IocServiceStack, IocServiceStack.Gateway, and IocServiceStack.Client 

[https://github.com/rjinaga/Web-N-Tier-Architecture](https://github.com/rjinaga/Web-N-Tier-Architecture)





