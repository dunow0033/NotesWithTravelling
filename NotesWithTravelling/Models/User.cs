using NotesWithTravelling.Data;
using System.ComponentModel.DataAnnotations;

namespace NotesWithTravelling.Models
{
	public class User
	{
		public Guid Id { get; set; }

		[Required]
		public string Name { get; set; }

		[Required]
		public string PasswordHash { get; set; }

		public ICollection<Note> Notes { get; set; }
		public ICollection<Destination> Destinations { get; set; }
	}
}
