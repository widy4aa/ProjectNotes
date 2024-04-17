using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectNotes.Infrastructure
{
using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

public class TaskItem
{
    public Guid Id { get; set; }
    public Func<Task<bool>> TaskFunc { get; set; }
    public bool Success { get; set; }
}

public class TaskQueue
{
    private ConcurrentDictionary<Guid, TaskItem> Tasks = new ConcurrentDictionary<Guid, TaskItem>();

    public async Task<bool> AddTask(Func<Task<bool>> taskFunc)
    {
        var taskItem = new TaskItem { Id = Guid.NewGuid(), TaskFunc = taskFunc, Success = false };
        Tasks.TryAdd(taskItem.Id, taskItem);
        return await ExecuteTask(taskItem.Id);
    }

    private async Task<bool> ExecuteTask(Guid id)
    {
        if (Tasks.TryGetValue(id, out var taskItem))
        {
            try
            {
                var result = await taskItem.TaskFunc();
                if (result)
                {
                    taskItem.Success = true;
                    return true;
                }
                else
                {
                    Console.WriteLine($"Task {taskItem.Id} failed. Retrying...");
                    return await ExecuteTask(id);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Task {taskItem.Id} failed with exception: {ex}. Retrying...");
                return await ExecuteTask(id);
            }
        }
        return false;
    }

    public bool GetTaskResult(Guid id)
    {
        if (Tasks.TryGetValue(id, out var taskItem))
        {
            if (taskItem.Success)
            {
                Tasks.TryRemove(id, out _);
            }
            return taskItem.Success;
        }
        return false;
    }
}

}
