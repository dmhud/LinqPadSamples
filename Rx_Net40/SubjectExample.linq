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

Subject<int> subject = new Subject<int>();
var subscription = subject.Subscribe(
	x => Console.WriteLine("Value published: {0}", x),
	() => Console.WriteLine("Sequence Completed."));


subject.OnNext(1);
subject.OnNext(2);

subject.OnCompleted();
subscription.Dispose();