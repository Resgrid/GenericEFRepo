using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Resgrid.Model
{

	[Table("TodoLists")]
	public class TodoList: IEntity
	{
		[Key]
		[Required]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int TodoListId { get; set; }

		[Required]
		public string Name { get; set; }

		public virtual ICollection<TodoListItem> Items { get; set; }

		[NotMapped]
		public object Id
		{
			get { return TodoListId; }
			set { TodoListId = (int)value; }
		}
	}
}
