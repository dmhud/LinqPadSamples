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

// BehaviorSubject хранит только последнее значение. А также требует в конструкторе значение по умолчанию
var subject = new BehaviorSubject<string>("a");
subject.Subscribe(x => Console.WriteLine("Default: {0}", x));

// Значение по умолчанию перезапишется значением 'b' и оно будет возвращено при подписке
var subject2 = new BehaviorSubject<string>("a");
subject2.OnNext("b");
subject.Subscribe(x => Console.WriteLine("LastValue: {0}", x));

// Возвращается последнее значение при подписке, а также все последующие
var subject3 = new BehaviorSubject<string>("a");
subject3.OnNext("b");
subject3.Subscribe(x => Console.WriteLine("LastValue with followings: {0}", x));
subject3.OnNext("c");
subject3.OnNext("d");

// Если подписка будет осуществлена после завершения последовательности (OnCompleted), 
// то ни одно значение не попадет к подписчиками
var subject4 = new BehaviorSubject<string>("a");
subject4.OnNext("b");
subject4.OnNext("c");
subject4.OnCompleted();
subject4.Subscribe(x => Console.WriteLine("No values: {0}", x));