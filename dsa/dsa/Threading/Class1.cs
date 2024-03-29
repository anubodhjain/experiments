﻿using System;
using System.Threading;
using System.Collections.Generic;

class ProducerConsumerQueue : IDisposable
{
    EventWaitHandle _wh = new AutoResetEvent(false);
    Thread _worker;
    readonly object _locker = new object();
    Queue<string> _tasks = new Queue<string>();

    public ProducerConsumerQueue()
    {
        _worker = new Thread(Work);
        _worker.Name = "A";
        _worker.Start();
    }

    public void EnqueueTask(string task)
    {
        Thread.Sleep(1900);
        lock (_locker) { 
            _tasks.Enqueue(task);
        }
        _wh.Set();
    }

    public void Dispose()
    {
        EnqueueTask(null); // Signal the consumer to exit. 
        _worker.Join(); // Wait for the consumer's thread to finish. 
        _wh.Close(); // Release any OS resources. 
    }
    void Work()
    {
        while (true)
        {
            string task = null;
            lock (_locker)
                if (_tasks.Count > 0)
                {
                    task = _tasks.Dequeue();
                    if (task == null) return;
                }
            if (task != null)
            {
                Console.WriteLine("Performing task: " + task);
                Thread.Sleep(1000); // simulate work... 
            }
            else
                _wh.WaitOne(); // No more tasks - wait for a signal 
        }
    }
}
