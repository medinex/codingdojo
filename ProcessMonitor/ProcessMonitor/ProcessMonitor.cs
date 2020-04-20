using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Management;
using System.Text;
using System.Threading;

namespace ProcessMonitor
{
    public class PerformanceMonitor
    {
        private string _comment;
        private ManagementEventWatcher _start;
        private ManagementEventWatcher _stop;

        public PerformanceMonitor()
        {
            _start = new ManagementEventWatcher(new WqlEventQuery("SELECT * FROM Win32_ProcessStartTrace"));
            _stop = new ManagementEventWatcher(new WqlEventQuery("SELECT * FROM Win32_ProcessStartTrace"));

        }

        public void start()
        {
            startMonitoringOn(_start, "started");
            startMonitoringOn(_stop, "stopped");
        }

        public void stop()
        {
            stopMonitoringOn(_start);
            stopMonitoringOn(_stop);
        }

        private void startMonitoringOn(ManagementEventWatcher eventWatcher, string comment)
        {
            _comment = comment;
            eventWatcher.EventArrived += new EventArrivedEventHandler(reportOnConsole);
            eventWatcher.Start();
        }

        private void stopMonitoringOn(ManagementEventWatcher eventWatcher)
        {
            eventWatcher.Stop();
        }

        private void reportOnConsole(object sender, EventArrivedEventArgs e)
        {
            Console.WriteLine("Process {0}: {1}", _comment, e.NewEvent.Properties["ProcessName"].Value);
        }
    }
}
