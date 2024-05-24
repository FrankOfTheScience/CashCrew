namespace CashCrew.Maui.Repository
{
    public class AuthRepository : PartecipantRepository
    {
        private readonly DatabaseContext _dbContext;
        public AuthRepository(DatabaseContext dbContext) : base(dbContext)
            => _dbContext = dbContext;

        public async Task<Partecipant> GetByUsernameAsync(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
                throw new ArgumentNullException(nameof(username));
            var Partecipant = await _dbContext.GetFileteredAsync<Partecipant>(x => x.Name.Equals(username, StringComparison.OrdinalIgnoreCase));
            return Partecipant.FirstOrDefault();
        }
    }
}
