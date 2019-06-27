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

// AsyncSubject хранит только последнее значение, но оно будет отправлено подписчикам, 
// только после завершения последовательности (OnCompleted)
// В этом примере ничего не будет выведено
var subject = new AsyncSubject<string>();
subject.OnNext("a");
subject.Subscribe(x => Console.WriteLine("No values: {0}", x));
subject.OnNext("b");
subject.OnNext("c");

// В этом примере после вызова OnCompleted, будет выведено последнее значение 'c'
var subject2 = new AsyncSubject<string>();
subject2.OnNext("a");
subject2.Subscribe(x => Console.WriteLine("Last value: {0}", x));
subject2.OnNext("b");
subject2.OnNext("c");
subject2.OnCompleted();

// В этом примере будет выведено последнее значение - 'b', которое было добавлено перед вызовом OnCompleted
// Последующие значения будут проигнорированы
var subject3 = new AsyncSubject<string>();
subject3.OnNext("a");
subject3.Subscribe(x => Console.WriteLine("Last value before completed: {0}", x));
subject3.OnNext("b");
subject3.OnCompleted();
subject3.OnNext("c");