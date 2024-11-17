using NotesWithTravelling.Data;
using System.ComponentModel.DataAnnotations;

namespace NotesWithTravelling.Models
{
	public class Destination
	{
		public Guid Id { get; set; }

		[Required]
		public string Name { get; set; }

		public ICollection<Note> Notes { get; set; } = new List<Note>();
		public ICollection<User> Users { get; set; } = new List<User>();

		public static IQueryable<Destination> GetMostNotes(TravelDbContext context)
		{
			return context.Destinations
				.Select(d => new
				{
					Destination = d,
					DestinationCount = d.Notes.Count
				})
				.OrderByDescending(d => d.DestinationCount)
				.Take(1)
				.Select(d => d.Destination);
		}
	}
}
