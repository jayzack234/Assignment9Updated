using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment9Updated.Models
{
    //Inherit from DB Context
    public class TaskListContext : DbContext
    {
        //constructor, bring the options into the context file
        //DbContexOptions of type TaskListContext
        //Inherients from the base option
        public TaskListContext (DbContextOptions<TaskListContext> options) : base (options)
        {

        }
        //Import a table, and the type is TaskList
        public DbSet<TaskItem> Tasks { get; set; }
    }
}
