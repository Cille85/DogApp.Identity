using DogApp.Shared.EntityModels;
using DogApp.Data;

namespace DogApp.Repository;

public class TrackRepo(DataContext context) : GenericRepository<Track>(context), ITrackRepo
{
}

