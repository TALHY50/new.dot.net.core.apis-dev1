//using System.Diagnostics;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Diagnostics;
//using App.Interfaces;

//namespace App.Services;

//public class QueryLogger
//{
//    private IUnitOfWork _unitOfWork;
//    public IDisposable NetworkSubscription;
//    public IDisposable ListenerSubscription;
//    public IDisposable DbSubscription;
//    public Stopwatch _stopwatch;
//    private int _queryCount = 0;
//    private string _fileName = "query.log";
//    private readonly object allListeners = new();

//    public QueryLogger(IUnitOfWork unitOfWork)
//    {
//        _unitOfWork = unitOfWork;
//        _stopwatch = new Stopwatch();

//    }

//    public void StartLogging(string file_name = null)
//    {
//        DiagnosticSource sqlLogger = new DiagnosticListener(DbLoggerCategory.Name);

//        if (file_name != null)
//        {
//            _fileName = file_name;
//        }

//        Action<KeyValuePair<string, object>> whenHeard = delegate (KeyValuePair<string, object> data)
//        {
//            if (data.Value is CommandEventData eventData)
//            {
//                if (data.Key == "Microsoft.EntityFrameworkCore.Database.Command.CommandCreated")
//                {
//                    _stopwatch.Restart();
//                }

//                if (data.Key == "Microsoft.EntityFrameworkCore.Database.Command.CommandExecuted")
//                {
//                    _stopwatch.Stop();
//                    var queryExecutionTime = _stopwatch.Elapsed;
//                    bool shouldDelete = _queryCount == 0;
//                    _queryCount++;
//                    var query = (_queryCount).ToString() + ":" + eventData.Command.CommandText + ": " + "\n" + "Time : " + queryExecutionTime.ToString();

//                    _unitOfWork.LogService.LogWrite(_fileName, query, shouldDelete);

//                }

//            }
//        };


//        Action<DiagnosticListener> onNewListener = delegate (DiagnosticListener listener)
//        {
//            Console.WriteLine($"New Listener discovered: {listener.Name}");
//            //Subscribe to the specific DiagnosticListener of interest.
//            if (listener.Name is DbLoggerCategory.Name)
//            {
//                //Use lock to ensure the callback code is thread safe.
//                lock (allListeners)
//                {
//                    if (DbSubscription != null)
//                    {
//                        DbSubscription.Dispose();
//                    }



//                    IObserver<KeyValuePair<string, object>> iobserver =
//                        new Observer<KeyValuePair<string, object>>(whenHeard, null);
//                    DbSubscription = listener.Subscribe(iobserver);
//                }
//            }
//        };

//        IObserver<DiagnosticListener> observer = new Observer<DiagnosticListener>(onNewListener, null);
//        ListenerSubscription = DiagnosticListener.AllListeners.Subscribe(observer);


//    }

//    public void StopLogging()
//    {
//        this.ListenerSubscription.Dispose();
//        this.DbSubscription.Dispose();
//    }



//}


//class Observer<T> : IObserver<T>
//{
//    public Observer(Action<T> onNext, Action onCompleted)
//    {
//        _onNext = onNext ?? new Action<T>(_ => { });
//        _onCompleted = onCompleted ?? new Action(() => { });
//    }

//    public void OnCompleted()
//    {
//        _onCompleted();
//    }

//    public void OnError(Exception error)
//    {
//    }

//    public void OnNext(T value)
//    {
//        _onNext(value);
//    }

//    private Action<T> _onNext;
//    private Action _onCompleted;
//}

namespace SharedKernel.Main.Infrastructure.Services;