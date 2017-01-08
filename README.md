# IocServiceStack.Client

[![Gitter](https://badges.gitter.im/IocServiceStack/Lobby.svg)](https://gitter.im/IocServiceStack/Lobby?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=body_badge)

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
IocServiceProvider.Configure(config =>
{
    config.UseRemoteServices(
	gatewayBaseUrl : 
		"http://localhost:8080/serviceapi");
});

```

### Web N Tier Architecture using IocServiceStack, IocServiceStack.Gateway, IocServiceStack.Client 

https://github.com/rjinaga/Web-N-Tier-Architecture





