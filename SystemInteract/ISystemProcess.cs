using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.Remoting;

namespace SystemInteract
{
    public interface ISystemProcess
    {
        /// <summary>
        /// Gets the value that the associated process specified when it terminated.
        /// </summary>
        /// <returns>
        /// The code that the associated process specified when it terminated.
        /// </returns>
        /// <exception cref="T:System.InvalidOperationException">The process has not exited.-or- The process <see cref="P:System.Diagnostics.Process.Handle"/> is not valid. </exception><exception cref="T:System.NotSupportedException">You are trying to access the <see cref="P:System.Diagnostics.Process.ExitCode"/> property for a process that is running on a remote computer. This property is available only for processes that are running on the local computer.</exception><filterpriority>1</filterpriority>
        int ExitCode { get; }

        /// <summary>
        /// Gets a value indicating whether the associated process has been terminated.
        /// </summary>
        /// <returns>
        /// true if the operating system process referenced by the <see cref="T:System.Diagnostics.Process"/> component has terminated; otherwise, false.
        /// </returns>
        /// <exception cref="T:System.InvalidOperationException">There is no process associated with the object. </exception><exception cref="T:System.ComponentModel.Win32Exception">The exit code for the process could not be retrieved. </exception><exception cref="T:System.NotSupportedException">You are trying to access the <see cref="P:System.Diagnostics.Process.HasExited"/> property for a process that is running on a remote computer. This property is available only for processes that are running on the local computer.</exception><filterpriority>1</filterpriority>
        bool HasExited { get; }

        /// <summary>
        /// Gets the time that the associated process exited.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.DateTime"/> that indicates when the associated process was terminated.
        /// </returns>
        /// <exception cref="T:System.PlatformNotSupportedException">The platform is Windows 98 or Windows Millennium Edition (Windows Me), which does not support this property. </exception><exception cref="T:System.NotSupportedException">You are trying to access the <see cref="P:System.Diagnostics.Process.ExitTime"/> property for a process that is running on a remote computer. This property is available only for processes that are running on the local computer.</exception><filterpriority>1</filterpriority>
        DateTime ExitTime { get; }

        /// <summary>
        /// Gets the native handle of the associated process.
        /// </summary>
        /// <returns>
        /// The handle that the operating system assigned to the associated process when the process was started. The system uses this handle to keep track of process attributes.
        /// </returns>
        /// <exception cref="T:System.InvalidOperationException">The process has not been started or has exited. The <see cref="P:System.Diagnostics.Process.Handle"/> property cannot be read because there is no process associated with this <see cref="T:System.Diagnostics.Process"/> instance.-or- The <see cref="T:System.Diagnostics.Process"/> instance has been attached to a running process but you do not have the necessary permissions to get a handle with full access rights. </exception><exception cref="T:System.NotSupportedException">You are trying to access the <see cref="P:System.Diagnostics.Process.Handle"/> property for a process that is running on a remote computer. This property is available only for processes that are running on the local computer.</exception><filterpriority>1</filterpriority>
        IntPtr Handle { get; }

        /// <summary>
        /// Gets the number of handles opened by the process.
        /// </summary>
        /// <returns>
        /// The number of operating system handles the process has opened.
        /// </returns>
        /// <exception cref="T:System.PlatformNotSupportedException">The platform is Windows 98 or Windows Millennium Edition (Windows Me); set the <see cref="P:System.Diagnostics.ProcessStartInfo.UseShellExecute"/> property to false to access this property on Windows 98 and Windows Me.</exception><filterpriority>2</filterpriority>
        int HandleCount { get; }

        /// <summary>
        /// Gets the unique identifier for the associated process.
        /// </summary>
        /// <returns>
        /// The system-generated unique identifier of the process that is referenced by this <see cref="T:System.Diagnostics.Process"/> instance.
        /// </returns>
        /// <exception cref="T:System.InvalidOperationException">The process's <see cref="P:System.Diagnostics.Process.Id"/> property has not been set.-or- There is no process associated with this <see cref="T:System.Diagnostics.Process"/> object. </exception><exception cref="T:System.PlatformNotSupportedException">The platform is Windows 98 or Windows Millennium Edition (Windows Me); set the <see cref="P:System.Diagnostics.ProcessStartInfo.UseShellExecute"/> property to false to access this property on Windows 98 and Windows Me.</exception><filterpriority>1</filterpriority>
        int Id { get; }

        /// <summary>
        /// Gets the name of the computer the associated process is running on.
        /// </summary>
        /// <returns>
        /// The name of the computer that the associated process is running on.
        /// </returns>
        /// <exception cref="T:System.InvalidOperationException">There is no process associated with this <see cref="T:System.Diagnostics.Process"/> object. </exception><filterpriority>1</filterpriority>
        string MachineName { get; }

        /// <summary>
        /// Gets the window handle of the main window of the associated process.
        /// </summary>
        /// <returns>
        /// The system-generated window handle of the main window of the associated process.
        /// </returns>
        /// <exception cref="T:System.InvalidOperationException">The <see cref="P:System.Diagnostics.Process.MainWindowHandle"/> is not defined because the process has exited. </exception><exception cref="T:System.NotSupportedException">You are trying to access the <see cref="P:System.Diagnostics.Process.MainWindowHandle"/> property for a process that is running on a remote computer. This property is available only for processes that are running on the local computer.</exception><exception cref="T:System.PlatformNotSupportedException">The platform is Windows 98 or Windows Millennium Edition (Windows Me); set <see cref="P:System.Diagnostics.ProcessStartInfo.UseShellExecute"/> to false to access this property on Windows 98 and Windows Me.</exception><filterpriority>2</filterpriority>
        IntPtr MainWindowHandle { get; }

        /// <summary>
        /// Gets the caption of the main window of the process.
        /// </summary>
        /// <returns>
        /// The main window title of the process.
        /// </returns>
        /// <exception cref="T:System.InvalidOperationException">The <see cref="P:System.Diagnostics.Process.MainWindowTitle"/> property is not defined because the process has exited. </exception><exception cref="T:System.NotSupportedException">You are trying to access the <see cref="P:System.Diagnostics.Process.MainWindowTitle"/> property for a process that is running on a remote computer. This property is available only for processes that are running on the local computer.</exception><exception cref="T:System.PlatformNotSupportedException">The platform is Windows 98 or Windows Millennium Edition (Windows Me); set <see cref="P:System.Diagnostics.ProcessStartInfo.UseShellExecute"/> to false to access this property on Windows 98 and Windows Me.</exception><filterpriority>1</filterpriority>
        string MainWindowTitle { get; }

        /// <summary>
        /// Gets the name of the process.
        /// </summary>
        /// <returns>
        /// The name that the system uses to identify the process to the user.
        /// </returns>
        /// <exception cref="T:System.InvalidOperationException">The process does not have an identifier, or no process is associated with the <see cref="T:System.Diagnostics.Process"/>.-or- The associated process has exited. </exception><exception cref="T:System.PlatformNotSupportedException">The platform is Windows 98 or Windows Millennium Edition (Windows Me); set <see cref="P:System.Diagnostics.ProcessStartInfo.UseShellExecute"/> to false to access this property on Windows 98 and Windows Me.</exception><exception cref="T:System.NotSupportedException">The process is not on this computer.</exception><filterpriority>1</filterpriority>
        string ProcessName { get; }


        /// <summary>
        /// Gets or sets the properties to pass to the <see cref="M:System.Diagnostics.Process.Start"/> method of the <see cref="T:System.Diagnostics.Process"/>.
        /// </summary>
        /// <returns>
        /// The <see cref="T:System.Diagnostics.ProcessStartInfo"/> that represents the data with which to start the process. These arguments include the name of the executable file or document used to start the process.
        /// </returns>
        /// <exception cref="T:System.ArgumentNullException">The value that specifies the <see cref="P:System.Diagnostics.Process.StartInfo"/> is null. </exception><filterpriority>1</filterpriority>
        ProcessStartInfo StartInfo { get; set; }

        /// <summary>
        /// Gets the time that the associated process was started.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.DateTime"/> that indicates when the process started. This only has meaning for started processes.
        /// </returns>
        /// <exception cref="T:System.PlatformNotSupportedException">The platform is Windows 98 or Windows Millennium Edition (Windows Me), which does not support this property. </exception><exception cref="T:System.NotSupportedException">You are attempting to access the <see cref="P:System.Diagnostics.Process.StartTime"/> property for a process that is running on a remote computer. This property is available only for processes that are running on the local computer. </exception><exception cref="T:System.InvalidOperationException">The process has exited.</exception><exception cref="T:System.ComponentModel.Win32Exception">An error occurred in the call to the Windows function.</exception><filterpriority>1</filterpriority>
        DateTime StartTime { get; }

        /// <summary>
        /// Gets a stream used to write the input of the application.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.IO.StreamWriter"/> that can be used to write the standard input stream of the application.
        /// </returns>
        /// <exception cref="T:System.InvalidOperationException">The <see cref="P:System.Diagnostics.Process.StandardInput"/> stream has not been defined because <see cref="P:System.Diagnostics.ProcessStartInfo.RedirectStandardInput"/> is set to false. </exception><filterpriority>1</filterpriority>
        StreamWriter StandardInput { get; }

        /// <summary>
        /// Gets a stream used to read the output of the application.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.IO.StreamReader"/> that can be used to read the standard output stream of the application.
        /// </returns>
        /// <exception cref="T:System.InvalidOperationException">The <see cref="P:System.Diagnostics.Process.StandardOutput"/> stream has not been defined for redirection; ensure <see cref="P:System.Diagnostics.ProcessStartInfo.RedirectStandardOutput"/> is set to true and <see cref="P:System.Diagnostics.ProcessStartInfo.UseShellExecute"/> is set to false.- or - The <see cref="P:System.Diagnostics.Process.StandardOutput"/> stream has been opened for asynchronous read operations with <see cref="M:System.Diagnostics.Process.BeginOutputReadLine"/>. </exception><filterpriority>1</filterpriority>
        StreamReader StandardOutput { get; }

        /// <summary>
        /// Gets a stream used to read the error output of the application.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.IO.StreamReader"/> that can be used to read the standard error stream of the application.
        /// </returns>
        /// <exception cref="T:System.InvalidOperationException">The <see cref="P:System.Diagnostics.Process.StandardError"/> stream has not been defined for redirection; ensure <see cref="P:System.Diagnostics.ProcessStartInfo.RedirectStandardError"/> is set to true and <see cref="P:System.Diagnostics.ProcessStartInfo.UseShellExecute"/> is set to false.- or - The <see cref="P:System.Diagnostics.Process.StandardError"/> stream has been opened for asynchronous read operations with <see cref="M:System.Diagnostics.Process.BeginErrorReadLine"/>. </exception><filterpriority>1</filterpriority>
        StreamReader StandardError { get; }

        /// <summary>
        /// Gets the associated process's physical memory usage.
        /// </summary>
        /// <returns>
        /// The total amount of physical memory the associated process is using, in bytes.
        /// </returns>
        /// <exception cref="T:System.PlatformNotSupportedException">The platform is Windows 98 or Windows Millennium Edition (Windows Me), which does not support this property. </exception><filterpriority>2</filterpriority>
        int WorkingSet { get; }

        /// <summary>
        /// Gets the amount of physical memory allocated for the associated process.
        /// </summary>
        /// <returns>
        /// The amount of physical memory, in bytes, allocated for the associated process.
        /// </returns>
        /// <exception cref="T:System.PlatformNotSupportedException">The platform is Windows 98 or Windows Millennium Edition (Windows Me), which does not support this property.</exception><filterpriority>2</filterpriority>
        long WorkingSet64 { get; }

        event EventHandler Disposed;

        /// <summary>
        /// Closes a process that has a user interface by sending a close message to its main window.
        /// </summary>
        /// <returns>
        /// true if the close message was successfully sent; false if the associated process does not have a main window or if the main window is disabled (for example if a modal dialog is being shown).
        /// </returns>
        /// <exception cref="T:System.PlatformNotSupportedException">The platform is Windows 98 or Windows Millennium Edition (Windows Me); set the <see cref="P:System.Diagnostics.ProcessStartInfo.UseShellExecute"/> property to false to access this property on Windows 98 and Windows Me.</exception><exception cref="T:System.InvalidOperationException">The process has already exited. -or-No process is associated with this <see cref="T:System.Diagnostics.Process"/> object.</exception><filterpriority>1</filterpriority>
        bool CloseMainWindow();

        /// <summary>
        /// Frees all the resources that are associated with this component.
        /// </summary>
        /// <filterpriority>2</filterpriority>
        void Close();

        /// <summary>
        /// Discards any information about the associated process that has been cached inside the process component.
        /// </summary>
        /// <filterpriority>1</filterpriority>
        void Refresh();

        /// <summary>
        /// Starts (or reuses) the process resource that is specified by the <see cref="P:System.Diagnostics.Process.StartInfo"/> property of this <see cref="T:System.Diagnostics.Process"/> component and associates it with the component.
        /// </summary>
        /// <returns>
        /// true if a process resource is started; false if no new process resource is started (for example, if an existing process is reused).
        /// </returns>
        /// <exception cref="T:System.InvalidOperationException">No file name was specified in the <see cref="T:System.Diagnostics.Process"/> component's <see cref="P:System.Diagnostics.Process.StartInfo"/>.-or- The <see cref="P:System.Diagnostics.ProcessStartInfo.UseShellExecute"/> member of the <see cref="P:System.Diagnostics.Process.StartInfo"/> property is true while <see cref="P:System.Diagnostics.ProcessStartInfo.RedirectStandardInput"/>, <see cref="P:System.Diagnostics.ProcessStartInfo.RedirectStandardOutput"/>, or <see cref="P:System.Diagnostics.ProcessStartInfo.RedirectStandardError"/> is true. </exception><exception cref="T:System.ComponentModel.Win32Exception">There was an error in opening the associated file. </exception><exception cref="T:System.ObjectDisposedException">The process object has already been disposed. </exception><filterpriority>1</filterpriority>
        bool Start();

        /// <summary>
        /// Immediately stops the associated process.
        /// </summary>
        /// <exception cref="T:System.ComponentModel.Win32Exception">The associated process could not be terminated. -or-The process is terminating.-or- The associated process is a Win16 executable.</exception><exception cref="T:System.NotSupportedException">You are attempting to call <see cref="M:System.Diagnostics.Process.Kill"/> for a process that is running on a remote computer. The method is available only for processes running on the local computer.</exception><exception cref="T:System.InvalidOperationException">The process has already exited. -or-There is no process associated with this <see cref="T:System.Diagnostics.Process"/> object.</exception><filterpriority>1</filterpriority>
        void Kill();

        /// <summary>
        /// Instructs the <see cref="T:System.Diagnostics.Process"/> component to wait the specified number of milliseconds for the associated process to exit.
        /// </summary>
        /// <returns>
        /// true if the associated process has exited; otherwise, false.
        /// </returns>
        /// <param name="milliseconds">The amount of time, in milliseconds, to wait for the associated process to exit. The maximum is the largest possible value of a 32-bit integer, which represents infinity to the operating system. </param><exception cref="T:System.ComponentModel.Win32Exception">The wait setting could not be accessed. </exception><exception cref="T:System.SystemException">No process <see cref="P:System.Diagnostics.Process.Id"/> has been set, and a <see cref="P:System.Diagnostics.Process.Handle"/> from which the <see cref="P:System.Diagnostics.Process.Id"/> property can be determined does not exist.-or- There is no process associated with this <see cref="T:System.Diagnostics.Process"/> object.-or- You are attempting to call <see cref="M:System.Diagnostics.Process.WaitForExit(System.Int32)"/> for a process that is running on a remote computer. This method is available only for processes that are running on the local computer. </exception><filterpriority>1</filterpriority>
        bool WaitForExit(int milliseconds);

        /// <summary>
        /// Instructs the <see cref="T:System.Diagnostics.Process"/> component to wait indefinitely for the associated process to exit.
        /// </summary>
        /// <exception cref="T:System.ComponentModel.Win32Exception">The wait setting could not be accessed. </exception><exception cref="T:System.SystemException">No process <see cref="P:System.Diagnostics.Process.Id"/> has been set, and a <see cref="P:System.Diagnostics.Process.Handle"/> from which the <see cref="P:System.Diagnostics.Process.Id"/> property can be determined does not exist.-or- There is no process associated with this <see cref="T:System.Diagnostics.Process"/> object.-or- You are attempting to call <see cref="M:System.Diagnostics.Process.WaitForExit"/> for a process that is running on a remote computer. This method is available only for processes that are running on the local computer. </exception><filterpriority>1</filterpriority>
        void WaitForExit();

        /// <summary>
        /// Causes the <see cref="T:System.Diagnostics.Process"/> component to wait the specified number of milliseconds for the associated process to enter an idle state. This overload applies only to processes with a user interface and, therefore, a message loop.
        /// </summary>
        /// <returns>
        /// true if the associated process has reached an idle state; otherwise, false.
        /// </returns>
        /// <param name="milliseconds">A value of 1 to <see cref="F:System.Int32.MaxValue"/> that specifies the amount of time, in milliseconds, to wait for the associated process to become idle. A value of 0 specifies an immediate return, and a value of -1 specifies an infinite wait. </param><exception cref="T:System.InvalidOperationException">The process does not have a graphical interface.-or-An unknown error occurred. The process failed to enter an idle state.-or-The process has already exited. -or-No process is associated with this <see cref="T:System.Diagnostics.Process"/> object.</exception><filterpriority>1</filterpriority>
        bool WaitForInputIdle(int milliseconds);

        /// <summary>
        /// Causes the <see cref="T:System.Diagnostics.Process"/> component to wait indefinitely for the associated process to enter an idle state. This overload applies only to processes with a user interface and, therefore, a message loop.
        /// </summary>
        /// <returns>
        /// true if the associated process has reached an idle state.
        /// </returns>
        /// <exception cref="T:System.InvalidOperationException">The process does not have a graphical interface.-or-An unknown error occurred. The process failed to enter an idle state.-or-The process has already exited. -or-No process is associated with this <see cref="T:System.Diagnostics.Process"/> object.</exception><filterpriority>1</filterpriority>
        bool WaitForInputIdle();

        /// <summary>
        /// Begins asynchronous read operations on the redirected <see cref="P:System.Diagnostics.Process.StandardOutput"/> stream of the application.
        /// </summary>
        /// <exception cref="T:System.InvalidOperationException">The <see cref="P:System.Diagnostics.ProcessStartInfo.RedirectStandardOutput"/> property is false.- or - An asynchronous read operation is already in progress on the <see cref="P:System.Diagnostics.Process.StandardOutput"/> stream.- or - The <see cref="P:System.Diagnostics.Process.StandardOutput"/> stream has been used by a synchronous read operation. </exception><filterpriority>2</filterpriority>
        void BeginOutputReadLine();

        /// <summary>
        /// Begins asynchronous read operations on the redirected <see cref="P:System.Diagnostics.Process.StandardError"/> stream of the application.
        /// </summary>
        /// <exception cref="T:System.InvalidOperationException">The <see cref="P:System.Diagnostics.ProcessStartInfo.RedirectStandardError"/> property is false.- or - An asynchronous read operation is already in progress on the <see cref="P:System.Diagnostics.Process.StandardError"/> stream.- or - The <see cref="P:System.Diagnostics.Process.StandardError"/> stream has been used by a synchronous read operation. </exception><filterpriority>2</filterpriority>
        void BeginErrorReadLine();

        /// <summary>
        /// Cancels the asynchronous read operation on the redirected <see cref="P:System.Diagnostics.Process.StandardOutput"/> stream of an application.
        /// </summary>
        /// <exception cref="T:System.InvalidOperationException">The <see cref="P:System.Diagnostics.Process.StandardOutput"/> stream is not enabled for asynchronous read operations. </exception><filterpriority>2</filterpriority>
        void CancelOutputRead();

        /// <summary>
        /// Cancels the asynchronous read operation on the redirected <see cref="P:System.Diagnostics.Process.StandardError"/> stream of an application.
        /// </summary>
        /// <exception cref="T:System.InvalidOperationException">The <see cref="P:System.Diagnostics.Process.StandardError"/> stream is not enabled for asynchronous read operations. </exception><filterpriority>2</filterpriority>
        void CancelErrorRead();

        event DataReceivedEventHandler OutputDataReceived;
        event DataReceivedEventHandler ErrorDataReceived;
        event EventHandler Exited;
    }
}