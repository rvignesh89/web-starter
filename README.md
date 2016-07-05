# web-starter

[![Join the chat at https://gitter.im/rvignesh89/web-starter](https://badges.gitter.im/Join%20Chat.svg)](https://gitter.im/rvignesh89/web-starter?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)
[![Build status](https://ci.appveyor.com/api/projects/status/dxgvityvevq8es8d?svg=true)](https://ci.appveyor.com/project/rvignesh89/web-starter)
[![Gitter](https://badges.gitter.im/Join%20Chat.svg)](https://gitter.im/rvignesh89/web-starter?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge)

## Description
web.starter is a library which can be used to hook in application startup behaviour in a clean way without polluting the global.asax file. The library itself is a simple implementation of the [Observer Design Pattern](https://sourcemaking.com/design_patterns/observer).

## Usage
Using this library is easy. You need to copy paste the following code into the Application_Start() of your project.

	var starter = new AppStarter();
	stater.RegisterWith(new YourImplementation());
	starter.StartAll();

Here, YourImplementation must implement IStartable with the following methods.

	public interface IStartable {
		void Start();
		void OnException();
		string GetName();
	}

### Start()
This method is called when StartAll() called in the global.asax.

*The ordering in which implementations are registered is the order in which they will be called*

### OnException()
If a particular observer throws an exception that observer's OnException method will be raised. This was we can avoid try {} catch blocks inside the Observers.
