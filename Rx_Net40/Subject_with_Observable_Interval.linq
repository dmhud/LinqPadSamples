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

var source = Observable.Interval(TimeSpan.FromSeconds(1));
Subject<long> subject = new Subject<long>();
var subSource = source.Subscribe(subject);
var subSubject1 = subject.Subscribe(
                         x => Console.WriteLine("Value published to observer #1: {0}", x),
                         () => Console.WriteLine("Sequence Completed."));
var subSubject2 = subject.Subscribe(
                         x => Console.WriteLine("Value published to observer #2: {0}", x),
                         () => Console.WriteLine("Sequence Completed."));

Thread.Sleep(10000);
subject.OnCompleted();
subSubject1.Dispose();
subSubject2.Dispose();