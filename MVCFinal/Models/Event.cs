using api.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCFinal.Models
{
    public class Event
    {
        [Key]
        public int EventId { get; set; }

        [Required(ErrorMessage = "Event Name is required")]
        public string EventName { get; set; }
        public string Description { get; set; }

        [Required(ErrorMessage = "Date is required")]
        [DataType(DataType.DateTime)]
        //[Range(typeof(DateTime), "11/28/2022", "01/12/2030")]
        [FromNow]
        public DateTime EventDate { get; set; }

        public DateTime? CreatedOn { get; set; }

        public DateTime? UpdatedOn { get; set; }

        //[Required]
        //[DataType(DataType.Time)]
        //public DateTime EventTime { get; set; }

        [Required(ErrorMessage = "The Duration must be between 0 to 72")]
        [Range(0, 72)]
        public int Duration { get; set; }
    }

    public class Skill
    {
        public int SkillId { get; set; }
        public string SkillName { get; set; }
        public int SkillRate { get; set; }
        public DateTime CreateDate { get; set; }
    }

    public class User
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
    }

    public class Question
    {
        public int QuestionID { get; set; }
        public string QuestionList { get; set; }
        public int UserID { get; set; }
        public virtual User user { get; set; }
    }

    public class Answer
    {
        public int AnswerID { get; set; }
        public string Comment { get; set; }
        public int UserID { get; set; }
        public DateTime? CommentDate { get; set; }

        public int QuestionID { get; set; }
        public virtual Question question { get; set; }
    }

    public class Employee
    {
        [Key]
        public int EmpID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Department { get; set; }
        public int Taskid { get; set; }
        public virtual Task task { get; set; }
    }

    public class Task
    {
        //Scalar properties

        public int Taskid { get; set; }
        public string tittle { get; set; }
        public string description { get; set; }
        public string category { get; set; }
        public DateTime AssignedDate { get; set; }
        public DateTime? DueDate { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }

        //Navigation properties
        public ICollection<Employee>  Emps { get; set; }
    }

    public class Cart
    {
        public int CartId { get; set; }
        public string CartName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? DueDate { get; set; }
        public int Rating { get; set; }
    }

    public class Item
    {
        public int ItemId { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Status { get; set; }

        public int CartId { get; set; }
        public virtual Cart cart { get; set; }
    }
    public class ToDo
    {
        public int ToDoId { get; set; }
        public string Title { get; set; }
        public string description { get; set; }
        public string Category { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime DueDate { get; set; }
    }

    public class Asset
    {
        public int AssetId { get; set; }
        public string AssetName { get; set; }
        public int AssetSku { get; set; }
        public string Description { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}