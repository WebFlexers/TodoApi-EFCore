using TodoApi.Data.Authentication;

namespace TodoApi.Data.Entities;
public class TodoItem
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public bool Status { get; set; }

    public int TodosId { get; set; }
    public Todos Todos { get; set; }

    public string UserId { get; set; }
    public virtual ApplicationUser User { get; set; }
}
