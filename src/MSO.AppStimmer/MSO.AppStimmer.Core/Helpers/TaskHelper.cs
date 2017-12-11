using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MSO.StimmApp.Core.Helpers
{
    /// <summary>
    /// Helper class for dealing with tasks.
    /// </summary>
    public static class TaskHelper
    {
        /// <summary>
        /// Runs some tasks simultaneously. You can specify the number of tasks that should run simultaneously.
        /// For example: If you pass a list with 8 tasks and a maxParallelCount of 3, this will happen:
        /// 3 tasks will run simultaneously. After that, another 3 tasks will run simultaneously. 
        /// Finally, the 2 remaining tasks will run simultaneously.
        /// </summary>
        /// <param name="tasks">The list of tasks</param>
        /// <param name="maxParallelCount">The maximum number of simultaneously running tasks</param>
        /// <returns>The task</returns>
        public static async Task RunParallel(IEnumerable<Task> tasks, int maxParallelCount = 0)
        {
            // negative maxParallel count? Just run the tasks, without any logic
            if (maxParallelCount <= 0)
            {
                await Task.WhenAll(tasks);
                return;
            }

            using (var semaphore = new SemaphoreSlim(maxParallelCount))
            {
                var items = new List<Task>();
                foreach (var task in tasks)
                {
                    await semaphore.WaitAsync();
                    items.Add(task.ContinueWith(t =>
                    {
                        // ReSharper disable once ConvertToLambdaExpression
                        // ReSharper disable once AccessToDisposedClosure
                        return semaphore.Release();
                    }));
                }

                await Task.WhenAll(items);
            }
        }


        /// <summary>
        /// Runs a task with a given timeout. 
        /// If the timeout is being exceeded, a dialog with a given message will appear.
        /// </summary>
        /// <param name="task">The task</param>
        /// <param name="timeout">The timeout in milliseconds</param>
        /// <param name="timeoutMessage">The message that will be displayed when exceeding the timeout for the task</param>
        /// <returns>The task</returns>
        public static async Task RunTaskWithTimeout(Task task, int timeout, string timeoutMessage)
        {
            if (await Task.WhenAny(task, Task.Delay(timeout)) == task)
            {
                // task completed within timeout
            }
            else
            {
                // task not completed within timeout              
            }
        }
    }
}
