using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoStudio.Core.Models;

namespace PhotoStudio.Core.Services;

public class TaskService
{
    private readonly List<TaskItem> _tasks = new();
    private int _nextId = 1;

    public TaskItem Add(string title)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Название не может быть пустым.");

        var task = new TaskItem
        {
            Id = _nextId++,
            Title = title.Trim(),
            Status = PhotoStudio.Core.Models.TaskStatus.New
        };

        _tasks.Add(task);
        return task;
    }

    public List<TaskItem> GetAll()
    {
        // Возвращаем копию, чтобы внешний код не ломал список
        return _tasks.ToList();
    }
}

