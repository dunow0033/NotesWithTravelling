using System.ComponentModel.DataAnnotations;

namespace NotesWithTravelling.Models
{
	public class Note
	{
		public Guid Id { get; set; }

		[Required]
		public string Content { get; set; }

		[Required]
		public Guid UserId { get; set; }
		public User User { get; set; }

		[Required]
		public Guid DestinationId {  get; set; }
		public Destination Destination { get; set; }
	}
}
