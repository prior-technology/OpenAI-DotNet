# C#/.NET SDK for accessing the OpenAI GPT-3 API

A simple C# .NET wrapper library to use with [OpenAI](https://openai.com/)'s GPT-3 API.  More context [on Roger Pincombe's blog](https://rogerpincombe.com/openai-dotnet-api) and forked from [OpenAI-API-dotnet](https://github.com/OkGoDoIt/OpenAI-API-dotnet).

This version is an unsupported fork from https://github.com/RageAgainstThePixel/OpenAI-DotNet/ v3.0.0 with some changes to support the Answers API and application specific hacks. 
I recommend not using this fork at this point - contact me if you are interested the changes and I will work to integrate them upstream.

## Requirements

This library is based on .NET Standard 2.0, so it should work across .NET Framework >=4.7.2 and .NET Core >= 3.0.  It should work across console apps, winforms, wpf, asp.net, etc. It should also work across Windows, Linux, and Mac.

## License

![CC-0 Public Domain](https://licensebuttons.net/p/zero/1.0/88x31.png)

This library is licensed CC-0, in the public domain.  You can use it for whatever you want, publicly or privately, without worrying about permission or licensing or whatever.  It's just a wrapper around the OpenAI API, so you still need to get access to OpenAI from them directly.  I am not affiliated with OpenAI and this library is not endorsed by them, I just have beta access and wanted to make a C# library to access it more easily.  Hopefully others find this useful as well.  Feel free to open a PR if there's anything you want to contribute.
