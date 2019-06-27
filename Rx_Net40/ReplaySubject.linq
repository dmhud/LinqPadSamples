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

// Subject возвращает только новые значения
var subject = new Subject<string>();
subject.OnNext("a");
subject.Subscribe(x => Console.WriteLine("Subject: {0}", x));
subject.OnNext("b");
subject.OnNext("c");

// ReplaySubject возвращает все значения, даже те которые были до подписки
var replaySubject = new ReplaySubject<string>();
replaySubject.OnNext("a");
replaySubject.Subscribe(x => Console.WriteLine("ReplaySubject: {0}", x));
replaySubject.OnNext("b");
replaySubject.OnNext("c");

// ReplaySubject с ограничением буфера для сохранения последних полученных значений
var bufferSize = 2;
var replaySubject2 = new ReplaySubject<string>(bufferSize);
replaySubject2.OnNext("a");
replaySubject2.OnNext("b");
replaySubject2.OnNext("c");
replaySubject2.Subscribe(x => Console.WriteLine("ReplaySubject with buffer: {0}", x));
replaySubject2.OnNext("d");

// ReplaySubject с ограничением буфера по времени
var window = TimeSpan.FromMilliseconds(150);
var replaySubject3 = new ReplaySubject<string>(window);
replaySubject3.OnNext("w");
Thread.Sleep(TimeSpan.FromMilliseconds(100));
replaySubject3.OnNext("x");
Thread.Sleep(TimeSpan.FromMilliseconds(100));
replaySubject3.OnNext("y");
replaySubject3.Subscribe(x => Console.WriteLine("ReplaySubject with buffer by time: {0}", x));
replaySubject3.OnNext("z");

// Если подписка будет осуществлена после завершения последовательности (OnCompleted), 
// то все значения все равно попадут к подписчиками
var replaySubject4 = new ReplaySubject<string>();
replaySubject4.OnNext("a");
replaySubject4.OnNext("b");
replaySubject4.OnNext("c");
replaySubject4.OnCompleted();
replaySubject4.Subscribe(x => Console.WriteLine("ReplaySubject all values after OnCompleted: {0}", x));