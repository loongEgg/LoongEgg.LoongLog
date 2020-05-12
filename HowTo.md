# How to
## 从NuGet安装（Install from NuGet）
> 搜索**LoongEgg.LoongLog**并安装   
> search **LoongEgg.LoongLog** and install

## 激活所有日志记录功能（Enable all log）
```c#
Logger.EnableAll();
```
## 打印一个新的日志消息(Write a new log message)
只要在入口激活了，在别的类中就可以正常调用，Logger是一个静态工具类
```c#
Logger.WriteDebug("a debugmessage"); // 调试消息
Logger.WriteInformation("aninformation message"); // 一般消息
Logger.WriteWarning("a warning message"); // 警告
Logger.WriteError("a error message"); // 错误
```

## 关闭日志记录功能(Disable all log)
```c#
Logger.Disable();
```
