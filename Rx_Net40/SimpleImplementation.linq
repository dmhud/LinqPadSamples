<Query Kind="Program">
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

// Пример простой реализации и использования интерфейсов IObserver<T> и IObservable<T>
public class MyConsoleObserver<T> : IObserver<T>
{
	public void OnNext(T value)
	{
		Console.WriteLine("Received value {0}", value);
	}
	public void OnError(Exception error)
	{
		Console.WriteLine("Sequence faulted with {0}", error);
	}
	public void OnCompleted()
	{
		Console.WriteLine("Sequence terminated");
	}
}

public class MySequenceOfNumbers : IObservable<int>
{
	public IDisposable Subscribe(IObserver<int> observer)
	{
		observer.OnNext(1);
		observer.OnNext(2);
		observer.OnNext(3);
		observer.OnCompleted();
		return Disposable.Empty;
	}
}
void Main()
{
	var numbers = new MySequenceOfNumbers();
	var observer = new MyConsoleObserver<int>();
	numbers.Subscribe(observer);
}
