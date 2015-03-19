using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Resgrid.Model
{
	[Table("TodoListItems")]
	public class TodoListItem : IEntity
	{
		[Key]
		[Required]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int TodoListItemId { get; set; }

		[Required]
		[ForeignKey("TodoList"), DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int TodoListId { get; set; }

		public virtual TodoList TodoList { get; set; }

		[Required]
		public string Task { get; set; }
		public bool Complete { get; set; }

		[NotMapped]
		public object Id
		{
			get { return TodoListItemId; }
			set { TodoListItemId = (int)value; }
		}
	}
}
