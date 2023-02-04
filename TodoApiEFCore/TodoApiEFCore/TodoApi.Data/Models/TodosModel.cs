using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApi.Data.Models;
public class TodosModel
{
    [Key]
    public int TodosId { get; set; }

    [Required(ErrorMessage = "TodosName is required")]
    [Column(TypeName = "nvarchar(100)")]
    public string TodosName { get; set; }

    [Required(ErrorMessage = "TodosDescription is required")]
    [Column(TypeName = "nvarchar(100)")]
    public string TodosDescription { get; set; }
    
    public List<TodoItemModel> Todoitems { get; set; }

    [Required(ErrorMessage = "ItemStatus is required")]
    [Column(TypeName = "bit")]
    public bool TodosStatus { get; set; }
}
