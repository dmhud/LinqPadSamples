<Query Kind="Statements">
  <Reference>D:\Nuget\Rx-Core.2.2.5\lib\net40\System.Reactive.Core.dll</Reference>
  <Reference>D:\Nuget\Rx-Interfaces.2.2.5\lib\net40\System.Reactive.Interfaces.dll</Reference>
  <Reference>D:\Nuget\Rx-Linq.2.2.5\lib\net40\System.Reactive.Linq.dll</Reference>
  <Reference>D:\Nuget\Rx-PlatformServices.2.2.5\lib\net40\System.Reactive.PlatformServices.dll</Reference>
  <Namespace>System</Namespace>
  <Namespace>System.Collections.Generic</Namespace>
  <Namespace>System.Linq</Namespace>
  <Namespace>System.Reactive.Disposables</Namespace>
  <Namespace>System.Reactive.Linq</Namespace>
  <Namespace>System.Reactive.Subjects</Namespace>
</Query>

// Ключевым моментом в Rx служит следующее - что кога последовательность завершается  
// больше никаких элементов не попадает к подписчикам при вызове OnNext.
// Последовательность завершается либо после вызова OnCompleted, либо - OnError
var subject = new Subject<string>();
subject.Subscribe(Console.WriteLine);
subject.OnNext("a");
subject.OnNext("b");
subject.OnCompleted();
subject.OnNext("c");