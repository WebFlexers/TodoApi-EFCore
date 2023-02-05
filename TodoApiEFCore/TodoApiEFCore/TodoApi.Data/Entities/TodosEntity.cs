using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoApi.Data.Entities;
public class TodosEntity
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Name is required")]
    [Column(TypeName = "nvarchar(100)")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Description is required")]
    [Column(TypeName = "nvarchar(100)")]
    public string Description { get; set; }
    
    public List<TodoItemEntity> TodoItems { get; set; }

    [Required(ErrorMessage = "Status is required")]
    [Column(TypeName = "bit")]
    public bool Status { get; set; }
}
